using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    	// check if user is logged in 
        if (Session["user"] == null) // not logged in transfer to login page
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }


        ddlMRTLocation.DataTextField = "name";
        ddlMRTLocation.DataValueField = "name";
        ddlMRTLocation.DataSource = LocationDB.getAllLocation();
        ddlMRTLocation.DataBind();

    }

    // adds item to database
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Item newItem = new Item();

        newItem.Name = tbxItemName.Text;
        newItem.CategoryName = CategoryDB.getCategorybyName("Services");
        newItem.Deposit = Convert.ToDecimal(tbxRefundableDeposit.Text);
        newItem.Location = LocationDB.getLocationbyID(ddlMRTLocation.SelectedValue);
        newItem.PricePerDay = Convert.ToDecimal(tbxPricePerDay.Text);
        newItem.PricePerWeek = Convert.ToDecimal(tbxPricePerWeek.Text);
        newItem.PricePerMonth = Convert.ToDecimal(tbxPricePerMonth.Text);
        newItem.Renter = MemberDB.getMemberbyEmail(Session["user"].ToString());
        newItem.Description = tbxDescription.InnerText;
        newItem.PostedDate = DateTime.Now;
        newItem.ItemID = Utility.convertIdentitytoPK("ITM", ItemDB.addItem(newItem));

        List<string> tags = Utility.findHashTags(tbxDescription.InnerText);

        if (tags.Count > 0)
        {
            foreach (string t in tags)
            {
                if (!TagDB.isTagPresent(t))
                    TagDB.addTag(t);

                ItemTagDB.addItemTag(newItem, t);
            }
        }
        Response.Redirect(Request.RawUrl);
    }
}