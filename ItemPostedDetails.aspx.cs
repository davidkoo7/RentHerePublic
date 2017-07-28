using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ItemPostedDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check if any item is selected
        if (Request.QueryString["itemID"] == null)
        {
            Response.Redirect("itemPosted.aspx"); 
            return;
        }

        //display item details
        List<Item> itemInfoDetails = new List<Item>();
        Item itemInfo = ItemDB.getItembyID((Request.QueryString["itemID"].ToString()));

        itemInfoDetails.Add(itemInfo);

        rptInfo.DataSource = itemInfoDetails;
        rptInfo.DataBind();

        List<Rental> itemRental = RentalDB.getRentalofItem(Request.QueryString["itemID"].ToString(), null);

        rptRentalHistory.DataSource = itemRental;
        rptRentalHistory.DataBind();
    }

    // check when item is due if any
    public string checkEndDate(string rentalID)
    {
        Extension itemExtension = ExtensionDB.getLastExtensionofRental(rentalID);


        if (itemExtension.ExtensionID == null)
        {
            Rental itemRental = RentalDB.getRentalbyID(rentalID);
            return itemRental.EndDate.ToString();
            
        }
        else
        {
            return itemExtension.NewEndDate.ToString();
        }
    }
}