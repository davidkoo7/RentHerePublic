using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;


public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        var myCharge = new StripeChargeCreateOptions();
        myCharge.Amount = 12312;
        myCharge.Currency = "sgd";

        myCharge.SourceCard = new SourceCard()
        {
            Number = "4242424242424242",
            ExpirationYear = 2022,
            ExpirationMonth = 10,
            AddressCountry = "US",                // optional
            AddressLine1 = "24 Beef Flank St",    // optional
            AddressLine2 = "Apt 24",              // optional
            AddressCity = "Biggie Smalls",        // optional
            AddressState = "NC",                  // optional
            AddressZip = "27617",                 // optional
            Name = "Joe Meatballs",               // optional
            Cvc = "1223"                          // optional
        };
        var chargeService = new StripeChargeService();
        StripeCharge stripeCharge = chargeService.Create(myCharge);

    }

}