using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class ItemTagDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // gets itemtags from the database based on user input
    // insert null to location if you dont want to search based on location
    public static List<ItemTag> getItemsWithTags(List<string> tagName, string location, string categoryName)
    {
        List<ItemTag> itemTagList = new List<ItemTag>();
        try
        {
            string sqlcommand = "SELECT * FROM ItemTag IT, Item I WHERE I.itemID=IT.itemID AND ( i.pricePerDay IS NOT NULL OR I.pricePerWeek IS NOT NULL OR I.pricePerMonth IS NOT NULL ) ";

            if (location != null)
                sqlcommand += "AND I.locationName = @locationName ";

            if (categoryName != null)
                sqlcommand += "AND I.categoryName = @categoryName ";

            sqlcommand += " and IT.tagName IN (";

            int iTagCounter = 0;
            foreach (string tag in tagName)
            {
                if (iTagCounter < tagName.Count - 1)
                    sqlcommand += "@tagName" + iTagCounter + ", ";
                else
                    sqlcommand += "@tagName" + iTagCounter + ")";
                iTagCounter++;
            }

            SqlCommand command = new SqlCommand(sqlcommand);

            if (location != null)
                command.Parameters.AddWithValue("@locationName", location);

            if (categoryName != null)
                command.Parameters.AddWithValue("@categoryName", categoryName);

            iTagCounter = 0;
            foreach (string tag in tagName)
            {
                command.Parameters.AddWithValue("@tagName" + iTagCounter, tag);
                iTagCounter++;
            }


            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ItemTag itemTag = new ItemTag();

                readAItemTag(ref itemTag, ref reader);
                itemTagList.Add(itemTag);
            }

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return itemTagList;
    }

    // gets itemtags from the database based on user input - search input for tags may not be exact same as tag in database
    public static List<ItemTag> getItemsWithTagsLike(List<string> tagName, string location, string categoryName)
    {
        List<ItemTag> itemTagList = new List<ItemTag>();
        try
        {
            string sqlcommand = "SELECT * FROM ItemTag IT, Item I WHERE I.itemID=IT.itemID AND ( I.pricePerDay IS NOT NULL OR I.pricePerWeek IS NOT  NULL OR I.pricePerMonth IS NOT  NULL ) ";

            if (location != null)
                sqlcommand += "AND I.locationName = @locationName ";

            if (categoryName != null)
                sqlcommand += "AND I.categoryName = @categoryName ";

            sqlcommand += " and (";

            int iTagCounter = 0;
            foreach (string tag in tagName)
            {
                sqlcommand += "IT.tagName LIKE ";
                if (iTagCounter < tagName.Count - 1)
                    sqlcommand += "@tagName" + iTagCounter + " OR ";
                else
                    sqlcommand += "@tagName" + iTagCounter + ")";
                iTagCounter++;
            }

            SqlCommand command = new SqlCommand(sqlcommand);

            if (location != null)
                command.Parameters.AddWithValue("@locationName", location);

            if (categoryName != null)
                command.Parameters.AddWithValue("@categoryName", categoryName);

            iTagCounter = 0;
            foreach (string tag in tagName)
            {
                command.Parameters.AddWithValue("@tagName" + iTagCounter, "%" + tag + "%");
                iTagCounter++;
            }

            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ItemTag itemTag = new ItemTag();

                readAItemTag(ref itemTag, ref reader);
                itemTagList.Add(itemTag);
            }

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return itemTagList;
    }

    // adds itemtags into the database, takes in parameters of type item and string
    public static int addItemTag(Item item, string tagName)
    {
        try
        {
            string commandString = "INSERT INTO ItemTag (itemID, tagName) VALUES (@itemID, @tagName)";
            SqlCommand command = new SqlCommand(commandString);
            command.Parameters.AddWithValue("@itemID", item.ItemID);
            command.Parameters.AddWithValue("@tagName", tagName);

            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
                return 1;
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    // delete itemtags from database based on itemID, keeps database consistent if item tags were to be modified
    public static int deleteItemTag(string itemID)
    {
        try
        {
            SqlCommand command = new SqlCommand("DELETE FROM ItemTag WHERE itemID=@itemID");
            command.Parameters.AddWithValue("@itemID", itemID);
            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                return 1;
            }
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    // gets item tags based on itemID from the database
    public static List<string> getTagofItem(string itemID)
    {
        List<string> tagList = new List<string>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM ItemTag WHERE itemID=@itemID");
            command.Parameters.AddWithValue("@itemID", itemID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ItemTag itemTag = new ItemTag();

                readAItemTag(ref itemTag, ref reader);

                tagList.Add(itemTag.TagName);
            }

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return tagList;
    }

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced ItemTags object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding ItemTags
    private static void readAItemTag(ref ItemTag itemTag, ref SqlDataReader reader)
    {
        itemTag.TagName = reader["tagName"].ToString();
        itemTag.Item = ItemDB.getItembyID(reader["itemID"].ToString());
    }

}