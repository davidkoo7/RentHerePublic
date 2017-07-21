using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class LocationDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    public static List<Location> getAllLocation()
    {
        List<Location> locationList = new List<Location>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Location");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Location loc = new Location();
            while (reader.Read())
            {
                readALocation(ref loc, ref reader);
                locationList.Add(loc);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return locationList;
    }

    public static Location getLocationbyID(string locName)
    {
        Location loc = new Location();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Location WHERE name = @name");
            command.Parameters.AddWithValue("@name", locName);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readALocation(ref loc, ref reader);
            else
                loc = new Location(null, null);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return loc;
    }

    private static void readALocation(ref Location loc, ref SqlDataReader reader)
    {
        loc.Name = reader["name"].ToString();
        loc.Description = reader["description"].ToString();
    }
}