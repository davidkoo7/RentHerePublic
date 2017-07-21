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
}