using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateSupportTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check if user is logged in 
        if (Session["user"] == null) // not logged in transfer to login page
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }
    }

    // adds support ticket to database
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int ticketIdentity = SupportTicketDB.insertTicket(tbxTitle.Text, txtArea.InnerText, DateTime.Now, "Pending", ddlUrgency.SelectedValue, MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID);


        string ticketID = "TIC";
        for(int x=0; x<9- ticketIdentity.ToString().Length; x++)
        {
            ticketID += "0";
        }
        ticketID += ticketIdentity.ToString();

        MessageSupportTicketDB.insertMemberMessage(txtArea.InnerText, DateTime.Now, SupportTicketDB.getSupportTicketbyID(ticketID), MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID);
        Response.Redirect("ViewSupportTicket.aspx?ticketID=" + ticketID);


    }

}