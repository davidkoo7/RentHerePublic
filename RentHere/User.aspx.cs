using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["user"] = "merandson@gmail.com";

        repeaterItemList.DataSource = ItemDB.getAllItemofMember(MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID);
        repeaterItemList.DataBind();

    }
}