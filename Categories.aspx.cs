using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // checks if there is anything searched
        if (Session["SearchListToDisplay"] != null)
        {
            // display searched items
            List<Item> itemList = new List<Item>();

            itemList = (List<Item>)Session["SearchListToDisplay"];
            repeaterItemList.DataSource = itemList;
            repeaterItemList.DataBind();

            Session["SearchListToDisplay"] = null;


        }
        else if(Request.QueryString["categoryName"] != null)
        {
            //get items by category
            List<Item> itemList = new List<Item>();

            itemList = ItemDB.getAllItemByCategory(Request.QueryString["categoryName"]);
            repeaterItemList.DataSource = itemList;
            repeaterItemList.DataBind();
        }
        else // nothing selected or searched
        {
            // display all items

            List<Item> itemList = ItemDB.getAllItem();
            repeaterItemList.DataSource = itemList;
            repeaterItemList.DataBind();
        }


    }
}