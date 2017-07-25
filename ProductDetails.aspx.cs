using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetails : System.Web.UI.Page
{
    string itemStatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["itemID"] == null)
        {
            Server.Transfer("~/Categories.aspx");
        }
        else
        { 

        List<Item> productDetails = new List<Item>();
        productDetails.Add(ItemDB.getItembyID(Request.QueryString["itemID"].ToString()));


        repeaterItemInformation.DataSource = productDetails;
        repeaterItemInformation.DataBind();

        }
    }

    protected void repeaterItemInformation_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Extension itemExtension = ExtensionDB.getLastExtensionofItem(Request.QueryString["itemID"], "On-going");


        if (itemExtension.ExtensionID == null)
        {
            List<Rental> itemRental = RentalDB.getRentalofItem(Request.QueryString["itemID"], "On-going");
            if (itemRental.Count == 0)
            {
                itemStatus = "Available";
                
                
            }
            else
            {
                itemStatus = "On-going";
                // itemRental[0].
            }
        }
        else
        {
            itemStatus = "On-going Extended";   
            // itemExtension.NewEndDate
        }

        // To display the status of the item to the user
        if (e.Item.ItemType == ListItemType.Item)
        {
            Button btnRent = (Button)e.Item.FindControl("btnRent");

            Label lblItemStatus = e.Item.FindControl("lblItemStatus") as Label;
            lblItemStatus.Text = itemStatus;
            if (itemStatus == "On-going" || itemStatus == "On-going Extended")
                btnRent.Text = "Reserve Now";
            else
                btnRent.Text = "Rent Now";
            

        }
    }

    protected void btnRent_Click(object sender, EventArgs e)
    {
        if (itemStatus == "Available")
        {
            Session["itemStatus"] = "Available";
            Response.Redirect("~/itemRental.aspx?itemID=" + Request.QueryString["itemID"]);
        }
        else
        {
            Session["itemStatus"] = "On-Going Extension";
            Response.Redirect("~/itemRental.aspx?itemID=" + Request.QueryString["itemID"]);

        }

    }
}