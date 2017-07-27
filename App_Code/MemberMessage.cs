using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class MemberMessage
{
    // properties of MemberMessage
    public MemberInbox MemberInbox { get; set; }
    public DateTime Date { get; set; }
    public string Reply { get; set; }
    public Member Sender { get; set; }

    // constructor for MemberMessage
    public MemberMessage(MemberInbox memberInbox, DateTime date, string reply, Member sender)
    {
        MemberInbox = memberInbox;
        Date = date;
        Reply = reply;
        Sender = sender;
    }

    // empty MemberMessage constructor
    public MemberMessage() { }
}