using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ScheduleDB
/// </summary>
public class ScheduleDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static Schedule getSchedulebyID(string schedID)
    {
        Schedule sched = new Schedule();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Schedule WHERE scheduleID = @schedID");
            command.Parameters.AddWithValue("@schedID", schedID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
                        
            if (reader.Read())
                readASchedule(ref sched, ref reader);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return sched;
    }

    public static List<Schedule> getSchedulebyItem(string itemID)
    {
        List<Schedule> schedList = new List<Schedule>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Schedule WHERE itemID = @itemID");
            command.Parameters.AddWithValue("@itemID", itemID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Schedule sched = new Schedule();
            while (reader.Read())
            {
                readASchedule(ref sched, ref reader);

                schedList.Add(sched);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return schedList;
    }

    public static int addSchedule(Schedule sched)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO Schedule (availability, startDate, endDate, itemID) VALUES (@availability, @startDate, @endDate, @itemID)");
            command.Parameters.AddWithValue("@availability", sched.Availability);
            command.Parameters.AddWithValue("@startDate", sched.StartDate);
            command.Parameters.AddWithValue("@endDate", sched.EndDate);
            command.Parameters.AddWithValue("@itemID", sched.Item.ItemID);

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
        return 0;
    }

    private static void readASchedule(ref Schedule sched, ref SqlDataReader reader)
    {
        sched.ScheduleID = reader["scheduleID"].ToString();
        sched.Availability = reader["availability"].ToString();
        sched.StartDate = Convert.ToDateTime(reader["startDate"]);
        sched.EndDate = Convert.ToDateTime(reader["endDate"]);

        sched.Item = ItemDB.getItembyID(reader["itemID"].ToString());
    }
}