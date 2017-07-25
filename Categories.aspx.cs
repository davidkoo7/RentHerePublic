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
        if (Session["SearchListToDisplay"] != null)
        {
            List<Item> itemList = new List<Item>();

            itemList = (List<Item>)Session["SearchListToDisplay"];
            repeaterItemList.DataSource = itemList;
            repeaterItemList.DataBind();

            Session["SearchListToDisplay"] = null;


        }
        else if(Request.QueryString["categoryName"] != null)
        {
            List<Item> itemList = new List<Item>();

            itemList = ItemDB.getAllItemByCategory(Request.QueryString["categoryName"]);
            repeaterItemList.DataSource = itemList;
            repeaterItemList.DataBind();
        }
        else
        {

            List<Item> itemList = ItemDB.getAllItem();
            repeaterItemList.DataSource = itemList;
            repeaterItemList.DataBind();
        }


    }
}