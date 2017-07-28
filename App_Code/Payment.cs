using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Payment
{
    // constructor for Payment 
    public Payment(string paymentID, string stripeRefNum)
    {
        PaymentID = paymentID;
        StripeRefNum = stripeRefNum;
    }

    // empty Payment constructor
    public Payment() { }

    // properties of Payment
    public string PaymentID { get; set; }
    public string StripeRefNum { get; set; }
}