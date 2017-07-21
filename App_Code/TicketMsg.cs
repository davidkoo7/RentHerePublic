using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TicketMsg
/// </summary>
public class TicketMsg
{

    private DateTime date;
    private string msg;
    private string person;
    private SupportTicket ticket;

    public TicketMsg()
    {
    }

    //public TicketMsg(string msg, string person, SupportTicket ticket)
    //{
    //    this.msg = msg;
    //    this.person = person;
    //    this.ticket = ticket;
    //}
    public TicketMsg(DateTime date, string msg, string person, SupportTicket ticket)
    {
        this.date = date;
        this.msg = msg;
        this.person = person;
        this.ticket = ticket;
    }

    public DateTime Date { get; set; }
    public string Msg { get; set; }
    public string Person { get; set; }
    public SupportTicket Ticket { get; set; }
}