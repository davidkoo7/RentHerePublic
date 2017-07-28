using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class LocationDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all locations from the database
    public static List<Location> getAllLocation()
    {
        List<Location> locationList = new List<Location>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Location");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Location loc = new Location();
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

    // method to get location by locationID from the database
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

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced Location object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding Location
    private static void readALocation(ref Location loc, ref SqlDataReader reader)
    {
        loc.Name = reader["name"].ToString();
        loc.Description = reader["description"].ToString();
    }
}