using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupportTicket
/// </summary>
public class SupportTicket
{
    public string TicketID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string Urgency { get; set; }
    public Member Member { get; set; }
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

    public SupportTicket() { }


}