using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Dispute
{
    // properties of Dispute
    public string DisputeID { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }

    public Member SubmittedBy { get; set; }

    public Rental Rental { get; set; }

    // constructor for Dispute
    public Dispute(string id, string reason, DateTime date, string status, Member submittedBy, Rental rental )
    {
        DisputeID = id;
        Reason = reason;
        Date = date;
        Status = status;
        SubmittedBy = submittedBy;
        Rental = rental;
    }

    // empty Dispute constructor
    public Dispute() { }
}