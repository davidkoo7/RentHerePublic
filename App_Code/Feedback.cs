﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Feedback
{
    // constructor for Feedback
    public Feedback(string feedbackID, string comments, string replyFeedback, DateTime date, string rating,
        Member submittedBy, Member feedbackTo, Rental rent)
    {
        FeedbackID = feedbackID;
        Comments = comments;
        ReplyFeedback = replyFeedback;
        Date = date;
        Rating = rating;
        SubmittedBy = submittedBy;
        FeedbackTo = feedbackTo;
        Rental = rent;
    }

    // empty Feedback constructor
    public Feedback() { }

    // properties of Feedback
    public string FeedbackID { get; set; }
    public string Comments { get; set; }
    public string ReplyFeedback { get; set; }
    public DateTime Date { get; set; }
    public string Rating { get; set; }
    public Member SubmittedBy { get; set; }
    public Member FeedbackTo { get; set; }
    public Rental Rental { get; set; }
}