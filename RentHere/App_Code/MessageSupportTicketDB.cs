using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for MessageSupportTicketDB
/// </summary>
public class MessageSupportTicketDB
{
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    public static List<MessageSupportTicket> getMessage(SupportTicket t)
    {
        List<MessageSupportTicket> msgList = new List<MessageSupportTicket>();
        try
        {
            SqlCommand command = new SqlCommand("select * from MessageSupportTicket where ticketID = @ticketID ");
            command.Parameters.AddWithValue("@ticketID", t.TicketID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MessageSupportTicket tix = new MessageSupportTicket();

                if (reader.IsDBNull(2)) //member null
                {
                    tix.Date = Convert.ToDateTime(reader["date"]);
                    tix.Reply = reader["reply"].ToString();
                    tix.Ticket = t;
                    tix.Member = new Member();
                    tix.Staff = StaffDB.getStaffbyID(reader["staffID"].ToString());
                    msgList.Add(tix);
                }
                if (reader.IsDBNull(3)) //stuff null
                {
                    tix.Date = Convert.ToDateTime(reader["date"]);
                    tix.Reply = reader["reply"].ToString();
                    tix.Ticket = t;
                    tix.Member = MemberDB.getMemberbyID(reader["memberID"].ToString());
                    tix.Staff = new Staff();
                    msgList.Add(tix);
                }
            }
        }

        finally
        {
            connection.Close();
        }
        return msgList;
    }

    public static List<TicketMsg> getMessage1(SupportTicket t)
    {
        List<TicketMsg> msgList = new List<TicketMsg>();
        try
        {
            SqlCommand command = new SqlCommand("select * from MessageSupportTicket where ticketID = @ticketID ");
            command.Parameters.AddWithValue("@ticketID", t.TicketID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                TicketMsg tix = new TicketMsg();
                if (reader.IsDBNull(2)) //member null
                {
                    tix.Date = Convert.ToDateTime(reader["date"]);
                    tix.Msg = reader["reply"].ToString();
                    tix.Ticket = t;
                    Staff s = StaffDB.getStaffbyID(reader["staffID"].ToString());
                    tix.Person = s.Name;
                    msgList.Add(tix);
                }
                if (reader.IsDBNull(3)) //stuff null
                {
                    tix.Date = Convert.ToDateTime(reader["date"]);
                    tix.Msg = reader["reply"].ToString();
                    tix.Ticket = t;
                    Member m = MemberDB.getMemberbyID(reader["memberID"].ToString());
                    tix.Person = m.Name;
                    msgList.Add(tix);
                }
            }
            if (!reader.HasRows)
            {
                TicketMsg tix = new TicketMsg();
                tix.Date = Convert.ToDateTime("1/1/0001 00:00:00");
                tix.Msg = "No Messages Yet";
                tix.Person = "System";
                tix.Ticket = t;
                msgList.Add(tix);
            }

            //reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return msgList;
    }

    public static int insertAdminMessage(string message, DateTime date, SupportTicket ticket, string person)
    {
        try
        {
            SqlCommand command = new SqlCommand("insert into MessageSupportTicket(date, reply, staffID, ticketID) values (@date, @reply, @staffID, @ticket)");
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@reply", message);
            command.Parameters.AddWithValue("@staffID", person);
            command.Parameters.AddWithValue("@ticket", ticket.TicketID);
            command.Connection = connection;
            connection.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }

    public static int insertMemberMessage(string message, DateTime date, SupportTicket ticket, string person)
    {
        try
        {
            SqlCommand command = new SqlCommand("insert into MessageSupportTicket(date, reply, memberID, ticketID) values (@date, @reply, @memberID, @ticket)");
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@reply", message);
            command.Parameters.AddWithValue("@memberID", person);
            command.Parameters.AddWithValue("@ticket", ticket.TicketID);
            command.Connection = connection;
            connection.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }
}