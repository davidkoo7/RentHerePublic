using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check if user is logged in 
        if (Session["user"] == null) // not logged in 
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx"); // transfer to login 
            return;
        }
            // get messages by member
        lsvInboxMessage.DataSource = getMessageOfThisMember();
        lsvInboxMessage.DataBind();
            
    }

    private List<MemberInbox> getMessageOfThisMember()
    {
        return MemberInboxDB.getAllMemberInboxByID(MemberDB.getMemberbyEmail(Session["user"].ToString()));
    }

}