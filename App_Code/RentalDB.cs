using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class RentalDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all rentals by member from the database, takes in parameter of type Member
    public static List<Rental> getRentalforMember(Member member)
    {
        List<Rental> rentalList = new List<Rental>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rental R, Item I WHERE R.itemID = I.itemID and (renteeID = @renteeID or renterID = @renterID)");
            command.Parameters.AddWithValue("@renteeID", member.MemberID);
            command.Parameters.AddWithValue("@renterID", member.MemberID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Rental rent = new Rental();
                readARental(ref rent, ref reader);

                rentalList.Add(rent);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentalList;
    }

    // method to get all rentals by item from the database
    public static List<Rental> getRentalofItem(string itemID, string status)
    {
        List<Rental> rentList = new List<Rental>();

        try
        {
            string sqlcommand = "SELECT * FROM Rental WHERE itemID = @itemID ";

            if (status != null)
                sqlcommand += " and status=@status ";

            sqlcommand += "ORDER BY startDate desc" ;

            SqlCommand command = new SqlCommand(sqlcommand);

            command.Parameters.AddWithValue("@itemID", itemID);

            if (status != null)
                command.Parameters.AddWithValue("@status", status);

            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Rental rent = new Rental();
                readARental(ref rent, ref reader);
                rentList.Add(rent);
            }

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentList;
    }

    // method to insert rental into the database, takes in parameter of type Rental
    public static int addRental(Rental rent)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO Rental (pickUpLocation, pickUpTime, returnLocation, returnTime, rentalFee, unit, deposit, dateCreated, startDate, endDate, status, paymentReleaseCode, depositRetrievalCode, itemID, paymentID, renteeID)" +
               "VALUES (@pickUpLocation, @pickUpTime, @returnLocation, @returnTime, @rentalFee, @unit, @deposit, @dateCreated, @startDate, @endDate, @status, @paymentReleaseCode, @depositRetrievalCode, @itemID, @paymentID, @renteeID)");
            command.Parameters.AddWithValue("@pickUpLocation", rent.PickUpLocation);
            command.Parameters.AddWithValue("@pickUpTime", rent.PickUpTime);

            if (rent.ReturnLocation != null)
                command.Parameters.AddWithValue("@returnLocation", rent.ReturnLocation);
            else
                command.Parameters.AddWithValue("@returnLocation", DBNull.Value);

            if (rent.ReturnTime != null)
                command.Parameters.AddWithValue("@returnTime", rent.ReturnTime);
            else
                command.Parameters.AddWithValue("@returnTime", DBNull.Value);

            command.Parameters.AddWithValue("@rentalFee", rent.RentalFee);
            command.Parameters.AddWithValue("@unit", rent.Unit);
            command.Parameters.AddWithValue("@deposit", rent.Deposit);
            command.Parameters.AddWithValue("@dateCreated", rent.DateCreated);
            command.Parameters.AddWithValue("@startDate", rent.StartDate);
            command.Parameters.AddWithValue("@endDate", rent.EndDate);
            command.Parameters.AddWithValue("@status", rent.Status);
            command.Parameters.AddWithValue("@paymentReleaseCode", rent.PaymentReleaseCode);
            command.Parameters.AddWithValue("@depositRetrievalCode", rent.DepositRetrievalCode);
            command.Parameters.AddWithValue("@itemID", rent.Item.ItemID);
            command.Parameters.AddWithValue("@paymentID", rent.Payment.PaymentID);
            command.Parameters.AddWithValue("@renteeID", rent.Rentee.MemberID);
            command.Connection = connection;
            connection.Open();

            if(command.ExecuteNonQuery() > 0)
            {
                command.CommandText = "SELECT @@identity";
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    // method to get rentee from rental record from the database
    public static Member getRenteeforRental(string rentalID)
    {
        Member m = new Member();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rental WHERE rentalID = @rentalID");
            command.Parameters.AddWithValue("@rentalID", rentalID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                m = MemberDB.getMemberbyID(reader["renteeID"].ToString());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return m;
    }

    // method to get rental by rentalID from the database
    public static Rental getRentalbyID(string rentalID)
    {
        Rental rent = new Rental();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rental WHERE rentalID = @rentalID");
            command.Parameters.AddWithValue("@rentalID", rentalID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readARental(ref rent, ref reader);
            else
                rent = new Rental(null, null, new TimeSpan(), null, new TimeSpan(), 0, null, 0, new DateTime(), new DateTime(), new DateTime(), null, null, null, new Item(), new Payment(), new Member());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rent;
    }

    // method to change status of rental in the database
    public static int updateRentStatus(string rentalID, string status)
    {
        try
        {
            SqlCommand command = new SqlCommand("UPDATE Rental SET status=@status WHERE rentalID=@rentalID");
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@rentalID", rentalID);

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

    // method to get number of rentals where member is rentee from the database
    public static int getNoofRentalAsRentee(string memberID)
    {
        int rentNo = 0;
        try
        {
            SqlCommand command = new SqlCommand("SELECT count(*) as noOfRental FROM Rental WHERE renteeID=@memberID");
            command.Parameters.AddWithValue("@memberID", memberID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                rentNo = Convert.ToInt32(reader["noOfRental"]);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentNo;
    }

    // method to get number of rentals where member is renter from the database
    public static int getNoofRentalAsRenter(string memberID)
    {
        int rentNo = 0;
        try
        {
            SqlCommand command = new SqlCommand("SELECT count(*) as noOfRental FROM Rental R, Item I WHERE R.itemID=I.itemID and I.renterID=@memberID");
            command.Parameters.AddWithValue("@memberID", memberID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                rentNo = Convert.ToInt32(reader["noOfRental"]); 

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentNo;
    }

    // method to get rental that has exceeded the due date from the database
    public static List<Rental> getRentalsThatExceeds(DateTime dueDate)
    {
        List<Rental> rentList = new List<Rental>();
        try
        {
            //and returnTime<@time
            SqlCommand command = new SqlCommand("SELECT * FROM Rental WHERE rentalID not in " +
                "( SELECT R.rentalID FROM Rental R, Extension E WHERE R.RentalID = E.RentalID GROUP BY R.rentalID, " +
                "E.status HAVING E.status <> 'Not Granted') and endDate = @date and E.returnTime < @time and status='On-going'");

            command.Parameters.AddWithValue("@date", String.Format("{0:yyyy/MM/dd}", dueDate.Date));
            command.Parameters.AddWithValue("@time", dueDate.TimeOfDay);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Rental rent = new Rental();
                readARental(ref rent, ref reader);
                rentList.Add(rent);
            }

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentList;
    }

    // method to get rental that has extension that has exceeded the due date from the database
    public static List<Rental> getRentalsWithExtensionThatExceeds(DateTime dueDate)
    {
        List<Rental> rentList = new List<Rental>();
        try
        {

            SqlCommand command = new SqlCommand("SELECT * FROM Rental R, Extension E " +
                "WHERE R.rentalID = E.rentalID and E.extensionID in ( SELECT TOP 1 E1.extensionID FROM Extension E1 " +
                "WHERE E1.rentalID = R.rentalID and E1.status<>'Not Granted' ORDER BY E1.newEndDate desc) " +
                " and E.newEndDate = @date and E.newReturnTime < @time  and R.status='On-going'");

            command.Parameters.AddWithValue("@date", dueDate.Date);
            command.Parameters.AddWithValue("@time", dueDate.TimeOfDay);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Rental rent = new Rental();
                readARental(ref rent, ref reader);

                rentList.Add(rent);
            }

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return rentList;
    }

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced Rental object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding Rental
    private static void readARental(ref Rental rent, ref SqlDataReader reader)
    {
        rent.RentalID = Convert.ToString(reader["rentalID"]);
        rent.PickUpLocation = Convert.ToString(reader["pickUpLocation"]);
        rent.PickUpTime = (TimeSpan)reader["pickUpTime"];
        rent.RentalFee = Convert.ToDecimal(reader["rentalFee"]);
        rent.Unit = reader["unit"].ToString();
        rent.Deposit = Convert.ToDecimal(reader["deposit"]);
        rent.DateCreated = Convert.ToDateTime(reader["dateCreated"]);
        rent.StartDate = Convert.ToDateTime(reader["startDate"]);
        rent.EndDate = Convert.ToDateTime(reader["endDate"]);
        rent.Status = Convert.ToString(reader["status"]);
        rent.PaymentReleaseCode = Convert.ToString(reader["paymentReleaseCode"]);
        rent.DepositRetrievalCode = Convert.ToString(reader["depositRetrievalCode"]);

        if (reader["returnLocation"] != DBNull.Value)
            rent.ReturnLocation = reader["returnLocation"].ToString();
        else
            rent.ReturnLocation = "";

        if (reader["returnTime"] != DBNull.Value)
            rent.ReturnTime = (TimeSpan)reader["returnTime"];
        else
            rent.ReturnTime = new TimeSpan(0, 0, 0);

        rent.Rentee = MemberDB.getMemberbyID(reader["renteeID"].ToString());

        rent.Item = ItemDB.getItembyID(reader["itemID"].ToString());

        rent.Payment = PaymentDB.getPaymentbyID(reader["paymentID"].ToString());
    }
}