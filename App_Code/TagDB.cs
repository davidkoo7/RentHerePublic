using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class TagDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to check if tag exists in database
    public static bool isTagPresent(string tagName)
    {
        bool presence = false;
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Tag WHERE tagName = @tagName");
            command.Parameters.AddWithValue("@tagName", tagName);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                presence = true;

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return presence;
    }

    // method to get number of times that has a specific tagName in the database
    public static int getNoOfTagUsed(string tagName)
    {
        int noOfTagPresent = 0;
        try
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) AS NoofTagUsed FROM ItemTag WHERE tagName = @tagName");
            command.Parameters.AddWithValue("@tagName", tagName);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                noOfTagPresent = Convert.ToInt32(reader["NoofTagUsed"]);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return noOfTagPresent;
    }

    // method to insert new tag into the datase
    public static int addTag(string tagName)
    {
        try
        {
            string commandString = "INSERT INTO Tag (tagName) VALUES (@tagName)";
            SqlCommand command = new SqlCommand(commandString);
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

    //private static void readATag(ref Tag tag, ref SqlDataReader reader)
    //{
    //    tag.TagName = reader["tagName"].ToString();
    //}

}