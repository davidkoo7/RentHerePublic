using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisputePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }

        Session["user"] = "merandson@gmail.com";

        Dispute dis = DisputeDB.getDisputeforRental("RNT000000001");

        if (dis.DisputeID != null)
        {
            ddlReason.SelectedValue = dis.Reason;
            ddlReason.Enabled = false;

            if (MemberDB.getMemberbyID(dis.SubmittedBy.MemberID).Email == Session["user"].ToString())
                btnResolve.Visible = true;

            if (dis.Status == "Resolved")
            {
                btnResolve.Enabled = false;
                tbxMessage.Enabled = false;
                btnSubmit.Enabled = false;
            }

            rptMessages.DataSource = MessageDisputeDB.getMsgforDispute(dis.DisputeID);
            rptMessages.DataBind();
        }
        else
        {
            if (RentalDB.getRentalbyID("RNT000000002").Rentee.Email == Session["user"].ToString())
            {
                for (int x = 1; x < 5; x++)
                {
                    ddlReason.Items[x].Enabled = false;
                }
            }
            else if (RentalDB.getRentalbyID("RNT000000002").Item.Renter.Email == Session["user"].ToString())
            {
                for (int x = 1; x < ddlReason.Items.Count ; x++)
                {
                    ddlReason.Items[x].Enabled = false; 
                }
            }
        }
    }

    protected string writeMsgSender(string memberID, string staffID)
    {
        if (staffID == "")
        {
            if (MemberDB.getMemberbyID(memberID).Email == Session["user"].ToString())
                return "You";
            else return MemberDB.getMemberbyID(memberID).Name;
        }
        else
        {
            return StaffDB.getStaffbyID(staffID).Name + " (admin)";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (tbxMessage.Text.Length > 255)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your message cannot exceed 255 characters!')", true);
            return;
        }
        Dispute dis = DisputeDB.getDisputeforRental("RNT000000002");



        if (dis.Status == "Resolved")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your page has expired since your disputer has closed the case')", true);
            rptMessages.DataBind();
            setChatControls(false);
            tbxMessage.Text = "";
            return;
        }

        if (tbxMessage.Text != "")
        {
            if (dis.DisputeID == null)
            {
                if (ddlReason.SelectedValue != "")
                {
                    dis = new Dispute();
                    dis.Reason = ddlReason.SelectedItem.Value;
                    dis.Date = DateTime.Now;
                    dis.Rental = RentalDB.getRentalbyID("RNT000000002");
                    dis.Status = "Pending";
                    dis.SubmittedBy = MemberDB.getMemberbyEmail(Session["user"].ToString());
                    DisputeDB.addDispute(dis);

                    ddlReason.Enabled = false;
                }
                else
                    return;
            }

            dis = DisputeDB.getDisputeforRental("RNT000000002");

            MessageDispute msgDis = new MessageDispute();

            msgDis.Date = DateTime.Now;
            msgDis.Dispute = dis;
            msgDis.Member = MemberDB.getMemberbyEmail(Session["user"].ToString());
            msgDis.Staff = new Staff(null, null, null, null, 0, null, new DateTime());

            msgDis.Reply = tbxMessage.Text;
            MessageDisputeDB.addMsgDispute(msgDis);

            tbxMessage.Text = "";

            rptMessages.DataSource = MessageDisputeDB.getMsgforDispute(dis.DisputeID);
            rptMessages.DataBind();
        }
    }

    protected void btnResolve_Click(object sender, EventArgs e)
    {
        Dispute dis = DisputeDB.getDisputeforRental(Request["rentid"].ToString());

        if (dis.Status == "Resolved")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your page has expired since your disputer has closed the case')", true);
            rptMessages.DataBind();
            setChatControls(false);
            tbxMessage.Text = "";
            return;
        }

        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "confirmMessage", "confirm('You are about to close the dispute case. As the action is irreversible, are you sure?')", true);
        DisputeDB.resolveDispute(dis.DisputeID);

        MessageDispute msgDis = new MessageDispute();

        msgDis.Date = DateTime.Now;
        msgDis.Dispute = dis;
        msgDis.Member = MemberDB.getMemberbyEmail(Session["user"].ToString());
        msgDis.Staff = new Staff(null, null, null, null, 0, null, new DateTime());

        msgDis.Reply = "==============The Dispute has been closed================";

        MessageDisputeDB.addMsgDispute(msgDis);

        setChatControls(false);

    }

    private void setChatControls(bool isEnabled)
    {
        btnResolve.Enabled = isEnabled;
        tbxMessage.Enabled = isEnabled;
        btnSubmit.Enabled = isEnabled;
    }

    protected string retrieveMessage(string memberID, string staffID, string reply, string datePosted)
    {
        if (MemberDB.getMemberbyID(memberID).Email == Session["user"].ToString())
        {
            return "<li class='clearfix'>" +
                "<div class='message-data'>\n" +
                    "<span class='message-data-name'><i class='fa fa-circle you'></i> You - " + Convert.ToString(datePosted) + " </span>\n" +
                    "</div>\n" +
                    "<div class='message you-message'>\n" +
                    reply + "<li class='clearfix'>\n";
        }
        else 
        {
            return " <li class='clearfix'>" +
                  "<div class='message-data align-right'>\n" +
                    "      <span class='message-data-name'>" + MemberDB.getMemberbyID(memberID).Name + " - " + Convert.ToString(datePosted) + "</span> <i class='fa fa-circle me'></i>\n" +
                    "    </div>\n" +
                    "    <div class='message me-message float-right'> " + reply + " </div>\n" +
                    "  </li>\n";

        }
    }
}