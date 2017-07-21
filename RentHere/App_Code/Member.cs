using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Member
{
    private string memberID;
    private string name;
    private string address;
    private int postalCode;
    private string password;
    private string email;
    private int phoneNumber;
    private string identificationNumber;
    private string identificationPicture;
    private DateTime dateJoined;
    private DateTime dateVerified;
    private string gender;
    private DateTime dateOfBirth;
    private string status;
    private string profilePic;


    public Member(string memberID, string name, string address, int postalCode, string password, string email, 
        int phoneNumber, string identificationNumber, string identificationPicture, DateTime dateJoined, DateTime dateVerified, 
        string gender, DateTime dateOfBirth, string status, string profilePic)
    {
        this.memberID = memberID;
        this.name = name;
        this.address = address;
        this.postalCode = postalCode;
        this.password = password;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.identificationNumber = identificationNumber;
        this.identificationPicture = identificationPicture;
        this.dateJoined = dateJoined;
        this.dateVerified = dateVerified;
        this.gender = gender;
        this.dateOfBirth = dateOfBirth;
        this.status = status;
        this.profilePic = profilePic;

    }

    public Member() { /* empty constructors */ }

    public string MemberID { get { return memberID; } set { memberID = value; } }
    public string Name { get { return name; } set { name = value; } }
    public string Address { get { return address; } set { address = value; } }
    public int PostalCode { get { return postalCode; } set { postalCode = value; } }
    public string Password { get { return password; } set { password = value; } }
    public string Email { get { return email; } set { email = value; } }
    public int PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
    public string IdentificationNumber { get { return identificationNumber; } set { identificationNumber = value; } }
    public string IdentificationPicture { get { return identificationPicture; } set { identificationPicture = value; } }
    public DateTime DateJoined { get { return dateJoined; } set { dateJoined = value; } }
    public DateTime DateVerified { get { return dateVerified; } set { dateVerified = value; } }
    public string Gender { get { return gender; } set { gender = value; } }
    public DateTime DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; } }
    public string Status { get { return status; } set { status = value; } }
    public string ProfilePicture { get { return profilePic; } set { profilePic = value; } }

}