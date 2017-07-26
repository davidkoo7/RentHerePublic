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
        rentalInfo.Add(RentalDB.getRentalbyID("RNT000000013"));
        rptItemRentalInfo.DataSource = rentalInfo;
        rptItemRentalInfo.DataBind();

    }

    public string checkEndDate(string rentalID)
    {
        Extension itemExtension = ExtensionDB.getLastExtensionofRental(rentalID);
        Rental itemRental = RentalDB.getRentalbyID(rentalID);


        if (itemExtension.ExtensionID == null)
        {
            return itemRental.StartDate.ToString() + itemRental.EndDate.ToString();

        }
        else
        {
            return itemRental.StartDate.ToString() + itemExtension.NewEndDate.ToString();
        }
    }



    protected void rptItemRentalInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Rental rentalInfo = RentalDB.getRentalbyID("RNT000000013");

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

}