using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for RentalDB
/// </summary>
public class RentalDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

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

    public static List<Rental> getRentalofItem(string itemID, string status)
    {
        List<Rental> rentList = new List<Rental>();

        try
        {
            string sqlcommand = "SELECT * FROM Rental WHERE itemID = @itemID ";

            if (status != null)
                sqlcommand += " and status=@status";

            SqlCommand command = new SqlCommand(sqlcommand);

            command.Parameters.AddWithValue("@itemID", itemID);

            if (status != null)
                command.Parameters.AddWithValue("@status", status);

            command.Connection = connection;

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
        } finally
        {
            connection.Close();
        }
        return -1;
    }

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

        rent.PaymentID = PaymentDB.getPaymentbyID(reader["paymentID"].ToString());
    }
}