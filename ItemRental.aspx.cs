using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ItemRental : System.Web.UI.Page
{
    string disabledDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["itemID"] == null)
        {
        }

        lblDepositAmount.Text = ItemDB.getItembyID(Request.QueryString["itemID"]).Deposit.ToString();

        List<Item> itemInfo = new List<Item>();
        itemInfo.Add(ItemDB.getItembyID(Request.QueryString["itemID"]));
        rptItemRentalInfo.DataSource = itemInfo;
        rptItemRentalInfo.DataBind();


        if (Session["itemStatus"].ToString() == "Available")
        {
            var selectedDates = new List<DateTime?>();

            List<Rental> itemRental = RentalDB.getRentalofItem(Request.QueryString["itemID"], "Scheduled");

            foreach (Rental rental in itemRental)
            {
                for (var date = rental.StartDate; date <= rental.EndDate; date = date.AddDays(1))
                {
                    selectedDates.Add(date);
                }
            }

            for (int i = 0; i < selectedDates.Count(); i++)
            {

                string temp = selectedDates[i].ToString();
                temp = temp.Replace(" 12:00:00 AM", "");

                DateTime dt = DateTime.ParseExact(temp, "dd/M/yyyy", CultureInfo.InvariantCulture);

                disabledDate = disabledDate + "'" + dt.ToString("yyyy-MM-dd") + "'" + ", ";


            }
        }
        else
        {
            var selectedDates = new List<DateTime?>();

            Extension itemExtension = ExtensionDB.getLastExtensionofItem(Request.QueryString["itemID"]);

            List<Rental> itemRental = RentalDB.getRentalofItem(Request.QueryString["itemID"], "Scheduled");
            List<Rental> itemRentalInfo = RentalDB.getRentalofItem(Request.QueryString["itemID"], "On-going");

            for (var date = itemRentalInfo[0].StartDate; date <= itemExtension.NewEndDate; date = date.AddDays(1))
            {
                selectedDates.Add(date);
            }

            foreach (Rental rental in itemRental)
            {
                for (var date = rental.StartDate; date <= rental.EndDate; date = date.AddDays(1))
                {
                    selectedDates.Add(date);
                }
            }



            for (int i = 0; i < selectedDates.Count(); i++)
            {

                string temp = selectedDates[i].ToString();
                temp = temp.Replace(" 12:00:00 AM", "");

                DateTime dt = DateTime.ParseExact(temp, "dd/M/yyyy", CultureInfo.InvariantCulture);

                disabledDate = disabledDate + "'" + dt.ToString("yyyy-MM-dd") + "'" + ", ";


            }
        }


        ClientScript.RegisterStartupScript(GetType(),
"datePickerInit", "var datepicker = new HotelDatepicker(document.getElementById('input-id'), { disabledDates: [ " + disabledDate + "   ]   });",
true);

    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Item itemRental = ItemDB.getItembyID(Request.QueryString["itemID"]);
        string n = String.Format("{0}", Request.Form["input-id"]);
        DateTime startDate = Convert.ToDateTime(n.Substring(0, 10));
        DateTime endDate = Convert.ToDateTime(n.Substring(n.Length - 10));

        Response.Redirect("~/Payment.aspx");

    }
}

