using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class StaffDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
    public static List<Staff> getAllStaff()
    {
        List<Staff> staffList = new List<Staff>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Staff");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Staff staff = new Staff();
                readAStaff(ref staff, ref reader);

                staffList.Add(staff);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return staffList;
    }

    public static bool isPermittedLogin(string email, string password)
    {
        bool permittedLogin = false;
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Staff WHERE email = @email and password = @password");
            command.Connection = connection;
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                permittedLogin = true;

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return permittedLogin;
    }

    public static Staff getStaffbyID(string staffid)
    {
        Staff staff = new Staff();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Staff WHERE staffID = @staffID");
            command.Parameters.AddWithValue("@staffID", staffid);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                readAStaff(ref staff, ref reader);
            else
                staff = new Staff(null, null, null, null, 0, null, new DateTime());            
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return staff;
    }

    public static Staff getStaffbyEmail(string email)
    {
        Staff s = new Staff();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Staff WHERE email = @email");
            command.Connection = connection;
            command.Parameters.AddWithValue("@email", email);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                readAStaff(ref s, ref reader);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return s;
    }

    private static void readAStaff(ref Staff staff, ref SqlDataReader reader)
    {
        staff.StaffID = reader["staffID"].ToString();
        staff.Password = reader["password"].ToString();
        staff.Name = reader["name"].ToString();
        staff.Email = reader["email"].ToString();
        staff.PhoneNumber = Convert.ToInt32(reader["phoneNumber"]);
        staff.Gender = reader["gender"].ToString();
        staff.DateOfBirth = Convert.ToDateTime(reader["dateOfBirth"]);
    }
}