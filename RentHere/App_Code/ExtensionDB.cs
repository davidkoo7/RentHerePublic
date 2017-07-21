using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ExtensionDB
/// </summary>
public class ExtensionDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

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
                ext = new Extension(null, null, new DateTime(), new DateTime(), null, null, 0, new Payment(), new Rental());
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ext;
    }

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
                ext = new Extension(null, null, new DateTime(), new DateTime(), null, null, 0, new Payment(), new Rental());
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ext;
    }

    public static int addExtension(Extension extension)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO Extension (extensionID, newReturnLocation, newReturnTime, newEndDate, unit, status, extensionRentalFee, paymentID, rentalID) values (@extensionID, @newReturnLocation, @newReturnTime, @newEndDate, @unit, @status, @extensionRentalFee, @paymentID, @rentalID)");
            command.Parameters.AddWithValue("@extensionID", extension.ExtensionID);             command.Parameters.AddWithValue("@newReturnLocation", extension.NewReturnLocation);
            command.Parameters.AddWithValue("@newReturnTime", extension.NewReturnTime);              command.Parameters.AddWithValue("@newEndDate", extension.NewEndDate);
            command.Parameters.AddWithValue("@unit", extension.Unit);                           command.Parameters.AddWithValue("@status", extension.Status);
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

    private static void readAnExtension(ref Extension extent, ref SqlDataReader reader)
    {
        extent.ExtensionID = reader["extentionID"].ToString();
        extent.NewReturnLocation = reader["newReturnLocation"].ToString();
        extent.NewReturnTime = Convert.ToDateTime(reader["newReturnTime"]);
        extent.NewEndDate = Convert.ToDateTime(reader["newEndDate"]);
        extent.Unit = Convert.ToString(reader["unit"]);
        extent.Status = Convert.ToString(reader["status"]);
        extent.ExtensionRentalFee = Convert.ToDecimal(reader["extensionRentalFee"]);
        extent.Payment = PaymentDB.getPaymentbyID(reader["paymentID"].ToString());
        extent.Rental = RentalDB.getRentalbyID(reader["rentalID"].ToString());
    }
}