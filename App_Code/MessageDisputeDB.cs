using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class MessageDisputeDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all MessagesDispute by disputeID from the database
    public static List<MessageDispute> getMsgforDispute(string disputeID)
    {
        List<MessageDispute> msgDisList = new List<MessageDispute>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MessageDispute WHERE disputeID = @disputeID");
            command.Parameters.AddWithValue("@disputeID", disputeID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MessageDispute msgDis = new MessageDispute();

                msgDis.Date = Convert.ToDateTime(reader["date"]);
                msgDis.Reply = reader["reply"].ToString();

                if (reader["memberID"] != DBNull.Value)
                    msgDis.Member = MemberDB.getMemberbyID(reader["memberID"].ToString());
                else
                    msgDis.Member = new Member(null, null, null, 0, null, null, 0, null, null, new DateTime(), new DateTime(), null, new DateTime(), null, null);

                if (reader["staffID"] != DBNull.Value)
                    msgDis.Staff = StaffDB.getStaffbyID(reader["staffID"].ToString());
                else
                    msgDis.Staff = new Staff(null, null, null, null, 0, null, new DateTime());

                msgDis.Dispute = DisputeDB.getDisputeybyID(reader["disputeID"].ToString());

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

    // method to add MessgaeDispute into the database, takes in parameter of type MessageDispute
    public static int addMsgDispute(MessageDispute msgDis)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO MessageDispute (date, reply, memberID, staffID, disputeID) values (@date, @reply, @memberID, @staffID, @disputeID)");
            command.Parameters.AddWithValue("@date", msgDis.Date);
            command.Parameters.AddWithValue("@reply", msgDis.Reply);

            if(msgDis.Member.MemberID != null)
                 command.Parameters.AddWithValue("@memberID", msgDis.Member.MemberID);
            else
                command.Parameters.AddWithValue("@memberID", DBNull.Value);

            if (msgDis.Staff.StaffID != null)
                command.Parameters.AddWithValue("@staffID", msgDis.Staff.StaffID);
            else
                command.Parameters.AddWithValue("@staffID", DBNull.Value);

            command.Parameters.AddWithValue("@disputeID", msgDis.Dispute.DisputeID);
            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                int msgdisputeID = 1;
                return msgdisputeID;
            }
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }
}