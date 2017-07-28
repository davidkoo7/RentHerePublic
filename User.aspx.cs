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

        // check if logged in
        if (Request.QueryString["memberID"] == null)
        {
            Response.Redirect("Default.aspx"); // redirect to default if not logged in 
            return;
        }
        // display items listed by member
        repeaterItemList.DataSource = ItemDB.getAllItemofMember(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()).MemberID);
        repeaterItemList.DataBind();

        // display feedback by member
        rptFeedbackInfo.DataSource = FeedbackDB.getFeedbackFor(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()).MemberID);
        rptFeedbackInfo.DataBind();

        // display memebr information
        List<Member> memInfo = new List<Member>();
        memInfo.Add(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()));

        rptMemberInfo.DataSource = memInfo;
        rptMemberInfo.DataBind();
    }

    // check if member is verified 
    public string isVerifiedOrNot(string memberID)
    {
        if (MemberDB.getMemberbyID(memberID).DateVerified == new DateTime())
            return "Unverified";
        else
            return "Verified";
    }




    protected void btnReport_Click(object sender, EventArgs e)
    {

    }

    protected void rptFeedbackInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {


    }
}