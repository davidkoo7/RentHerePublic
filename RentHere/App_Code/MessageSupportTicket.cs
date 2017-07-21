using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MessageSupportTicket
/// </summary>
public class MessageSupportTicket
{
    private DateTime date;
    private string reply;
    private Member member;
    private Staff staff;
    private SupportTicket ticket;

    public MessageSupportTicket()
    { }

    public MessageSupportTicket(DateTime date, string reply, Member member, Staff staff, SupportTicket ticket)
    {
        this.date = date;
        this.reply = reply;
        this.member = member;
        this.staff = staff;
        this.ticket = ticket;
    }

    public MessageSupportTicket(DateTime date, string reply, Member member, SupportTicket ticket)
    {
        this.date = date;
        this.reply = reply;
        this.member = member;
        this.ticket = ticket;
    }

    public MessageSupportTicket(DateTime date, string reply, Staff staff, SupportTicket ticket)
    {
        this.date = date;
        this.reply = reply;
        this.staff = staff;
        this.ticket = ticket;
    }


    public DateTime Date { get; set; }
    public string Reply { get; set; }
    public Member Member { get; set; }
    public Staff Staff { get; set; }
    public SupportTicket Ticket { get; set; }
}