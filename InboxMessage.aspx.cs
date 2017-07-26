using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InboxMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }

        if (Request.QueryString["memberInboxID"] == null)
        {
            Response.Redirect("Default.aspx");
            return;
        }

            List<MemberMessage> memberMessageList = MemberMessageDB.getMsgforMember(Request.QueryString["memberInboxID"].ToString());

         rptMessages.DataSource = memberMessageList;
         rptMessages.DataBind();

        List<Item> itemInfo = new List<Item>();
        itemInfo.Add(ItemDB.getItembyID(MemberInboxDB.getMemberInboxID(Request.QueryString["memberInboxID"].ToString()).Item.ItemID ));
        rptItemInfo.DataSource = itemInfo;
        rptItemInfo.DataBind();

    }

    protected string retrieveMessage(string senderID, string reply, string datePosted)
    {
        if (MemberDB.getMemberbyID(senderID).Email == Session["user"].ToString())
        {
            return "<li class='left'>" +
                    "<span class='username'> " + "You" + "</span>\n" +
                    "<small class='timestamp'>" +
                    "<i class='fa fa-clock-o'></i>" + datePosted + "\n " +
                    "</small> \n" +
                    "<span class='avatar available tooltips' data-toggle='tooltip ' data-placement='right' data-original-title='Yanique Robinson'>\n " +
                    "<img src='https://bootdey.com/img/Content/avatar/avatar1.png' alt='avatar' class='img-circle'>\n " +
                    "</span> \n" +
                    "<div class='body'>" +
                    "<div class='message well well-sm'>\n" +
                    reply + "\n" +
                    "</div>\n " +
                    " </div>\n " +
                    " </li> \n";
        }
        else
        {
            return "<li class='right'>\n " +
                     "<span class='username'>" + MemberDB.getMemberbyID(senderID).Name + "</span>\n " +
                     "<small class='timestamp'>\n " +
                    "<i class='fa fa-clock-o'></i>" + datePosted + "\n " +
                     "</small>\n " +
                     "<span class='avatar tooltips' data-toggle='tooltip ' data-placement='left' data-original-title='Kevin Mckoy'>\n " +
                     "<img src='https://bootdey.com/img/Content/avatar/avatar2.png' alt='avatar' class='img-circle'>\n " +
                     "</span>\n " +
                     "<div class='body'>\n " +
                     "<div class='message well well-sm'>\n " +
                     reply + "\n " +
                     "</div>\n " +
                     "</div>\n " +
                     "</li> \n ";

        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (tbxMessage.Text.Length > 255)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your message cannot exceed 255 characters!')", true);
            return;
        }


        if (tbxMessage.Text != "")
        {

            MemberMessage msgDis = new MemberMessage();

            msgDis.Date = DateTime.Now;
            msgDis.Reply = tbxMessage.Text;
            msgDis.Sender = MemberDB.getMemberbyEmail(Session["user"].ToString());
            msgDis.MemberInbox = MemberInboxDB.getMemberInboxID(Request.QueryString["memberInboxID"].ToString());
            //msgDis.Receiver = MemberDB.getMemberbyID(MemberDB.getMemberbyID("MEM000000001").MemberID);
            //msgDis.Item = ItemDB.getItembyID("ITM000000003");

            MemberMessageDB.AddMsgMember(msgDis);
            


            tbxMessage.Text = "";

            rptMessages.DataBind();
            Response.Redirect(Request.RawUrl);

        }
    }

}