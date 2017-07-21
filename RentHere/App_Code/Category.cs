using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Category
{
    private string name;
    private string description;
    private string type;

    public Category(string name, string description, string type)
    {
        this.name = name;
        this.description = description;
        this.type = type;
    }

    public Category() { /*empty constructor*/ }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public string Type
    {
        get { return type; }
        set { type = value; }
    }
}