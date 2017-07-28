using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewSupportTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check if user is logged in 
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx"); // not logged in, go to login page
            return;
        }

        if (Request.QueryString["ticketID"] == null) // check if ticket is selected
        {
            Response.Redirect("~/SupportTicketList.aspx"); // if not selected, go back to list
        }
        else
        {
            List<SupportTicket> ticketInfo = new List<SupportTicket>();
            ticketInfo.Add(SupportTicketDB.getSupportTicketbyID(Request.QueryString["ticketID"]));
            rptInfo.DataSource = ticketInfo;
            rptInfo.DataBind();

            if (ticketInfo[0].Status == "Closed")
            {
                btnSubmit.Visible = false;
                txtMsg.Visible = false;
                lblMessages.Visible = false;
                
            }

            // display messages for support ticket
            List<MessageSupportTicket> supportTicketMsg = MessageSupportTicketDB.getMessage(SupportTicketDB.getSupportTicketbyID(Request.QueryString["ticketID"].ToString()));
            rptMessages.DataSource = supportTicketMsg;
            rptMessages.DataBind();
        }

    }

    //display messages in corect format
    protected string retrieveMessage(string memberID, string staffID, string reply, string datePosted)
    {
        if (MemberDB.getMemberbyID(memberID).Email == Session["user"].ToString())
        {
            return "<li class='clearfix'>" +
                "<div class='message-data'>\n" +
                    "<span class='message-data-name'><i class='fa fa-circle you'></i> " + MemberDB.getMemberbyID(memberID).Name + " - "  + Convert.ToString(datePosted) + " </span>\n" +
                    "</div>\n" +
                    "<div class='message you-message'>\n" +
                    reply + "<li class='clearfix'>\n";
        }
        else
        {
            return " <li class='clearfix'>" +
                  "<div class='message-data align-right'>\n" +
                    "      <span class='message-data-name'> (Staff) " + StaffDB.getStaffbyID(staffID).Name + " - " + Convert.ToString(datePosted) + "</span> <i class='fa fa-circle me'></i>\n" +
                    "    </div>\n" +
                    "    <div class='message me-message float-right'> " + reply + " </div>\n" +
                    "  </li>\n";

        }
    }

    // insert support ticket into database 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        MessageSupportTicketDB.insertMemberMessage(txtMsg.InnerText,DateTime.Now,SupportTicketDB.getSupportTicketbyID(Request.QueryString["ticketID"]), MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID);

        Response.Redirect(Request.RawUrl);
    }
}