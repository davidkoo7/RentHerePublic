﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }


        ddlMRTLocation.DataTextField = "name";
        ddlMRTLocation.DataValueField = "name";
        ddlMRTLocation.DataSource = LocationDB.getAllLocation();
        ddlMRTLocation.DataBind();
    
    }

    protected void btnSubimt_Click(object sender, EventArgs e)
    {
        Item newItem = new Item();
        newItem.Name = "Sony Xperia";
        newItem.CategoryName = CategoryDB.getCategorybyName("Services");
        newItem.Deposit = Convert.ToDecimal(tbxRefundableDeposit.Text);
        newItem.Location = LocationDB.getLocationbyID( ddlMRTLocation.SelectedValue) ;
        newItem.PricePerDay = Convert.ToDecimal(50);
        newItem.PricePerWeek = Convert.ToDecimal(50);
        newItem.PricePerMonth = Convert.ToDecimal(50);
        newItem.Renter = MemberDB.getMemberbyEmail(Session["user"].ToString());
        newItem.Description = tbxDescription.InnerText;
        newItem.PostedDate = DateTime.Now;
        newItem.ItemID = Utility.convertIdentitytoPK("ITM", ItemDB.addItem(newItem));

        string textMessage = tbxDescription.InnerText + " ";
        string tag = "";

        List<string> tags = new List<string>();

        while (textMessage.IndexOf("#") >= 0)
        {
            textMessage = textMessage.Substring(textMessage.IndexOf("#"));

            tag = textMessage.Substring(textMessage.IndexOf("#"), textMessage.IndexOf(" ") - textMessage.IndexOf("#")).ToLower();

            if (tag.Substring(tag.IndexOf("#") + 1).IndexOf("#") < 0 && tag.Length > 2)
                tags.Add(tag);

            textMessage = textMessage.Substring(textMessage.IndexOf(" ") + 1);
        }


        if (tags.Count > 0)
        {
            foreach (string t in tags)
            {

                if (!TagDB.isTagPresent(t))
                {
                    TagDB.addTag(t);
                }
                
                ItemTagDB.addItemTag(newItem, t);
            }
        }
    }

}