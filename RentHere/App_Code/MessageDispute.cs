using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MessageDispute
/// </summary>
public class MessageDispute
{
    public DateTime Date { get; set; }
    public string Reply { get; set; }
    public Member Member { get; set; }
    public Staff Staff { get; set; }
    public Dispute Dispute { get; set; }

    public MessageDispute(DateTime date, string reply, Member member, Staff staff, Dispute dispute)
    {
        //
        // TODO: Add constructor logic here
        //
        Date = date;
        Reply = reply;
        Member = member;
        Staff = staff;
        Dispute = dispute;
    }

    public MessageDispute() { }
}