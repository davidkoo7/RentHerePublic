using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class FAQ
{
    // properties of FAQ
    public string FaqID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Staff Staff { get; set; }

    // constructor for FAQ
    public FAQ(string faqID, string title, string description, DateTime date, Staff staff)
    {
        FaqID = faqID;
        Title = title;
        Description = description;
        Date = date;
        Staff = staff;
    }

    // empty FAQ constructor
    public FAQ() { }    
}