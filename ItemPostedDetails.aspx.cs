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
        Item itemInfo = ItemDB.getItembyID(("ITM000000003"));

        itemInfoDetails.Add(itemInfo);

        rptInfo.DataSource = itemInfoDetails;
        rptInfo.DataBind();

        List<Rental> itemRental = RentalDB.getRentalofItem("ITM000000003", null);

        rptRentalHistory.DataSource = itemRental;
        rptRentalHistory.DataBind();
    }


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