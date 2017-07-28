using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

public class MemberMessageDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get MemberMessage by memberInboxID from the database
    public static List<MemberMessage> getMsgforMember(string memberInboxID)
    {
        List<MemberMessage> msgDisList = new List<MemberMessage>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MemberMessage WHERE memberInboxID = @memberInboxID");
            command.Parameters.AddWithValue("@memberInboxID", memberInboxID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MemberMessage msgDis = new MemberMessage();

                msgDis.Date = Convert.ToDateTime(reader["date"]);
                msgDis.Reply = reader["reply"].ToString();

                if (reader["memberInboxID"] != DBNull.Value)
                    msgDis.MemberInbox = MemberInboxDB.getMemberInboxID(reader["memberInboxID"].ToString());
                else
                    msgDis.MemberInbox = new MemberInbox(0, new DateTime(), new Member(), new Item());

                if (reader["senderID"] != DBNull.Value)
                    msgDis.Sender = MemberDB.getMemberbyID(reader["senderID"].ToString());
                else
                    msgDis.Sender = new Member(null, null, null, 0, null, null, 0, null, null, new DateTime(), new DateTime(), null, new DateTime(), null, null);

                msgDisList.Add(msgDis);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return msgDisList;
    }

    // method to get MemberMessage by Member from the database
    public static List<MemberMessage> getMessageDetailsforMember(Member sender, Member receiver, Item item)
    {
        List<MemberMessage> messageList = new List<MemberMessage>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MemberMessage WHERE (senderID = @senderID AND itemID = @itemID AND receiverID = @receiverID) OR (senderID = @receiverID AND receiverID = @senderID AND itemID = @itemID) ");
            command.Parameters.AddWithValue("@senderID", sender.MemberID);
            command.Parameters.AddWithValue("@receiverID", receiver.MemberID);
            command.Parameters.AddWithValue("@itemID", item.ItemID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MemberMessage msg = new MemberMessage();
                readAMsg(ref msg, ref reader);

                messageList.Add(msg);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return messageList;
    }

    // method to add MemberMessage into the database, takes in parameters of type MemberMessage 
    public static int AddMsgMember(MemberMessage msgDis)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO MemberMessage (memberInboxID, date, reply, senderID) values (@memberInboxID, @date, @reply, @senderID)");
            command.Parameters.AddWithValue("@memberInboxID", msgDis.MemberInbox.MemberInboxID);
            command.Parameters.AddWithValue("@date", msgDis.Date);
            command.Parameters.AddWithValue("@reply", msgDis.Reply);
            command.Parameters.AddWithValue("@senderID", msgDis.Sender.MemberID);

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

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced MemberMessage object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding MemberMessage
    private static void readAMsg(ref MemberMessage msg, ref SqlDataReader reader)
    {
        msg.MemberInbox = MemberInboxDB.getMemberInboxID(reader["memberInboxID"].ToString());
        msg.Reply = Convert.ToString(reader["reply"]);
        msg.Date = Convert.ToDateTime(reader["date"]);
        msg.Sender = MemberDB.getMemberbyID(reader["senderID"].ToString());
    }
}