using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Payment
/// </summary>
public class Payment
{
    
    public Payment(string paymentID, string stripeRefNum)
    {
        PaymentID = paymentID;
        StripeRefNum = stripeRefNum;
    }

    public Payment() { }

    public string PaymentID { get; set; }
    public string StripeRefNum { get; set; }
}