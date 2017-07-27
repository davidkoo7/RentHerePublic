using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TicketMsg
{
    // TicketMsg fields
    private DateTime date;
    private string msg;
    private string person;
    private SupportTicket ticket;

    // empty TicketMsg constructor 
    public TicketMsg()
    {
    }

    //public TicketMsg(string msg, string person, SupportTicket ticket)
    //{
    //    this.msg = msg;
    //    this.person = person;
    //    this.ticket = ticket;
    //}
     
    // constructor for TicketMsg
    public TicketMsg(DateTime date, string msg, string person, SupportTicket ticket)
    {
        this.date = date;
        this.msg = msg;
        this.person = person;
        this.ticket = ticket;
    }

    // properties of TicketMsg
    public DateTime Date { get; set; }
    public string Msg { get; set; }
    public string Person { get; set; }
    public SupportTicket Ticket { get; set; }
}