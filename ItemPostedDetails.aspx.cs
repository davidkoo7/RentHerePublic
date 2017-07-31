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
        if (Session["user"] == null) // user not logged in 
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx"); // transfer to login page
            return;
        }

        if (Request.QueryString["itemID"] == null)
        {
            Response.Redirect("itemPosted.aspx"); 
            return;
        }

        //display item details
        if (ItemDB.isItemofRenterPresent(Request.QueryString["itemID"].ToString(), MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID))
        {
            List<Item> itemInfoDetails = new List<Item>();
            Item itemInfo = ItemDB.getItembyID((Request.QueryString["itemID"].ToString()));

            itemInfoDetails.Add(itemInfo);

            rptInfo.DataSource = itemInfoDetails;
            rptInfo.DataBind();

            List<Rental> itemRental = RentalDB.getRentalofItem(Request.QueryString["itemID"].ToString(), null);

            rptRentalHistory.DataSource = itemRental;
            rptRentalHistory.DataBind();
        } else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Inaccessible Page!')", true);
        }
    }
}