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
        List<Item> itemList = ItemDB.getAllItem();
        repeaterItemList.DataSource = itemList;
        repeaterItemList.DataBind();

    }
}