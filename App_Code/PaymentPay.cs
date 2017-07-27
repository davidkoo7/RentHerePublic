using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentPay
/// </summary>
public class PaymentPay
{
    public PaymentPay(string paymentID, string stripeRefNum)
    {
        PaymentID = paymentID;
        StripeRefNum = stripeRefNum;
    }

    public PaymentPay() { }

    public string PaymentID { get; set; }
    public string StripeRefNum { get; set; }
}