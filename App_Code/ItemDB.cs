using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class ItemDB
{
    static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<Item> getAllItem()
    {
        List<Item> itemList = new List<Item>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Item");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Item i = new Item();
                readAItem(ref i, ref reader);

                itemList.Add(i);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return itemList;
    }

    // Need to clarify whether this particular function is working
    public static List<Item> searchItembyName(string keyword, string location, string categoryName)
    {
        List<Item> itemList = new List<Item>();
        try
        {

            string sqlcommand = "SELECT * FROM Item WHERE name LIKE @name";

            if (location != null)
                sqlcommand += "AND I.locationName = @locationName ";

            if (categoryName != null)
                sqlcommand += "AND I.categoryName = @categoryName ";

            SqlCommand command = new SqlCommand(sqlcommand);

            command.Parameters.AddWithValue("@name", "%" + keyword + "%");

            if (location != null)
                command.Parameters.AddWithValue("@locationName", location);

            if (categoryName != null)
                command.Parameters.AddWithValue("@categoryName", categoryName);

            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Item i = new Item();
            while (reader.Read())
            {
                readAItem(ref i, ref reader);

                itemList.Add(i);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return itemList;
    }

    public static Item getItembyID(string itemID)
    {
        Item i = new Item();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Item WHERE itemID = @itemID");
            command.Parameters.AddWithValue("@itemID", itemID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAItem(ref i, ref reader);
            else
                i = new Item(null, null, null, new DateTime(), 0, 0, 0, 0, null, null, null, null, new Member(), new Category(), new Location());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return i;
    }

    public static List<Item> getAllItemofMember(string memberID)
    {
        List<Item> itemList = new List<Item>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Item WHERE renterID = @renterID");
            command.Parameters.AddWithValue("@renterID", memberID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Item i = new Item();
                readAItem(ref i, ref reader);

                itemList.Add(i);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return itemList;
    }

    public static int addItem(Item item)
    {
        /* please insert PricePerDay/Week/Month as 0 if you want them to be inserted null in the Database
            and also please insert img as a null to be inserted null in the database */
        try
        {
            string commandString = "INSERT INTO Item (name, description, postedDate, deposit, categoryName, pricePerDay, pricePerWeek, pricePerMonth, img1, img2, img3, img4, renterID, locationName)";
            commandString += " VALUES (@name, @description, @postedDate, @deposit, @categoryName, @pricePerDay, @pricePerWeek, @pricePerMonth, @img1, @img2, @img3, @img4, @renterID, @locationName)";
            SqlCommand command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@description", item.Description);
            command.Parameters.AddWithValue("@postedDate", item.PostedDate);
            command.Parameters.AddWithValue("@deposit", item.Deposit);
            command.Parameters.AddWithValue("@categoryName", item.CategoryName.Name);

            if (item.PricePerDay > 0)
                command.Parameters.AddWithValue("@pricePerDay", item.PricePerDay);
            else
                command.Parameters.AddWithValue("@pricePerDay", DBNull.Value);

            if (item.PricePerWeek > 0)
                command.Parameters.AddWithValue("@pricePerWeek", item.PricePerWeek);
            else
                command.Parameters.AddWithValue("@pricePerWeek", DBNull.Value);

            if (item.PricePerMonth > 0)
                command.Parameters.AddWithValue("@pricePerMonth", item.PricePerMonth);
            else
                command.Parameters.AddWithValue("@pricePerMonth", DBNull.Value);

            if (item.Img1 != null)
                command.Parameters.AddWithValue("@img1", item.Img1);
            else
                command.Parameters.AddWithValue("@img1", DBNull.Value);

            if (item.Img2 != null)
                command.Parameters.AddWithValue("@img2", item.Img2);
            else
                command.Parameters.AddWithValue("@img2", DBNull.Value);

            if (item.Img3 != null)
                command.Parameters.AddWithValue("@img3", item.Img3);
            else
                command.Parameters.AddWithValue("@img3", DBNull.Value);

            if (item.Img4 != null)
                command.Parameters.AddWithValue("@img4", item.Img4);
            else
                command.Parameters.AddWithValue("@img4", DBNull.Value);

            command.Parameters.AddWithValue("@renterID", item.Renter.MemberID);
            command.Parameters.AddWithValue("@locationName", item.Location.Name);

            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                command.CommandText = "Select @@identity";
                return Convert.ToInt32(command.ExecuteScalar());

            }
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    private static void readAItem(ref Item i, ref SqlDataReader reader)
    {
        i.ItemID = reader["itemID"].ToString();
        i.Name = reader["name"].ToString();
        i.Description = reader["description"].ToString();
        i.PostedDate = Convert.ToDateTime(reader["postedDate"]);
        i.Deposit = Convert.ToDecimal(reader["deposit"]);
        i.CategoryName = CategoryDB.getCategorybyName(reader["categoryName"].ToString());
        i.Location = LocationDB.getLocationbyID(reader["locationName"].ToString());

        //This sectin will set the default value of 0 whenever null is found in the database
        if (reader["pricePerDay"] != DBNull.Value)
            i.PricePerDay = Convert.ToDecimal(reader["pricePerDay"]);
        else
            i.PricePerDay = 0;

        if (reader["pricePerWeek"] != DBNull.Value)
            i.PricePerWeek = Convert.ToDecimal(reader["pricePerWeek"]);
        else
            i.PricePerWeek = 0;

        if (reader["pricePerMonth"] != DBNull.Value)
            i.PricePerMonth = Convert.ToDecimal(reader["pricePerMonth"]);
        else
            i.PricePerMonth = 0;

        // This section for collecting images
        if (reader["img1"] != DBNull.Value)
            i.Img1 = reader["img1"].ToString();
        else
            i.Img1 = "NotAvailable.jpg";

        if (reader["img2"] != DBNull.Value)
            i.Img2 = reader["img2"].ToString();
        else
            i.Img2 = "NotAvailable.jpg";

        if (reader["img3"] != DBNull.Value)
            i.Img3 = reader["img3"].ToString();
        else
            i.Img3 = "NotAvailable.jpg";

        if (reader["img4"] != DBNull.Value)
            i.Img4 = reader["img4"].ToString();
        else
            i.Img4 = "NotAvailable.jpg";

        //This section for getting the renter of an item
        i.Renter = MemberDB.getMemberbyID(reader["renterID"].ToString());
    }
}