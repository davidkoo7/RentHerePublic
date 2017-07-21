using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Location
/// </summary>
public class Location
{
    
    public Location(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public Location() { }

    public string Name { get; set; }
    public string Description { get; set; }
}