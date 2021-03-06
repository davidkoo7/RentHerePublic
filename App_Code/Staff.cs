﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Staff
{
    // constructor for Staff 
    public Staff(string staffID, string password, string name, string email, int phoneNumber, string gender, DateTime dateOfBirth)

    {
        StaffID = staffID;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Password = password;
    }

    // empty Staff constructor
    public Staff() { }

    // properties of Staff
    public string StaffID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Password { get; set; }
}