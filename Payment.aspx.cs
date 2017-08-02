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

        if(Request.QueryString["rentalID"] != null && !RentalDB.isRentalOfMemberPresent(Request.QueryString["rentalID"].ToString(), MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID))
        {
            Response.Redirect("ProductDetails.aspx?itemID=" + Request.QueryString["rentalID"]);
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

        Rental rentInfo = (Rental)Session["rental"];
        lblTotalAmount.Text = rentInfo.RentalFee.ToString();
        lblTotalAmountPayable.Text = rentInfo.RentalFee.ToString();

    }

    protected void btnPay_Click(object sender, EventArgs e)
    {
        // submit payment 

        Item itemInfo = ItemDB.getItembyID(Request.QueryString["itemID"]);

        Member mem = MemberDB.getMemberbyEmail(Session["user"].ToString());

        Rental rentInfo = (Rental)Session["rental"];
        var myCharge = new StripeChargeCreateOptions();
        myCharge.Amount = Convert.ToInt32(rentInfo.RentalFee) * 100;
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
            rentInfo.DateCreated = DateTime.Now;
            rentInfo.Deposit = itemInfo.Deposit;
            rentInfo.PaymentReleaseCode = Utility.getRandomizedChar(6, 0);
            rentInfo.Item = itemInfo;

            rentInfo.StartDate = Convert.ToDateTime(startDate);
            rentInfo.EndDate = Convert.ToDateTime(endDate);
            rentInfo.Status = "Scheduled";

            rentInfo.Payment = PaymentDB.getPaymentbyID(Utility.convertIdentitytoPK("PAY", PaymentDB.addPayment(pay)));
            rentInfo.Rentee = mem;
            rentInfo.Unit = "Day";

            Response.Redirect("RentalDetails.aspx?rentalID=" + Utility.convertIdentitytoPK("RNT", RentalDB.addRental(rentInfo)));
        }
        else
        {
            Rental rent = RentalDB.getRentalbyID(Request.QueryString["rentalID"]);

            Extension ext = new Extension();

            ext.ExtensionRentalFee = rentInfo.RentalFee;
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