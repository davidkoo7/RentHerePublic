using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class FeedbackDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database 
    private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all feedbacks by member from the database 
    public static List<Feedback> getFeedbackFor(string memberID)
    {
        List<Feedback> feedList = new List<Feedback>();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Feedback WHERE feedbackTo = @memberID");
            command.Parameters.AddWithValue("@memberID", memberID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Feedback f = new Feedback();
                readAFeedback(ref f, ref reader);

                feedList.Add(f);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return feedList;
    }

    // method to get feedback by feedbackID from the database
    public static Feedback getFeedbackByID(string feedbackID)
    {
        Feedback f = new Feedback();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Feedback WHERE feedbackID = @feedbackID");
            command.Parameters.AddWithValue("@feedbackID", feedbackID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAFeedback(ref f, ref reader);
            else
                f = new Feedback(null, null, null, new DateTime(), null, new Member(), new Member(), new Rental());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return f;
    }

    // method to get feedback by rentalID from the database 
    public static Feedback getFeedbackforRental(string rentalID)
    {
        Feedback f = new Feedback();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Feedback WHERE rentalID = @rentalID");
            command.Parameters.AddWithValue("@rentalID", rentalID);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readAFeedback(ref f, ref reader);
            else
                f = new Feedback(null, null, null, new DateTime(), null, new Member(), new Member(), new Rental());

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return f;
    }

    // method to add feedback into database, takes in parameter of type Feedback
    public static int addFeedback(Feedback feed)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO Feedback (comments, replyFeedback, date, rating, submittedBy, feedbackTo, rentalID) VALUES (@comments, @replyFeedback, @date, @rating, @submittedBy, @feedbackTo, @rentalID)");
            command.Parameters.AddWithValue("@comments", feed.Comments);

            if (feed.ReplyFeedback != null) // SUPPLY WITH NULL if you want it to be NULL in the DB!!
                command.Parameters.AddWithValue("@replyFeedback", feed.ReplyFeedback);
            else
                command.Parameters.AddWithValue("@replyFeedback", DBNull.Value);

            command.Parameters.AddWithValue("@date", feed.Date);
            command.Parameters.AddWithValue("@rating", feed.Rating);
            command.Parameters.AddWithValue("@submittedBy", feed.SubmittedBy.MemberID);
            command.Parameters.AddWithValue("@feedbackTo", feed.FeedbackTo.MemberID);
            command.Parameters.AddWithValue("@rentalID", feed.Rental.RentalID);

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

    // method to update reply for feedback into database, takes in parameter of type Feedback
    public static int setReplyforFeedback(Feedback feed)
    {
        try
        {
            SqlCommand command = new SqlCommand("UPDATE Feedback SET replyFeedback=@replyFeedback WHERE feedbackID = @feedbackID");
            command.Parameters.AddWithValue("@replyFeedback", feed.ReplyFeedback);
            command.Parameters.AddWithValue("@feedbackID", feed.FeedbackID);

            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                //command.CommandText = "SELECT @@identity";
                //int disputeID = Convert.ToInt32(command.ExecuteScalar());

                return 1;
            }
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    // method to read the column values in the database (through the referenced reader) and assign it to the correct properties of the referenced Feedback object 
    // allows for easier editing of column names if needed, used only for methods with select statments regarding Feedback
    private static void readAFeedback(ref Feedback feed, ref SqlDataReader reader)
    {
        feed.FeedbackID = reader["feedbackID"].ToString();
        feed.Comments = reader["comments"].ToString();

        if (reader["replyFeedback"] != DBNull.Value)
            feed.ReplyFeedback = reader["replyFeedback"].ToString();
        else
            feed.ReplyFeedback = null;

        feed.Date = Convert.ToDateTime(reader["date"]);
        feed.Rating = reader["rating"].ToString();
        feed.SubmittedBy = MemberDB.getMemberbyID(reader["submittedBy"].ToString());
        feed.FeedbackTo = MemberDB.getMemberbyID(reader["feedbackTo"].ToString());
        feed.Rental = RentalDB.getRentalbyID(reader["rentalID"].ToString());
    }
}