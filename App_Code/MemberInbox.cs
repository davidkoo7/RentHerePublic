using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MemberInbox
/// </summary>
    public class MemberInbox
    {
        public int MemberInboxID { get; set; }
        public DateTime Date { get; set; }
        public Member Sender { get; set; }
        public Item Item { get; set; }

        public MemberInbox(int memberInboxID, DateTime date, Member sender, Item item)
        {
            MemberInboxID = memberInboxID;
            Date = date;
            Sender = sender;
            Item = item;
        }

        public MemberInbox() { }
    }