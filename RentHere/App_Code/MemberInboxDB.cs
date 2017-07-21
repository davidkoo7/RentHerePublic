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
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

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
                return 1;
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    private static void readAMsg(ref MemberInbox msg, ref SqlDataReader reader)
    {
        msg.MemberInboxID = Convert.ToInt32(reader["memberInboxID"]);
        msg.Date = Convert.ToDateTime(reader["date"]);
        msg.Sender = MemberDB.getMemberbyID(reader["senderID"].ToString());
        msg.Item = ItemDB.getItembyID(reader["itemID"].ToString());
    }


}