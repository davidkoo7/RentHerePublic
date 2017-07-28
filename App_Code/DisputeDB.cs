using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class DisputeDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get dispute by rental from the database
    public static Dispute getDisputeforRental(string rentalID)
    {
        Dispute dis = new Dispute();

        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Dispute WHERE rentalID = @rentalID");
            command.Parameters.AddWithValue("@rentalID", rentalID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readADispute(ref dis, ref reader);
            else
            {
                dis = new Dispute(null, null, new DateTime(), null, new Member(), new Rental());
                return dis;
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return dis;
    }

    /// method to get dispute by ID from the database
    public static Dispute getDisputeybyID(string disputeID)
    {
        Dispute dis = new Dispute();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Dispute WHERE disputeID = @disputeID");
            command.Parameters.AddWithValue("@disputeID", disputeID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readADispute(ref dis, ref reader);
            else
                dis = new Dispute(null, null, new DateTime(), null, new Member(), new Rental());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return dis;
    }

    // method to add dispute into the database, takes in parameter of type Dispute
    public static int addDispute(Dispute dis)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO Dispute (reason, date, status, submittedBy, rentalID) values (@reason, @date, @status, @submittedBy, @rentalID)");
            command.Parameters.AddWithValue("@reason", dis.Reason);
            command.Parameters.AddWithValue("@date", dis.Date);
            command.Parameters.AddWithValue("@status", dis.Status);
            command.Parameters.AddWithValue("@submittedBy", dis.SubmittedBy.MemberID);
            command.Parameters.AddWithValue("@rentalID", dis.Rental.RentalID);

            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                //command.CommandText = "SELECT @@identity";
                //int disputeID = Convert.ToInt32(command.ExecuteScalar());

                return 1;
            }
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    // method to change dispute status to 'Resolved' in the database, takes in disputeID string as parameter
    public static int resolveDispute(string disputeID)
    {        
        try
        {
            SqlCommand command = new SqlCommand("UPDATE Dispute SET status=@status WHERE disputeID = @disputeID");
            command.Parameters.AddWithValue("@status", "Resolved");
            command.Parameters.AddWithValue("@disputeID", disputeID);

            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                //command.CommandText = "SELECT @@identity";
                //int disputeID = Convert.ToInt32(command.ExecuteScalar());

                return 1;
            }
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    // method to get all disputes based on status 
    public static List<Dispute> getAllDisputeforRentals(string condition)
    {
        List<Dispute> disList = new List<Dispute>();

        try
        {
            string query = "SELECT D.disputeID, D.reason, D.date, D.status, D.submittedBy, D.rentalID, R.status as Rstatus FROM Dispute D, Rental R WHERE D.rentalID = R.rentalID";

            if (condition == "PendingDispute")
                query += " AND D.status = 'Pending'";
            else if (condition == "ResolvedDispute")
                query += " AND D.status = 'Resolved'";

            SqlCommand command = new SqlCommand(query);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Dispute dis = new Dispute();

                readADispute(ref dis, ref reader);

                disList.Add(dis);
            }           

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return disList;
    }

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced Dispute object  
    // allows for easier editing of column names if needed, used only for methods with select statments regarding Dispute
    public static void readADispute(ref Dispute dis, ref SqlDataReader reader)
    {
        dis.DisputeID = reader["disputeID"].ToString();
        dis.Date = Convert.ToDateTime(reader["date"]);
        dis.Reason = reader["reason"].ToString();
        dis.Status = reader["status"].ToString();

        dis.SubmittedBy = MemberDB.getMemberbyID(reader["submittedBy"].ToString());

        dis.Rental = RentalDB.getRentalbyID(reader["rentalID"].ToString());
    }
}