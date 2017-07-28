using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            if (Session["user"] == null)
            {
                pnlBeforeLogin.Visible = true;
            }
            else
            {
                pnlAfterLogin.Visible = true;
                string[] fullName = MemberDB.getMemberbyEmail(Session["user"].ToString()).Name.Split(' ');

                lblUsername.Text = " " + fullName[0];


            }

            ddlCategory.DataSource = CategoryDB.getAllCategory();
            ddlCategory.DataBind();

            ddlLocation.DataSource = LocationDB.getAllLocation();
            ddlLocation.DataBind();

            ddlLocation.Items.Insert(0, new ListItem("Singapore", ""));

            
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //string ss = ddlCategory.Value;
        string location = null, category = null;


        List<Item> itemList = new List<Item>();

        if (tbxSearch.Value.IndexOf("#") >= 0)
        {
            List<string> tags = Utility.findHashTags(tbxSearch.Value);

            List<ItemTag> itemTagList = new List<ItemTag>();

            //if (ddlCategory.SelectedIndex > 0)
            //    category = ddlCategory.SelectedValue;

            //if (ddlLocation.SelectedIndex > 0)
            //    location = ddlLocation.SelectedValue;

            //itemTagList = ItemTagDB.getItemsWithTags(tags, location, category);

            if (ddlCategory.SelectedIndex > 0)
                category = ddlCategory.SelectedValue;

            if (ddlLocation.SelectedIndex > 0)
                location = ddlLocation.SelectedValue;

            itemTagList = ItemTagDB.getItemsWithTags(tags, location, category);

            foreach (ItemTag it in itemTagList)
                itemList.Add(it.Item);
        }
        else
        {
            if (ddlCategory.SelectedIndex > 0)
                category = ddlCategory.SelectedValue;

            if (ddlLocation.SelectedIndex > 0)
                location = ddlLocation.SelectedValue;

            itemList = ItemDB.searchItembyName(tbxSearch.Value, location, category);
        }

        Session["SearchListToDisplay"] = itemList;
        Response.Redirect("~/Categories.aspx");
    }



    protected void lbLogout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Response.Redirect("Default.aspx");
    }

}
