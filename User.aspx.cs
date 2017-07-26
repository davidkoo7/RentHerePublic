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
        Session["user"] = "merandson@gmail.com";

        repeaterItemList.DataSource = ItemDB.getAllItemofMember(MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID);
        repeaterItemList.DataBind();

        rptFeedbackInfo.DataSource = FeedbackDB.getFeedbackFor(MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID);
        rptFeedbackInfo.DataBind();

        List<Member> memInfo = new List<Member>();
        memInfo.Add(MemberDB.getMemberbyEmail(Session["user"].ToString()));

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

    protected void btnContact_Click(object sender, EventArgs e)
    {

    }


    protected void btnReport_Click(object sender, EventArgs e)
    {

    }

    protected void rptFeedbackInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {


    }
}