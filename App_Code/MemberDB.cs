using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


public class MemberDB
{

    static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);


    public static bool isPermittedLogin(string email, string password)
    {
        bool permittedLogin = false;
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Member WHERE email = @email and password = @password");
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

    public static Member getMemberbyEmail(string email)
    {
        Member m = new Member();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Member WHERE email = @email");
            command.Connection = connection;
            command.Parameters.AddWithValue("@email", email);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                readAMember(ref m, ref reader);
            else
                m = new Member(null, null, null, 0, null, null, 0, null, null, new DateTime(), new DateTime(), null, new DateTime(), null, null);


            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return m;
    }

    public static Member getMemberbyPhone(string phoneNumber)
    {
        Member m = new Member();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Member WHERE phoneNumber = @phoneNumber");
            command.Connection = connection;
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                readAMember(ref m, ref reader);
            else
                m = new Member(null, null, null, 0, null, null, 0, null, null, new DateTime(), new DateTime(), null, new DateTime(), null, null);


            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return m;
    }


    public static int updateMemberStatus(string memberID, string status)
    {
        try
        {
            SqlCommand command = new SqlCommand("UPDATE Member SET status=@status WHERE memberID = @memberID");
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@memberID", memberID);

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

    public static int changeMemberPassword(string email, string newPassword)
    {
        try
        {
            SqlCommand command = new SqlCommand("UPDATE Member SET password=@password WHERE email = @email");
            command.Parameters.AddWithValue("@password", newPassword);
            command.Parameters.AddWithValue("@email", email);

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

    public static int addMember(Member m)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT into Member (name, address, postalCode, password, email, phoneNumber, identificationNumber, identificationPicture, dateJoined, dateVerified, gender, dateofBirth, status, profilePic) VALUES (@name, @address, @postalCode, @password, @email, @phoneNumber, @identificationNumber, @identificationPicture, @dateJoined, @dateVerified, @gender, @dateofBirth,@status,@profilePic)");
            command.Parameters.AddWithValue("@name", m.Name);
            command.Parameters.AddWithValue("@address", m.Address);
            command.Parameters.AddWithValue("@postalCode", m.PostalCode);
            command.Parameters.AddWithValue("@password", m.Password);
            command.Parameters.AddWithValue("@email", m.Email);
            command.Parameters.AddWithValue("@phoneNumber", m.PhoneNumber);
            command.Parameters.AddWithValue("@identificationNumber", DBNull.Value);
            command.Parameters.AddWithValue("@identificationPicture", DBNull.Value);

            command.Parameters.AddWithValue("@dateJoined", m.DateJoined);
            command.Parameters.AddWithValue("@dateVerified", DBNull.Value);
            command.Parameters.AddWithValue("@gender", m.Gender);
            command.Parameters.AddWithValue("@dateofBirth", m.DateOfBirth);
            command.Parameters.AddWithValue("@status", m.Status);

            if (m.ProfilePicture != null)
                command.Parameters.AddWithValue("@profilePic", DBNull.Value);
            else
                command.Parameters.AddWithValue("@profilePic", DBNull.Value);

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

    public static int updateICVerification(string memberID, string identificationNumber, string identificationPicture)
    {
        try
        {
            SqlCommand command = new SqlCommand("UPDATE Member SET identificationNumber=@identificationNumber, identificationPicture=@identificationPicture WHERE memberID=@memberID");

            if (identificationNumber != null)
                command.Parameters.AddWithValue("@identificationNumber", identificationNumber);
            else
                command.Parameters.AddWithValue("@identificationNumber", DBNull.Value);

            if (identificationPicture != null)
                command.Parameters.AddWithValue("@identificationPicture", identificationPicture);
            else
                command.Parameters.AddWithValue("@identificationPicture", DBNull.Value);

            command.Parameters.AddWithValue("@memberID", memberID);
            command.Connection = connection;
            connection.Open();

            if (command.ExecuteNonQuery() > 0)
                return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    public static int updateProfilePicture(string memberID, string profilePic)
    {
        try
        {
            SqlCommand command = new SqlCommand("UPDATE Member SET profilePic=@profilePic WHERE memberID=@memberID");

            command.Parameters.AddWithValue("@profilePic", profilePic);
            command.Parameters.AddWithValue("@memberID", memberID);

            command.Connection = connection;
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
                return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    public static List<Member> getAllMembertoVerify()
    {
        List<Member> memberList = new List<Member>();

        try
        {
            SqlCommand command = new SqlCommand("SELECT * from Member WHERE identificationNumber IS NOT NULL and identificationPicture IS NOT NULL and dateVerified IS NULL and identificationNumber<>'Rejected' and identificationPicture<>'Rejected'");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Member m = new Member();
                readAMember(ref m, ref reader);

                memberList.Add(m);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return memberList;
    }

    public static int confirmICVerification(string memberID, DateTime dateVerified)
    {
        try
        {
            SqlCommand command = new SqlCommand("UPDATE member SET dateVerified=@dateVerified WHERE memberID=@memberID");
            command.Parameters.AddWithValue("@memberID", memberID);
            command.Parameters.AddWithValue("@dateVerified", dateVerified);
            command.Connection = connection;
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
                return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    public static int updateMemberDetail(Member member)
    {
        try
        {
            SqlCommand command = new SqlCommand("UPDATE Member SET name = @name,address = @address, postalCode = @postalCode, password = @password, email = @email, phoneNumber = @phoneNumber, gender = @gender WHERE memberID = @memberID");

            command.Parameters.AddWithValue("@name", member.Name);
            command.Parameters.AddWithValue("@address", member.Address);
            command.Parameters.AddWithValue("@postalCode", member.PostalCode);
            command.Parameters.AddWithValue("@password", member.Password);
            command.Parameters.AddWithValue("@email", member.Email);
            command.Parameters.AddWithValue("@phoneNumber", member.PhoneNumber);
            command.Parameters.AddWithValue("@gender", member.Gender);

            command.Parameters.AddWithValue("@memberID", member.MemberID);
            command.Connection = connection;
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
                return command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
        return -1;
    }

    public static Member getMemberbyID(string memberID)
    {
        Member m = new Member();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Member WHERE memberID = @memberID");
            command.Connection = connection;
            command.Parameters.AddWithValue("@memberID", memberID);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                readAMember(ref m, ref reader);
            else
                m = new Member(null, null, null, 0, null, null, 0, null, null, new DateTime(), new DateTime(), null, new DateTime(), null, null);

            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return m;
    }

    public static List<Member> getAllMember()
    {
        List<Member> memberList = new List<Member>();

        try
        {
            SqlCommand command = new SqlCommand("select * from Member");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Member m = new Member();
                readAMember(ref m, ref reader);

                memberList.Add(m);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return memberList;
    }

    private static void readAMember(ref Member m, ref SqlDataReader reader)
    {
        m.MemberID = reader["memberID"].ToString();
        m.Name = reader["name"].ToString();
        m.Address = reader["address"].ToString();
        m.PostalCode = Convert.ToInt32(reader["postalCode"]);
        m.Password = reader["password"].ToString();
        m.Email = reader["email"].ToString();
        m.PhoneNumber = Convert.ToInt32(reader["phoneNumber"]);
        m.DateJoined = Convert.ToDateTime(reader["dateJoined"]);
        m.Gender = reader["gender"].ToString();
        m.DateOfBirth = Convert.ToDateTime(reader["dateOfBirth"]);
        m.Status = Convert.ToString(reader["status"]);

        // This section will set the id number to an empty string if in any case that NULL is retrieved from DB
        if (reader["identificationNumber"] != DBNull.Value)
            m.IdentificationNumber = reader["identificationNumber"].ToString();
        else
            m.IdentificationNumber = "";

        if (reader["identificationPicture"] != DBNull.Value)
            m.IdentificationPicture = reader["identificationPicture"].ToString();
        else
            m.IdentificationPicture = "";

        //IF the dateVerified column is a null in a certain row, 
        //then the date will be represented as 1/1/0001 within the list after the retrieval
        if (reader["dateVerified"] != DBNull.Value)
            m.DateVerified = Convert.ToDateTime(reader["dateVerified"]);
        else
            m.DateVerified = new DateTime(1, 1, 1);

        // DefaultPic is set if there is no picture
        if (reader["profilePic"] != DBNull.Value)
            m.ProfilePicture = reader["profilePic"].ToString();
        else
            m.ProfilePicture = "DefaultPic.jpg";
    }


}