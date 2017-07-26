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

        //if (Request.QueryString["rentalID"] == null)
        //{
        //    Response.Redirect("RentalHistory.aspx");
        //    return;
        //}

        List<Rental> rentalInfo = new List<Rental>();
        rentalInfo.Add(RentalDB.getRentalbyID("RNT000000003"));
        rptItemRentalInfo.DataSource = rentalInfo;
        rptItemRentalInfo.DataBind();

        if (Session["user"].ToString() == rentalInfo[0].Item.Renter.Email)
        {
            if (rentalInfo[0].Status == "Ended")
                btnRetrivalCode.Visible = true;

            if (rentalInfo[0].Status == "Ended & Returned")
                btnDispute.Visible = true;
        }
        else
        {
            if (rentalInfo[0].Status == "Pending")
                btnReleaseCode.Visible = true;

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
            return String.Format("{0:MM/dd/yy}", itemRental.StartDate) +" - " + String.Format("{0:MM/dd/yy}", itemRental.EndDate);

        }
        else
        {
            return String.Format("{0:MM/dd/yy}", itemRental.StartDate) +" - " + String.Format("{0:MM/dd/yy}", itemExtension.NewEndDate);
        }
    }



    protected void rptItemRentalInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Rental rentalInfo = RentalDB.getRentalbyID("RNT000000003");

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
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your message cannot exceed 255 characters!')", true);

    }

    protected void btnDispute_Click(object sender, EventArgs e)
    {
        // Help Stanley
        
    }


    protected void btnRetrivalCode_Click(object sender, EventArgs e)
    {

        lblTitle.Text = "Deposit Retrival";
        lblCode.Text = "Please enter Deposit Retrival Code";


    }

    protected void btnReleaseCode_Click(object sender, EventArgs e)
    {

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
}