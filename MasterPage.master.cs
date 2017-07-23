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
        List<Item> itemList = new List<Item>();
        if (tbxSearch.Value.IndexOf("#") >= 0)
        {

            List<string> tags = Utility.findHashTags(tbxSearch.Value);            

            List<ItemTag> itemTagList = new List<ItemTag>();

            //if (ddlLocation.SelectedIndex > 0 && ddlCategory.SelectedIndex > 0)
            //{
            //    itemTagList = ItemTagDB.getItemsWithTags(tags, ddlLocation.SelectedValue, ddlCategory.SelectedValue);
            //}
            //else if (ddlLocation.SelectedIndex > 0)
            //{
            //    itemTagList = ItemTagDB.getItemsWithTags(tags, ddlLocation.SelectedValue, null);
            //}
            //else if (ddlCategory.SelectedIndex > 0)
            //{
            //    itemTagList = ItemTagDB.getItemsWithTags(tags, null, ddlCategory.SelectedValue);

            //}
            //else
            //{
            //    itemTagList = ItemTagDB.getItemsWithTags(tags, null, null);
            //}

            if (ddlLocation.SelectedIndex > 0 && ddlCategory.SelectedIndex > 0)
            {
                itemTagList = ItemTagDB.getItemsWithTagsLike(tags, ddlLocation.SelectedValue, ddlCategory.SelectedValue);
            }
            else if (ddlLocation.SelectedIndex > 0)
            {
                itemTagList = ItemTagDB.getItemsWithTagsLike(tags, ddlLocation.SelectedValue, null);
            }
            else if (ddlCategory.SelectedIndex > 0)
            {
                itemTagList = ItemTagDB.getItemsWithTagsLike(tags, null, ddlCategory.SelectedValue);

            }
            else
            {
                itemTagList = ItemTagDB.getItemsWithTagsLike(tags, null, null);
            }

            foreach (ItemTag it in itemTagList)
                itemList.Add(it.Item);

            Session["SearchListToDisplay"] = itemList;
            Response.Redirect("~/Categories.aspx");
        }
        else
        {
            itemList = ItemDB.searchItembyName(tbxSearch.Value);
            Session["SearchListToDisplay"] = itemList;
            Response.Redirect("~/Categories.aspx");
        }
    }

}
