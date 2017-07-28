using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class MessageDispute
{
    // properties of MessageDispute
    public DateTime Date { get; set; }
    public string Reply { get; set; }
    public Member Member { get; set; }
    public Staff Staff { get; set; }
    public Dispute Dispute { get; set; }

    // constructor of MessageDispute
    public MessageDispute(DateTime date, string reply, Member member, Staff staff, Dispute dispute)
    {
        Date = date;
        Reply = reply;
        Member = member;
        Staff = staff;
        Dispute = dispute;
    }

    // empty MessageDispute constructor 
    public MessageDispute() { }
}