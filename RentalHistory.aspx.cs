using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RentalHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }

        lsvRentView.DataSource = getRentalofThisMember();
        lsvRentView.DataBind();

        if (getRentalofThisMember().Count < 1)
            DataPager1.Visible = false;
        else
            DataPager1.Visible = true;
    }

    public string isRenteeOrRenter(string renteeID, string rentalID)
    {
        Member member = MemberDB.getMemberbyID(renteeID);

        if (member.Email == Convert.ToString(Session["user"]))
            return "Renter:  " + MemberDB.getMemberbyID(ItemDB.getItembyID(RentalDB.getRentalbyID(rentalID).Item.ItemID).Renter.MemberID).Name;
        else
            return "Rentee:  " + RentalDB.getRenteeforRental(rentalID).Name;
    }

    public string isDisputeorDisputed(string rentalID)
    {
        Dispute dis = DisputeDB.getDisputeforRental(rentalID);
        if (dis.DisputeID == null)
            return "Dispute Partner";
        else if (dis.Status == "Resolved")
            return "Dispute Case Resolved";
        else if (MemberDB.getMemberbyID(dis.SubmittedBy.MemberID).Email == Session["user"].ToString())
            return "Continue Dispute Case";
        else
            return "Rental's been Disputed";
    }

    public string isGiveorReceiveFeedback(string rentalID, string renteeID, string rentStatus)
    {
        if (rentStatus != "On-going")
        {
            Feedback feed = FeedbackDB.getFeedbackforRental(rentalID);
            if (feed.FeedbackID != null)
            {
                if (renteeID == MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID)
                    return "Review Feedback";
                else
                    return "Feedback Given";
            }
            else
            {
                if (renteeID == MemberDB.getMemberbyEmail(Session["user"].ToString()).MemberID)
                    return "Give Feedback";
                else
                    return "No Feedback Yet";
            }
        }
        else
            return "";
    }


    protected void lbtnDispute_Click(object sender, EventArgs e)
    {
        ListViewItem item = (ListViewItem)((LinkButton)sender).Parent;
        int itemIndex = item.DisplayIndex;

        int currentRow = DataPager1.StartRowIndex / DataPager1.MaximumRows;
        Rental r = getRentalofThisMember()[DataPager1.PageSize * currentRow + itemIndex];

        Response.Redirect("DisputePage.aspx?rentid=" + r.RentalID);
    }

    //recently added
    protected void lbtnFeedback_Click(object sender, EventArgs e)
    {
        if (((LinkButton)sender).Text == "No Feedback Yet")
            return;

        ListViewItem item = (ListViewItem)((LinkButton)sender).Parent;
        int itemIndex = item.DisplayIndex;

        int currentRow = DataPager1.StartRowIndex / DataPager1.MaximumRows;
        Rental r = getRentalofThisMember()[DataPager1.PageSize * currentRow + itemIndex];

        Response.Redirect("ViewFeedback.aspx?rentid=" + r.RentalID);
    }

    protected void lsvRentView_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        //int currentRow = DataPager1.StartRowIndex / DataPager1.MaximumRows;
        //Rental r = getRentalofThisMember()[DataPager1.PageSize * currentRow + e.NewSelectedIndex];

        //Response.Redirect("Dispute.aspx?rentid=" + r.RentalID);

        ////More to be done here
    }

    protected void lsvRentView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

        lsvRentView.DataSource = getRentalofThisMember();
        lsvRentView.DataBind();
    }

    private List<Rental> getRentalofThisMember()
    {
        return RentalDB.getRentalforMember(MemberDB.getMemberbyEmail(Session["user"].ToString()));
    }
}