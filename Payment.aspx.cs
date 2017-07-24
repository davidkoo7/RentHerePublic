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
        var service = new AdaptivePaymentsService();


        var receiverList = new ReceiverList(new List<Receiver>
{
    new Receiver { email = "support-buyer@renthere.sg", amount = 10m}
});

        var payRequest = new PayRequest(
            new RequestEnvelope { errorLanguage = "en_US", detailLevel = DetailLevelCode.RETURNALL },
            "PAY", "http://localhost:60686/Paypal/Cancel",
            "USD", receiverList, "http://localhost:60686/Paypal/Return");

        var response = service.Pay(payRequest);
    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        //var myCharge = new StripeChargeCreateOptions();
        //myCharge.Amount = 12312;
        //myCharge.Currency = "sgd";

        //myCharge.SourceCard = new SourceCard()
        //{
        //    Number = "4242424242424242",
        //    ExpirationYear = 2022,
        //    ExpirationMonth = 10,
        //    AddressCountry = "US",                // optional
        //    AddressLine1 = "24 Beef Flank St",    // optional
        //    AddressLine2 = "Apt 24",              // optional
        //    AddressCity = "Biggie Smalls",        // optional
        //    AddressState = "NC",                  // optional
        //    AddressZip = "27617",                 // optional
        //    Name = "Joe Meatballs",               // optional
        //    Cvc = "1223"                          // optional
        //};
        //var chargeService = new StripeChargeService();
        //StripeCharge stripeCharge = chargeService.Create(myCharge);

    }

}