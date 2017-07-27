using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


public class PaymentDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all payments from the database
    public static List<Payment> getAllPayment()
    {
        List<Payment> paymentList = new List<Payment>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Payment");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Payment p = new Payment();
                readAPayment(ref p, ref reader);

                paymentList.Add(p);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return paymentList;

    }

    // method to get payment by paymentID from the database
    public static Payment getPaymentbyID(string payID)
    {
        Payment pay = new Payment();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Payment WHERE paymentID = @paymentID");
            command.Parameters.AddWithValue("@paymentID", payID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                readAPayment(ref pay, ref reader);
            else
                pay = new Payment(null, null);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return pay;
    }

    // method to add payment into the database, takes in parameter of Payment type
    public static int addPayment(Payment pay)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO Payment (paymentID, stripeRefNum) values (@paymentID, @stripeRefNum)");
            command.Parameters.AddWithValue("@paymentID", pay.PaymentID);
            command.Parameters.AddWithValue("@stripeRefNum", pay.StripeRefNum);

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

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced Payment object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding Payment
    private static void readAPayment (ref Payment pay, ref SqlDataReader reader)
    {
        pay.PaymentID = reader["paymentID"].ToString();
        pay.StripeRefNum = reader["stripeRefNum"].ToString();
    }
}