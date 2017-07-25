using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewFeedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }

        if (Request["rentid"] == null)
        { 

            Response.Redirect("RentalHistory.aspx");
            return;
        }



        List<Rental> rentalInfoDetails = new List<Rental>();
        Rental rentalInfo = RentalDB.getRentalbyID((Request["rentid"].ToString()));

        rentalInfoDetails.Add(rentalInfo);

        rptInfo.DataSource = rentalInfoDetails;
        rptInfo.DataBind();


        List<Feedback> feedbackInfo = new List<Feedback>();
        feedbackInfo.Add(FeedbackDB.getFeedbackforRental(Request["rentid"].ToString()));
        
        rptFeedbackInfo.DataSource = feedbackInfo;
        rptFeedbackInfo.DataBind();


        Feedback feed = FeedbackDB.getFeedbackforRental(Request["rentid"].ToString());
        if (feed.FeedbackID != null)
        {
            if (feed.Rating == "Positive")
                rbtnPositive.Checked = true;
            else if (feed.Rating == "Neutral")
                rbtnNeutral.Checked = true;
            else if (feed.Rating == "Negative")
                rbtnNegative.Checked = true;

            if (feed.ReplyFeedback != null)
            {
                txtArea.Visible = false;
                btnSubmit.Visible = false;
                setFeedbackControls(false);

            }
            else if (feed.Rental.Rentee.Email == Session["user"].ToString())
            {
                txtArea.Visible = false;
                btnSubmit.Visible = false;

            }
            
        }
        else
        {
            setFeedbackControls(true);
            btnSubmit.Enabled = true;
        }


    }

    protected string retrieveMessage(string submittedBy, string feedbackTo, string comments, string replyFeedback, string datePosted, string rating)
    {
        if (replyFeedback != "")
        {
            if (rating == "Positive")
            {
                return " <div class='col-sm-12'>  \n " +
                    " <div class='feature-box well'> <i class='feature-icon fa fa-smile-o'  style='color:green'></i> \n " +
                    " <div class='feature-content'> \n " +
                    " <p> " +
                    comments +
                    " </p> \n " +
                    " <a href=''><i> - " + MemberDB.getMemberbyID( submittedBy).Name + "</i></a> \n " +
                    " </div>	 \n " +
                    " </div> \n " +
                    " </div> \n " +

                    " <div class='col-sm-12'>  \n " +
                    " <div class='feature-box well'> <i class='feature-icon fa fa-mail-forward' '></i> \n " +
                    " <div class='feature-content'> \n " +
                    " <p> " +
                    replyFeedback +
                    " </p> \n " +
                    " <a href=''><i> - " + MemberDB.getMemberbyID(feedbackTo).Name + "</i></a> \n " +
                    " </div>	 \n " +
                    " </div> \n " +
                    " </div> \n ";
            }
            else if (rating == "Negative")
            {
                return " <div class='col-sm-12'>  \n " +
                    " <div class='feature-box well'> <i class='feature-icon fa fa-frown-o'  style='color:red'></i> \n " +
                    " <div class='feature-content'> \n " +
                    " <p> " +
                    comments +
                    " </p> \n " +
                    " <a href=''><i> - " + MemberDB.getMemberbyID(submittedBy).Name + "</i></a> \n " +
                    " </div>	 \n " +
                    " </div> \n " +
                    " </div> \n " +

                    " <div class='col-sm-12'>  \n " +
                    " <div class='feature-box well'> <i class='feature-icon fa fa-mail-forward' '></i> \n " +
                    " <div class='feature-content'> \n " +
                    " <p> " +
                    replyFeedback +
                    " </p> \n " +
                    " <a href=''><i> - " + MemberDB.getMemberbyID(feedbackTo).Name + "</i></a> \n " +
                    " </div>	 \n " +
                    " </div> \n " +
                    " </div> \n ";

            }
            else
            {
                return " <div class='col-sm-12'>  \n " +
                    " <div class='feature-box well'> <i class='feature-icon fa fa-meh-o' '></i> \n " +
                    " <div class='feature-content'> \n " +
                    " <p> " +
                    comments +
                    " </p> \n " +
                    " <a href=''><i> - " + MemberDB.getMemberbyID(submittedBy).Name + "</i></a> \n " +
                    " </div>	 \n " +
                    " </div> \n " +
                    " </div> \n " +
                    " <div class='col-sm-12'>  \n " +
                    " <div class='feature-box well'> <i class='feature-icon fa fa-mail-forward' '></i> \n " +
                    " <div class='feature-content'> \n " +
                    " <p> " +
                    replyFeedback +
                    " </p> \n " +
                    " <a href=''><i> - " + MemberDB.getMemberbyID(feedbackTo).Name + "</i></a> \n " +
                    " </div>	 \n " +
                    " </div> \n " +
                    " </div> \n ";
            }
        }
        else
        {
            if (rating == "Positive")
            {
                return " <div class='col-sm-12'>  \n " +
                    " <div class='feature-box well'> <i class='feature-icon fa fa-smile-o'  style='color:green'></i> \n " +
                    " <div class='feature-content'> \n " +
                    " <p> " +
                    comments +
                    " </p> \n " +
                    " <a href=''><i> - " + MemberDB.getMemberbyID(submittedBy).Name + "</i></a> \n " +
                    " </div>	 \n " +
                    " </div> \n " +
                    " </div> \n ";
            }
            else if (rating == "Negative")
            {
                return " <div class='col-sm-12'>  \n " +
                    " <div class='feature-box well'> <i class='feature-icon fa fa-frown-o'  style='color:red'></i> \n " +
                    " <div class='feature-content'> \n " +
                    " <p> " +
                    comments +
                    " </p> \n " +
                    " <a href=''><i> - " + MemberDB.getMemberbyID(submittedBy).Name + "</i></a> \n " +
                    " </div>	 \n " +
                    " </div> \n " +
                    " </div> \n ";

            }
            else
            {
                return " <div class='col-sm-12'>  \n " +
                    " <div class='feature-box well'> <i class='feature-icon fa fa-meh-o' '></i> \n " +
                    " <div class='feature-content'> \n " +
                    " <p> " +
                    comments +
                    " </p> \n " +
                    " <a href=''><i> - " + MemberDB.getMemberbyID(submittedBy).Name + "</i></a> \n " +
                    " </div>	 \n " +
                    " </div> \n " +
                    " </div> \n ";
            }
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtArea.InnerText == "" || (!rbtnNegative.Checked && !rbtnNeutral.Checked && !rbtnPositive.Checked))
            return;

        if (txtArea.InnerText.Length > 255)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your message cannot exceed 255 characters!')", true);
            return;
        }

        Feedback feed = FeedbackDB.getFeedbackforRental(Request["rentid"].ToString());

        if (feed.FeedbackID != null)
        {
            if (feed.ReplyFeedback != null || feed.Rental.Rentee.Email == Session["user"].ToString())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Form resubmission is not allowed')", true);
                setFeedbackControls(true);
                txtArea.Visible = false;
                btnSubmit.Visible = false;
            }
            else
            {
                feed.ReplyFeedback = txtArea.InnerText;
                FeedbackDB.setReplyforFeedback(feed);

                btnSubmit.Visible = false;
                txtArea.InnerText = "";
                txtArea.Visible = false;
                   
            }

        }
        else
        {
            feed.Comments = txtArea.InnerText;
            feed.Date = DateTime.Now;

            if (rbtnPositive.Checked)
                feed.Rating = "Positive";
            else if (rbtnNeutral.Checked)
                feed.Rating = "Neutral";
            else if (rbtnNegative.Checked)
                feed.Rating = "Negative";

            feed.Rental = RentalDB.getRentalbyID(Request["rentid"].ToString());
            feed.SubmittedBy = feed.Rental.Rentee;
            feed.FeedbackTo = feed.Rental.Item.Renter;
            feed.ReplyFeedback = null;

            FeedbackDB.addFeedback(feed);

            txtArea.InnerText = "";
            txtArea.Visible = false;


            btnSubmit.Visible = false;

            setFeedbackControls(true);
        }

        Response.Redirect(Request.RawUrl);
    }

    private void setFeedbackControls(bool settings)
    {

        pnlSetControl.Visible = settings;


    }



}