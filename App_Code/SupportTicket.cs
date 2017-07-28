using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class SupportTicket
{
    // properties of SupportTicket
    public string TicketID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string Urgency { get; set; }
    public Member Member { get; set; }

    // constructor for SupportTicket
    public SupportTicket(string ticketID, string title, string description, DateTime date, string status, string urgency, Member member)
    {
        TicketID = ticketID;
        Title = title;
        Description = description;
        Date = date;
        Status = status;
        Urgency = urgency;
        Member = member;
    }

    // empty SupportTicket constructor
    public SupportTicket() { }


}