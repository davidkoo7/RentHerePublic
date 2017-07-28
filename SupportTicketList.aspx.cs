using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SupportTicketList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check if logged in 
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx"); // redirect to login page if not logge din 
            return;
        }

        // view support ticket submitted if any
        lsvTicketView.DataSource = SupportTicketDB.getTicketByUser(MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID);
        lsvTicketView.DataBind();

        //if (getRentalofThisMember().Count < 1)
        //    DataPager1.Visible = false;
        //else
        //    DataPager1.Visible = true;

    }
}