using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


public class PaymentDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    public static List<PaymentPay> getAllPayment()
    {
        List<PaymentPay> paymentList = new List<PaymentPay>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Payment");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PaymentPay p = new PaymentPay();
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

    public static PaymentPay getPaymentbyID(string payID)
    {
        PaymentPay pay = new PaymentPay();
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
                pay = new PaymentPay(null, null);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return pay;
    }

    public static int addPayment(PaymentPay pay)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO Payment (stripeRefNum) values (@stripeRefNum)");
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

    private static void readAPayment (ref PaymentPay pay, ref SqlDataReader reader)
    {
        pay.PaymentID = reader["paymentID"].ToString();
        pay.StripeRefNum = reader["stripeRefNum"].ToString();
    }
}