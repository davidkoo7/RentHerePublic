using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ICVerification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check if user is logged in
        if (Session["user"] == null) // user is not logged in 
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl; 
            Response.Redirect("Login.aspx"); // transfer to login page
            return;
        }

        // new DateTime means NULL in the DB
        if(MemberDB.getMemberbyEmail(Session["user"].ToString()).DateVerified != new DateTime() || MemberDB.getMemberbyEmail(Session["user"].ToString()).IdentificationPicture != "")
        {
            Response.Redirect("Categories.aspx");
            return;
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // submit IC verification 
        if (flIdentificationPicture.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(flIdentificationPicture.FileName);
                flIdentificationPicture.SaveAs(Server.MapPath("~/image/icpicture/") + filename);
                MemberDB.updateICVerification(MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID, tbxIdentificationNumber.Value, flIdentificationPicture.FileName);

            }
            catch (Exception ex)
            {

            }
        }

    }

}