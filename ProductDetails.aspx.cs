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


        if (Request.QueryString["itemID"] == null) // no item selected,
        {
            Response.Redirect("~/Categories.aspx");  // redirect to categories page
        }
        else
        { // get and display item details

            List<Item> productDetails = new List<Item>();
            productDetails.Add(ItemDB.getItembyID(Request.QueryString["itemID"].ToString()));


            repeaterItemInformation.DataSource = productDetails;
            repeaterItemInformation.DataBind();

        }
    }

    protected void repeaterItemInformation_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // check if there is on going rental extenson for item selected
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
            // allow renting if no extension, allow reserve if there is 
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
        Item item = ItemDB.getItembyID(Request.QueryString["itemID"].ToString());

        // check if logged in 
        if (Session["user"] == null) // user not logged in 
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx"); // transfer to login page 
            return;
        }

        if (item.Renter.Email == Session["user"].ToString())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cannot rent your own item!')", true);

            return;
        }

        // insert rent record into database for item selected

        Session["itemExtension"] = "NotExtension";


        if (item.Renter.Email == Session["user"].ToString())
        {
            return;
        }


        if (itemStatus == "Available")
        {
            Session["itemStatus"] = "Available";
            Response.Redirect("~/itemRental.aspx?itemID=" + Request.QueryString["itemID"]);
        }
        else if (itemStatus == "On-going")
        {
            Session["itemStatus"] = "On-going";
            Response.Redirect("~/itemRental.aspx?itemID=" + Request.QueryString["itemID"]);
        }
        else
        {
            Session["itemStatus"] = "On-Going Extension";
            Response.Redirect("~/itemRental.aspx?itemID=" + Request.QueryString["itemID"]);

        }



    }

    protected void btnRenterProfile_Click(object sender, EventArgs e)
    {
        // Redirect to renter's profile page
        Item itemInfo = ItemDB.getItembyID(Request.QueryString["itemID"].ToString());
        Response.Redirect("~/User.aspx?memberID=" + MemberDB.getMemberbyID(ItemDB.getItembyID(Request.QueryString["itemID"].ToString()).Renter.MemberID).MemberID);
    }


    protected void btnContactRenter_Click(object sender, EventArgs e)
    {
        // check if logged in 
        if (Session["user"] == null) // user not logged in 
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx"); // transfer to login page 
            return;
        }

        // allow Rentee to contact Renter
        Item item = ItemDB.getItembyID(Request.QueryString["itemID"].ToString());

        if (item.Renter.Email == Session["user"].ToString())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Cannot message yourself!')", true);

            return;
        }
        // must be logged in to contact Renter
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }
        else
        {
            // If memberInbox doesnt exist
            if (MemberInboxDB.searchMemberInbox(MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID, ItemDB.getItembyID(Request.QueryString["itemID"].ToString()).ItemID).MemberInboxID == -1)
            { // creates and send message
                MemberInbox mem = new MemberInbox();
                mem.Date = DateTime.Now;
                mem.Item = ItemDB.getItembyID(Request.QueryString["itemID"]);
                mem.Sender = MemberDB.getMemberbyEmail(Session["user"].ToString());

                int memberInboxID = MemberInboxDB.AddMsgMember(mem);
                Response.Redirect("/inboxMessage.aspx?memberInboxID=" + memberInboxID);
            }

            else
            {

                Response.Redirect("/inboxMessage.aspx?memberInboxID=" + MemberInboxDB.searchMemberInbox(MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID, ItemDB.getItembyID(Request.QueryString["itemID"].ToString()).ItemID).MemberInboxID);
            }


        }
    }

}