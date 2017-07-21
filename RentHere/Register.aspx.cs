using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


public partial class Register : System.Web.UI.Page
{
    string otp;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] != null)
        {
            Response.Redirect("Default.aspx");
        }

    }

    protected void btnVerifyPhone_Click(object sender, EventArgs e)
    {
        pnlPhone.Visible = true;
        btnVerifyPhone.Enabled = false;

        // Your Account SID from twilio.com/console
        var accountSid = "AC6df3f3bb4adeee93cdbc734e56757194";
        // Your Auth Token from twilio.com/console
        var authToken = "268d599703a742f5a70d22e28ad3e2ab";

        TwilioClient.Init(accountSid, authToken);

        if (tbxPhone.Value == "")
        {
            pnlMessageOutput.Visible = true;
            lblOutput.Text = "Please insert phone number.";
        }
        else if (MemberDB.getMemberbyPhone(tbxPhone.Value).Email != null)
        {
            pnlMessageOutput.Visible = true;
            lblOutput.Text = "Phone number exists.";
        }
        else
        {
            string num = "0123456789";
            int len = num.Length;
            otp = string.Empty;

            //digits
            int otpdigit = 5;
            string finaldigit;
            int getindex;
            for (int i = 0; i < otpdigit; i++)
            {
                do
                {
                    getindex = new Random().Next(0, len);
                    finaldigit = num.ToCharArray()[getindex].ToString();

                } while (otp.IndexOf(finaldigit) != -1);
                otp += finaldigit;

            }

            var message = MessageResource.Create(
            to: new PhoneNumber("+65" + tbxPhone.Value),
            from: new PhoneNumber("+12566678209"),
            body: otp + " is your RentHere OTP.");

            Session["OTP"] = otp;
          

        }


    }
    

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string gender;

        if (rbtnMale.Checked)
            gender = "Male";
        else
            gender = "Female";

        if (MemberDB.getMemberbyEmail(tbxEmail.Value).Email != null)
        {
            pnlMessageOutput.Visible = true;
            lblOutput.Text = "Please Enter a Different Email";
        }

        else if (Session["OTP"].ToString() == "Verified")
        {
            MemberDB.addMember(new Member("NULL", tbxFullName.Value, tbxAddress.Value, Convert.ToInt32(tbxPostCode.Value), tbxPasswordConfirm.Value, tbxEmail.Value, Convert.ToInt32(tbxPhone.Value), "NULL", "NULL", DateTime.Now, new DateTime(), gender, Convert.ToDateTime(tbxDOB.Value), "Active", "NULL"));
        }
        else
        {
            pnlMessageOutput.Visible = true;
            lblOutput.Text = "Please verify your phone number.";

        }
    }

    protected void btnSubmitOTP_Click(object sender, EventArgs e)
    {
        if (tbxOTP.Value != Session["OTP"].ToString())
        {
            pnlMessageOutput.Visible = true;
            lblOutput.Text = "Incorrect OTP.";
        }
        else
        {
            btnVerifyPhone.Enabled = false;
            pnlPhone.Visible = false;
            lblPhoneStatus.Text = "Verified";
            Session["OTP"] = "Verified";
        }
    }

}