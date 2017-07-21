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
        Session["user"] = "merandson@gmail.com";

        lsvTicketView.DataSource = SupportTicketDB.getTicketByUser(MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID);
        lsvTicketView.DataBind();

        //if (getRentalofThisMember().Count < 1)
        //    DataPager1.Visible = false;
        //else
        //    DataPager1.Visible = true;

    }
}