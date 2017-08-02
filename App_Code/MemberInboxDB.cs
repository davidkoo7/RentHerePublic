using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MemberInboxDB
/// </summary>
public class MemberInboxDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all MemberInbox from the database
    public static List<MemberInbox> getAllMemberInbox()
    {
        List<MemberInbox> memberInboxList = new List<MemberInbox>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from MemberInbox");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MemberInbox memberInbox = new MemberInbox();
                readAMsg(ref memberInbox, ref reader);

                memberInboxList.Add(memberInbox);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return memberInboxList;
    }

    public static bool isInboxPresentForMember(string memberInboxID, string memberID)
    {
        bool isPresent = false;
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MemberInbox MI, Item I WHERE MI.itemID=I.itemID and memberInboxID=@memberInboxID and (senderID=@senderID or I.renterID=@renterID)");
            command.Parameters.AddWithValue("@memberInboxID", memberInboxID);
            command.Parameters.AddWithValue("@senderID", memberID);
            command.Parameters.AddWithValue("@renterID", memberID);
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

    // method to get all MemberInbox by member, takes in parameter of type Member
    public static List<MemberInbox> getAllMemberInboxByID(Member sender)
    {
        List<MemberInbox> memberInboxList = new List<MemberInbox>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MemberInbox M, Item i WHERE M.itemID = i.itemID and (M.senderID = @sender OR i.itemID IN ( SELECT itemID FROM Item WHERE renterID = @sender ))");
            command.Parameters.AddWithValue("@sender", sender.MemberID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MemberInbox memberInbox = new MemberInbox();
                readAMsg(ref memberInbox, ref reader);

                memberInboxList.Add(memberInbox);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return memberInboxList;
    }

    // method to get MemberInbox by memberInboxID from the database
    public static MemberInbox getMemberInboxID(string memberInboxID)
    {
        MemberInbox mem = new MemberInbox();
        try
        {
            SqlCommand command = new SqlCommand("Select * from MemberInbox WHERE memberInboxID = @memberInboxID");
            command.Parameters.AddWithValue("@memberInboxID", memberInboxID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                readAMsg(ref mem, ref reader);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return mem;
    }

    public static MemberInbox searchMemberInbox(string senderID, string itemID)
    {
        MemberInbox memInbox = new MemberInbox();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MemberInbox Where senderID= @senderID AND itemID=@itemID");
            command.Parameters.AddWithValue("@senderID", senderID);
            command.Parameters.AddWithValue("@itemID", itemID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAMsg(ref memInbox, ref reader);
            else
                memInbox = new MemberInbox(-1, new DateTime(), new Member(), new Item());
            
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return memInbox;
    }

    public static MemberInbox getMemberInboxBetweenSenderAndItemOWner(string senderID, string itemID)
    {
        MemberInbox mem = new MemberInbox();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MemberInbox Where SenderID=@senderID' AND itemID=@itemID");
            command.Parameters.AddWithValue("@senderID", senderID);
            command.Parameters.AddWithValue("@itemID", itemID);
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                readAMsg(ref mem, ref reader);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return mem;
    }

    public static int AddMsgMember(MemberInbox msgDis)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO MemberInbox (date, senderID, itemID) values (@date, @senderID, @itemID)");
            command.Parameters.AddWithValue("@date", msgDis.Date);
            command.Parameters.AddWithValue("@senderID", msgDis.Sender.MemberID);
            command.Parameters.AddWithValue("@itemID", msgDis.Item.ItemID);

            command.Connection = connection;
            connection.Open();


            if (command.ExecuteNonQuery() > 0)
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

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced MemberInbox object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding MemberInbox
    private static void readAMsg(ref MemberInbox msg, ref SqlDataReader reader)
    {
        msg.MemberInboxID = Convert.ToInt32(reader["memberInboxID"]);
        msg.Date = Convert.ToDateTime(reader["date"]);
        msg.Sender = MemberDB.getMemberbyID(reader["senderID"].ToString());
        msg.Item = ItemDB.getItembyID(reader["itemID"].ToString());
    }
}