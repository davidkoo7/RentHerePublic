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


        if (Request.QueryString["memberID"] == null)
        {
            Response.Redirect("Default.aspx");
            return;
        }

        repeaterItemList.DataSource = ItemDB.getAllItemofMember(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()).MemberID);
        repeaterItemList.DataBind();

        rptFeedbackInfo.DataSource = FeedbackDB.getFeedbackFor(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()).MemberID);
        rptFeedbackInfo.DataBind();

        List<Member> memInfo = new List<Member>();
        memInfo.Add(MemberDB.getMemberbyID(Request.QueryString["memberID"].ToString()));

        rptMemberInfo.DataSource = memInfo;
        rptMemberInfo.DataBind();
    }

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