using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class ExtensionDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get extension by extensionID from the database
    public static Extension getExtensionbyID(string extID)
    {
        Extension ext = new Extension();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Extension WHERE extensionID = @extID");
            command.Parameters.AddWithValue("@extID", extID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAnExtension(ref ext, ref reader);
            else
                ext = new Extension(null, null, new TimeSpan(), new DateTime(), null, null, 0, new Payment(), new Rental());
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ext;
    }

    // method to get extension by rentalID from the database
    public static Extension getExtensionbyRental(string rentalID)
    {
        Extension ext = new Extension();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Extension WHERE rentalID = @rentalID");
            command.Parameters.AddWithValue("@rentalID", rentalID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAnExtension(ref ext, ref reader);
            else
                ext = new Extension(null, null, new TimeSpan(), new DateTime(), null, null, 0, new Payment(), new Rental());
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ext;
    }

    // method to add extension into database, takes in parameter of type Extension
    public static int addExtension(Extension extension)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO Extension (extensionID, newReturnLocation, newReturnTime, newEndDate, unit, status, extensionRentalFee, paymentID, rentalID) values (@extensionID, @newReturnLocation, @newReturnTime, @newEndDate, @unit, @status, @extensionRentalFee, @paymentID, @rentalID)");
            command.Parameters.AddWithValue("@extensionID", extension.ExtensionID); command.Parameters.AddWithValue("@newReturnLocation", extension.NewReturnLocation);
            command.Parameters.AddWithValue("@newReturnTime", extension.NewReturnTime); command.Parameters.AddWithValue("@newEndDate", extension.NewEndDate);
            command.Parameters.AddWithValue("@unit", extension.Unit); command.Parameters.AddWithValue("@status", extension.Status);
            command.Parameters.AddWithValue("@extensionRentalFee", extension.ExtensionRentalFee); command.Parameters.AddWithValue("@paymentID", extension.Payment.PaymentID);
            command.Parameters.AddWithValue("@rentalID", extension.Rental.RentalID);

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

    // method to get last extension by item from the database
    public static Extension getLastExtensionofItem(string itemID, string status)
    {
        Extension ext = new Extension();
        try
        {
            string commandString = "SELECT * FROM Rental R, Extension E WHERE R.rentalID = E.rentalID and E.extensionID in ( " +
         "SELECT TOP 1 E1.extensionID FROM Extension E1 WHERE E1.rentalID = R.rentalID and E1.status <> 'Not Granted' " +
         "and E1.status <> 'Pending' ORDER BY E1.newEndDate desc)";

            if (status != null)
                commandString += " AND R.status=@status";

            commandString += " AND R.itemID = @itemID";

            SqlCommand command = new SqlCommand(commandString);

            if (status != null)
                command.Parameters.AddWithValue("@status", status);

            command.Parameters.AddWithValue("@itemID", itemID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAnExtension(ref ext, ref reader);
            else
                ext = new Extension(null, null, new TimeSpan(), new DateTime(), null, null, 0, new Payment(), new Rental());
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ext;
    }

    // method to get last extension of item by rental from the database
    public static Extension getLastExtensionofRental(string rentalID)
    {
        Extension ext = new Extension();
        try
        {
            string commandString = "SELECT * FROM Rental R, Extension E WHERE R.rentalID = E.rentalID and E.extensionID in ( " +
         "SELECT TOP 1 E1.extensionID FROM Extension E1 WHERE E1.rentalID = R.rentalID and E1.status <> 'Not Granted' " +
         "and E1.status <> 'Pending' ORDER BY E1.newEndDate desc) AND R.rentalID = @rentalID";
            SqlCommand command = new SqlCommand(commandString);

            command.Parameters.AddWithValue("@rentalID", rentalID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAnExtension(ref ext, ref reader);
            else
                ext = new Extension(null, null, new TimeSpan(), new DateTime(), null, null, 0, new Payment(), new Rental());
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ext;
    }

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced Extension object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding Extension
    private static void readAnExtension(ref Extension extent, ref SqlDataReader reader)
    {
        extent.ExtensionID = reader["extensionID"].ToString();
        extent.NewReturnLocation = reader["newReturnLocation"].ToString();
        extent.NewReturnTime = (TimeSpan)reader["newReturnTime"];
        extent.NewEndDate = Convert.ToDateTime(reader["newEndDate"]);
        extent.Unit = Convert.ToString(reader["unit"]);
        extent.Status = Convert.ToString(reader["status"]);
        extent.ExtensionRentalFee = Convert.ToDecimal(reader["extensionRentalFee"]);
        extent.Payment = PaymentDB.getPaymentbyID(reader["paymentID"].ToString());
        extent.Rental = RentalDB.getRentalbyID(reader["rentalID"].ToString());
    }
}