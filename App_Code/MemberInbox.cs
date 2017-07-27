using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class MemberInbox
    {
        // propertise of MemberInbox
        public int MemberInboxID { get; set; }
        public DateTime Date { get; set; }
        public Member Sender { get; set; }
        public Item Item { get; set; }

        // constructor for MemberInbox
        public MemberInbox(int memberInboxID, DateTime date, Member sender, Item item)
        {
            MemberInboxID = memberInboxID;
            Date = date;
            Sender = sender;
            Item = item;
        }

        // empty MemberInbox constructor
        public MemberInbox() { }
    }