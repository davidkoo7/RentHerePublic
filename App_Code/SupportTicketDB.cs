using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class SupportTicketDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all support tickets with pending status from the database
    public static List<SupportTicket> getPendingSupportTicket()
    {
        List<SupportTicket> ticketList = new List<SupportTicket>();
        try
        {
            SqlCommand command = new SqlCommand("Select ticketID, title, description, date, st.status, urgency, m.memberID, m.name, m.address, m.postalCode,m.password, m.email, m.phoneNumber, m.identificationNumber, m.identificationPicture, m.dateJoined , m.dateOfBirth, m.dateVerified, m.gender, m.status as MState, m.profilePic from SupportTicket st, Member m where st.status = 'Pending' and st.memberID = m.memberID");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SupportTicket t = new SupportTicket();
                readASupportTicket(ref t, ref reader);
                
                ticketList.Add(t);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ticketList;
    }

    public static bool isTicketforMemberPresent(string ticketID, string memberID)
    {
        bool isPresent = false;
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM SupportTicket WHERE ticketID=@ticketID and memberID=@memberID");
            command.Parameters.AddWithValue("@ticketID", ticketID);
            command.Parameters.AddWithValue("@memberID", memberID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                isPresent = true;

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return isPresent;
    }

    // method to get all support tickets with answered status from the database
    public static List<SupportTicket> getAnsweredSupportTicket()
    {
        List<SupportTicket> ticketList = new List<SupportTicket>();
        try
        {
            SqlCommand command = new SqlCommand("Select ticketID, title, description, date, st.status, urgency, m.memberID, m.name, m.address, m.postalCode,m.password, m.email, m.phoneNumber, m.identificationNumber, m.identificationPicture, m.dateJoined , m.dateOfBirth, m.dateVerified, m.gender, m.status as MState, m.profilePic from SupportTicket st, Member m where st.status = 'Answered' and st.memberID = m.memberID");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SupportTicket t = new SupportTicket();
                readASupportTicket(ref t, ref reader);
                
                ticketList.Add(t);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ticketList;
    }

    // method to get all support tickets with closed status from the database
    public static List<SupportTicket> getClosedSupportTicket()
    {
        List<SupportTicket> ticketList = new List<SupportTicket>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from SupportTicket where status = 'Closed' ");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SupportTicket t = new SupportTicket();
                readASupportTicket(ref t, ref reader);
                
                ticketList.Add(t);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ticketList;
    }

    // method to change urgency of support ticket in the database, takes in parameter of type SupportTicket and string
    public static int updateUrgency(SupportTicket s, string urgency)
    {
        try
        {
            SqlCommand command = new SqlCommand("update SupportTicket set urgency = @urgency where ticketID = @ticketID");
            command.Parameters.AddWithValue("@urgency", urgency);
            command.Parameters.AddWithValue("@ticketID", s.TicketID);
            command.Connection = connection;
            connection.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }

    // method to change status of support ticket in the database, takes in parameter of type SupportTicket and string
    public static int updateStatus(SupportTicket s, string status)
    {
        try
        {
            SqlCommand command = new SqlCommand("update SupportTicket set status = @status where ticketID = @ticketID");
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@ticketID", s.TicketID);
            command.Connection = connection;
            connection.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }

    // method to get support ticket by memberID from the data based
    public static List<SupportTicket> getTicketByUser(string memberID)
    {
        List<SupportTicket> ticketList = new List<SupportTicket>();
        try
        {
            SqlCommand command = new SqlCommand("select * from SupportTicket where memberID = @memberID");
            //Select ticketID, title, description, date, st.status, urgency, m.memberID, m.name, m.address, m.postalCode,m.password, m.email, m.phoneNumber, m.identificationNumber, m.identificationPicture, m.dateJoined , m.dateOfBirth, m.dateVerified, m.gender, m.status as MState, m.profilePic from SupportTicket st, Member m where st.memberID = m.memberID and st.memberID = @memberID");
            command.Parameters.AddWithValue("@memberID", memberID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SupportTicket t = new SupportTicket();

                readASupportTicket(ref t, ref reader);
                
                ticketList.Add(t);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return ticketList;
    }

    // method to add support ticket into database
    public static int insertTicket(string title, string description, DateTime date, string status, string urgency, string memberID)
    {
        try
        {
            SqlCommand command = new SqlCommand("insert into SupportTicket(title, description, date, status, urgency, memberID) values (@title, @description, @date, @status, @urgency, @memberID)");
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@urgency", urgency);
            command.Parameters.AddWithValue("@memberID", memberID);
            command.Connection = connection;
            connection.Open();
            if (command.ExecuteNonQuery() > 0 )
            {
                command.CommandText = "Select @@identity";
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    // method to get support ticket by ticketID from database
    public static SupportTicket getSupportTicketbyID(string ticketID)
    {
        SupportTicket sT = new SupportTicket();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM SupportTicket WHERE ticketID = @ticketID");
            command.Parameters.AddWithValue("@ticketID", ticketID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readASupportTicket(ref sT, ref reader);
            else
                sT = new SupportTicket(null, null, null, new DateTime(), null, null, new Member());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return sT;
    }

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced SupportTicket object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding SupportTicket
    private static void readASupportTicket(ref SupportTicket sT, ref SqlDataReader reader)
    {
        sT.Date = Convert.ToDateTime(reader["date"]);
        sT.Description = reader["description"].ToString();
        sT.Member = MemberDB.getMemberbyID(reader["memberID"].ToString());
        sT.Status = reader["status"].ToString();
        sT.Urgency = reader["urgency"].ToString();
        sT.Title = reader["title"].ToString();
        sT.TicketID = reader["ticketID"].ToString();
    }
}