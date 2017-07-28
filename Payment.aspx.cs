using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;
using System.Globalization;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check if logged in 
        if (Session["user"] == null) // not logged in 
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx"); // go to login page
            return;
        }

        if (Request.QueryString["itemID"] == null) // if there is item selected 
        {
            Response.Redirect("Categories.aspx"); // go to categories page
            return;
        }

        // populate payment fields 
        List<Item> itemInfo = new List<Item>();
        itemInfo.Add(ItemDB.getItembyID(Request.QueryString["itemID"]));
        rptItemRentalInfo.DataSource = itemInfo;
        rptItemRentalInfo.DataBind();

        lblDepositAmount.Text = itemInfo[0].Deposit.ToString();
        lblRentalPeriod.Text = Session["rentalPeriod"].ToString();
        lblRentalRate.Text = Session["rentalRate"].ToString();
        lblTotalAmount.Text = Session["totalAmountPayable"].ToString();
        lblTotalAmountPayable.Text = Session["totalAmountPayable"].ToString();

    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        // submit payment 

        Item itemInfo = ItemDB.getItembyID(Request.QueryString["itemID"]);

        Member mem = MemberDB.getMemberbyEmail(Session["user"].ToString());

        var myCharge = new StripeChargeCreateOptions();
        myCharge.Amount = 50;
        myCharge.Currency = "sgd";

        myCharge.SourceCard = new SourceCard()
        {
            Number = "4242424242424242",
            ExpirationYear = 2022,
            ExpirationMonth = 10,
            AddressCountry = "SG",                // optional
            AddressLine1 = mem.Address,    // optional
            AddressLine2 = mem.Address,              // optional
            AddressCity = "Singapore",        // optional
            AddressState = "NC",                  // optional
            AddressZip = mem.PostalCode.ToString(),                 // optional
            Name = mem.Name,               // optional
            Cvc = "1223"                          // optional
        };
        var chargeService = new StripeChargeService();
        StripeCharge stripeCharge = chargeService.Create(myCharge);

        PaymentPay pay = new PaymentPay();

        pay.StripeRefNum = Utility.getRandomizedChar(5, 0);


        string n = Session["rentalPeriod"].ToString();
        string startDate = n.Substring(0, 10);
        string endDate = n.Substring(n.Length - 10);

        if (Session["itemExtension"].ToString() == "NotExtension")
        { 
        Rental rent = new Rental();
        rent.DateCreated = DateTime.Now;
        rent.Deposit = itemInfo.Deposit;
        rent.DepositRetrievalCode = Utility.getRetrivalCode(6, 0);
        rent.PaymentReleaseCode = Utility.getRandomizedChar(6, 0);
        rent.PickUpLocation = Session["pickUpLocation"].ToString();
        rent.RentalFee = Convert.ToDecimal(Session["totalAmountPayable"].ToString());

        DateTime pickUpTime = DateTime.ParseExact(Session["pickUpTime"].ToString(),
                            "hh:mm tt", CultureInfo.InvariantCulture);
        TimeSpan pickUpTimeSpan = pickUpTime.TimeOfDay;

        DateTime returnTime = DateTime.ParseExact(Session["returnTime"].ToString(),
                    "hh:mm tt", CultureInfo.InvariantCulture);
        TimeSpan returnTimeSpan = returnTime.TimeOfDay;

        rent.PickUpTime = pickUpTimeSpan;
        rent.ReturnTime = returnTimeSpan;

        rent.ReturnLocation = Session["returnLocation"].ToString();
        rent.Item = itemInfo;


        rent.StartDate = Convert.ToDateTime(startDate);
        rent.EndDate = Convert.ToDateTime(endDate);
        rent.Status = "Scheduled";

        rent.Payment = PaymentDB.getPaymentbyID(Utility.convertIdentitytoPK("PAY", PaymentDB.addPayment(pay)));

        rent.Rentee = mem;


        rent.Unit = "Day";

        Response.Redirect("RentalDetails.aspx?rentalID=" + Utility.convertIdentitytoPK("RNT", RentalDB.addRental(rent)));
        }
        else
        {
            Rental rent = RentalDB.getRentalbyID(Request.QueryString["rentalID"]);
            Extension ext = new Extension();
            ext.ExtensionRentalFee = Convert.ToDecimal(Session["totalAmountPayable"].ToString());
            ext.NewEndDate = Convert.ToDateTime(endDate);
            ext.NewReturnLocation = rent.ReturnLocation;
            int paymentID = PaymentDB.addPayment(pay);

            pay.PaymentID = Utility.convertIdentitytoPK("PAY", paymentID);
            ext.NewReturnTime = rent.ReturnTime;
            ext.Payment = pay;

            ext.Rental = rent;
            ext.Status = "Granted";
            ext.Unit = "Day";

            ExtensionDB.addExtension(ext);

            Response.Redirect("RentalDetails.aspx?rentalID=" + Request.QueryString["rentalID"]);

        }
    }

}