using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
            Response.Redirect("Default.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (MemberDB.isPermittedLogin(tbxEmail.Value, tbxPassword.Value))
        {
            Session["user"] = tbxEmail.Value;
            if (Session["pageRedirectAfterLogin"].ToString() == "")
                Response.Redirect("Default.aspx");
            else
            {
                Response.Redirect("~" + Session["pageRedirectAfterLogin"].ToString());
                Session["pageRedirectAfterLogin"] = "";
            }
        }
    }

}