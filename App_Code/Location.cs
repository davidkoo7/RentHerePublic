using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Location
{
    // constructor for Location
    public Location(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // empty Location constructor
    public Location() { }

    // properties of Location
    public string Name { get; set; }
    public string Description { get; set; }
}