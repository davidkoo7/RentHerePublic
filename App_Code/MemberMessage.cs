using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MemberMessage
/// </summary>
public class MemberMessage
{
    public MemberInbox MemberInbox { get; set; }
    public DateTime Date { get; set; }
    public string Reply { get; set; }
    public Member Sender { get; set; }

    public MemberMessage(MemberInbox memberInbox, DateTime date, string reply, Member sender)
    {
        MemberInbox = memberInbox;
        Date = date;
        Reply = reply;
        Sender = sender;
    }

    public MemberMessage() { }
}