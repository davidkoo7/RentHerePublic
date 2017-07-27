using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


public class CategoryDB
{
    // gets the connection value from "myConnectionString" in web.config to connect to database
    public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);

    // method to get all categories from the database
    public static List<Category> getAllCategory()
    {
        List<Category> categoryList = new List<Category>();
        try
        {
            SqlCommand command = new SqlCommand("Select * from Category");
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Category c = new Category();
                readACategory(ref c, ref reader);

                categoryList.Add(c);
            }
            reader.Close();
        }
        finally
        {
            connection.Close();
        }
        return categoryList;
    }

    // method to get categories by name from the database
    public static Category getCategorybyName(string catName)
    {
        Category cat = new Category();
        try
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Category WHERE name = @catName");
            command.Parameters.AddWithValue("@catName", catName);
            command.Connection = connection;
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                readACategory(ref cat, ref reader);
            else
                cat = new Category(null, null, null);
        }
        finally
        {
            connection.Close();
        }

        return cat;
    }

    // method to add category into the database, takes in parameter of type Category 
    public static int addCategory(Category categ)
    {
        try
        {
            SqlCommand command = new SqlCommand("INSERT INTO Category (name, description, type) VALUES (@name, @description, @type)");
            command.Parameters.AddWithValue("@name", categ.Name);
            command.Parameters.AddWithValue("@description", categ.Description);
            command.Parameters.AddWithValue("@type", categ.Type);

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

    // method to read the column values in the database(through the referenced reader) and assign it to the correct properties of the referenced Category object
    // allows for easier editing of column names if needed, used only for methods with select statments regarding category
    private static void readACategory(ref Category cat, ref SqlDataReader reader)
    {
        cat.Name = reader["name"].ToString();
        cat.Description = reader["description"].ToString();
        cat.Type = reader["type"].ToString();
    }
}