using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RentalDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }

        if (Request.QueryString["rentalID"] == null)
        {
            Response.Redirect("RentalHistory.aspx");
            return;
        }

        List<Rental> rentalInfo = new List<Rental>();
        rentalInfo.Add(RentalDB.getRentalbyID(Request.QueryString["rentalID"].ToString()));
        rptItemRentalInfo.DataSource = rentalInfo;
        rptItemRentalInfo.DataBind();

        if (Session["user"].ToString() == rentalInfo[0].Item.Renter.Email)
        {
            if (rentalInfo[0].Status == "Ended")
            {
                btnRetrivalCode.Visible = true;
                lblTitle.Text = "Deposit Retrival";
                lblCode.Text = "Please enter Deposit Retrival Code";
            }

            if (rentalInfo[0].Status == "Ended & Returned")
                btnDispute.Visible = true;
        }
        else
        {
            if (rentalInfo[0].Status == "Scheduled" && DateTime.Today == rentalInfo[0].StartDate)
            {
                btnReleaseCode.Visible = true;
                lblTitle.Text = "Payment Release Code";
                lblCode.Text = "Please enter Payment Release Code";
            }

            if (rentalInfo[0].Status == "On-going")
                btnExtend.Visible = true;
        }



    }

    public string checkEndDate(string rentalID)
    {
        Extension itemExtension = ExtensionDB.getLastExtensionofRental(rentalID);
        Rental itemRental = RentalDB.getRentalbyID(rentalID);


        if (itemExtension.ExtensionID == null)
        {
            return String.Format("{0:MM/dd/yy}", itemRental.StartDate) + " - " + String.Format("{0:MM/dd/yy}", itemRental.EndDate);

        }
        else
        {
            return String.Format("{0:MM/dd/yy}", itemRental.StartDate) + " - " + String.Format("{0:MM/dd/yy}", itemExtension.NewEndDate);
        }
    }



    protected void rptItemRentalInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Rental rentalInfo = RentalDB.getRentalbyID(Request.QueryString["rentalID"].ToString());

        if (e.Item.ItemType == ListItemType.Item)
        {
            Label lblTotalAmount = (Label)e.Item.FindControl("lblTotalAmount");
            Label lblMeetingLocation = (Label)e.Item.FindControl("lblMeetingLocation");
            Label lblTotalAmountPayable = (Label)e.Item.FindControl("lblTotalAmountPayable");

            Label lblItemStatus = e.Item.FindControl("lblItemStatus") as Label;
            lblTotalAmount.Text = rentalInfo.RentalFee.ToString();
            lblTotalAmountPayable.Text = rentalInfo.RentalFee.ToString();
            lblMeetingLocation.Text = rentalInfo.PickUpLocation;


        }
    }


    protected void btnExtend_Click(object sender, EventArgs e)
    {

    }

    protected void btnDispute_Click(object sender, EventArgs e)
    {
        // Help Stanley

    }


    protected void btnRetrivalCode_Click(object sender, EventArgs e)
    {

    }

    protected void btnReleaseCode_Click(object sender, EventArgs e)
    {


        

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lblTitle.Text == "Deposit Retrival")
        {
            if (tbxValue.Value == RentalDB.getRentalbyID(Request.QueryString["rentalID"].ToString()).DepositRetrievalCode)
            {
                RentalDB.updateRentStatus(Request.QueryString["rentalID"].ToString(), "Ended & Returned");
                btnRetrivalCode.Visible = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrect Retrival Code!')", true);
            }
        }
        else
        {

            if (tbxValue.Value == RentalDB.getRentalbyID(Request.QueryString["rentalID"].ToString()).PaymentReleaseCode)
            {
                RentalDB.updateRentStatus(Request.QueryString["rentalID"].ToString(), "On-going");
                btnReleaseCode.Visible = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Incorrect Payment Release Code!')", true);
            }
        }
    }
}