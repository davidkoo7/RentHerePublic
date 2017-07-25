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
        List<Item> itemInfoDetails = new List<Item>();
        Item itemInfo = ItemDB.getItembyID(("ITM000000001"));

        itemInfoDetails.Add(itemInfo);

        rptInfo.DataSource = itemInfoDetails;
        rptInfo.DataBind();

            List<Rental> itemRental = RentalDB.getRentalofItem("ITM000000001", null);

        rptRentalHistory.DataSource = itemRental;
        rptRentalHistory.DataBind();
    }


    public string checkEndDate(string itemID)
    {
        Extension itemExtension = ExtensionDB.getLastExtensionofItem(itemID, "On-going");


        if (itemExtension.ExtensionID == null)
        {
            List<Rental> itemRental = RentalDB.getRentalofItem("ITM000000001", "On-going");
            return itemRental[0].EndDate.ToString();
            
        }
        else
        {
            return itemExtension.NewEndDate.ToString();
        }
    }
}