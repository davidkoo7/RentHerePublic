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
            if (Session["pageRedirectAfterLogin"] == null)
                Response.Redirect("Default.aspx");

            else
            {
                Response.Redirect("~" + Session["pageRedirectAfterLogin"].ToString());
                Session["pageRedirectAfterLogin"] = null ;
            }
        }
        else
        {
            pnlOutput.Visible = true;
            lblOutput.Text = "Incorrect username or password";
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string newPassword = Utility.getRandomizedChar(7, 1);

        string message = "This is message is to inform you on your auto-generated password: " + newPassword;
        message += "\nDo not reply.\n Regards, RentHere Team";

        Utility.sendEmail(tbxEmail.Value, "Your Password Reset is Here", message);

        pnlForgotPasswordOutput.Visible = true;
        lblForgotEmailOutput.Text = "Your password reset has been sent to your email";

        MemberDB.changeMemberPassword(tbxEmail.Value, newPassword);

        Session["password"] = " ";

        Response.Redirect(Request.RawUrl);
    }
}