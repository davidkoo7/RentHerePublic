using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for SupportTicketDB
/// </summary>
public class SupportTicketDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

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
                t.TicketID = reader["ticketID"].ToString();
                t.Title = reader["title"].ToString();
                t.Description = reader["description"].ToString();
                t.Date = Convert.ToDateTime(reader["Date"]);
                t.Status = reader["status"].ToString();
                t.Urgency = reader["urgency"].ToString();

                t.Member = MemberDB.getMemberbyID(reader["memberID"].ToString());
                
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
                t.TicketID = reader["ticketID"].ToString();
                t.Title = reader["title"].ToString();
                t.Description = reader["description"].ToString();
                t.Date = Convert.ToDateTime(reader["Date"]);
                t.Status = reader["status"].ToString();
                t.Urgency = reader["urgency"].ToString();

                t.Member = MemberDB.getMemberbyID(reader["memberID"].ToString());
                
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
                t.TicketID = reader["ticketID"].ToString();
                t.Title = reader["title"].ToString();
                t.Description = reader["description"].ToString();
                t.Date = Convert.ToDateTime(reader["Date"]);
                t.Status = reader["status"].ToString();
                t.Urgency = reader["urgency"].ToString();

                t.Member = MemberDB.getMemberbyID(reader["memberID"].ToString());
                
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
                t.TicketID = reader["ticketID"].ToString();
                t.Title = reader["title"].ToString();
                t.Description = reader["description"].ToString();
                t.Date = Convert.ToDateTime(reader["Date"]);
                t.Status = reader["status"].ToString();
                t.Urgency = reader["urgency"].ToString();

                t.Member = MemberDB.getMemberbyID(reader["memberID"].ToString());
                
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