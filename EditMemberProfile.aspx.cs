using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditMemberProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }

        Member memberInfo = MemberDB.getMemberbyEmail(Session["user"].ToString());
        lblMemberName.Text = memberInfo.Name;
        tbxFullName.Text = memberInfo.Name;
        tbxEmail.Text = memberInfo.Email;
        tbxAddress.Text = memberInfo.Address;
        tbxDateJoined.Text = memberInfo.DateJoined.ToString();
        tbxStatus.Text = memberInfo.Status;
        tbxMobilePhone.Text = memberInfo.PhoneNumber.ToString();
        tbxPostalCode.Text = memberInfo.PostalCode.ToString();
        tbxDOB.Text = memberInfo.DateOfBirth.ToString();

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        btnEdit.Visible = false;
        btnSubmit.Visible = true;
        isEnabled(true);

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        isEnabled(true);
        btnSubmit.Visible = false;
        btnEdit.Visible = true;
        Member newMemInfo = MemberDB.getMemberbyEmail(Session["user"].ToString());
        newMemInfo.Name = tbxFullName.Text;
        newMemInfo.Address = tbxAddress.Text;
        newMemInfo.PostalCode = Convert.ToInt32(tbxPostalCode.Text);
        MemberDB.updateMemberDetail(newMemInfo);
        isEnabled(false);


    }

    void isEnabled (bool enabled)
    {
        tbxFullName.Enabled = enabled;
        tbxAddress.Enabled = enabled;
        tbxPostalCode.Enabled = enabled;
    }



    protected void btnSubmitNewPassword_Click(object sender, EventArgs e)
    {
        if (tbxCurrentPassword.Value == MemberDB.getMemberbyEmail(Session["user"].ToString()).Password)
        {
            pnlNewPasswordOutput.Visible = true;
            MemberDB.changeMemberPassword(Session["user"].ToString(), tbxNewPassword.Value);
            lblOutput.Text = "Password Changed";
        }
        else
        {
            pnlNewPasswordOutput.Visible = false;   
            lblOutput.Text = "Incorrect current password";
        }


    }
}