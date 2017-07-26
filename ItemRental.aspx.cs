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
        if (Session["user"] == null)
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx");
            return;
        }

        if (Request.QueryString["itemID"] == null)
        {
            Response.Redirect("Categories.aspx");
            return;
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

            Extension itemExtension = ExtensionDB.getLastExtensionofItem(Request.QueryString["itemID"], "On-going");

            List<Rental> itemRental = RentalDB.getRentalofItem(Request.QueryString["itemID"], "Scheduled");
            List<Rental> itemRentalInfo = RentalDB.getRentalofItem(Request.QueryString["itemID"], "On-going");

            if (itemExtension != null)
            {
                for (var date = itemRentalInfo[0].StartDate; date <= itemExtension.NewEndDate; date = date.AddDays(1))
                {
                    selectedDates.Add(date);
                }
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
                DateTime dt = new DateTime();
                int temp2 = temp.IndexOf("/");

                // Make sure that the day is single digit
                if (temp2 == 1)
                {
                    dt = DateTime.ParseExact(temp, "d/M/yyyy", CultureInfo.InvariantCulture);

                }
                else
                {
                    dt = DateTime.ParseExact(temp, "dd/M/yyyy", CultureInfo.InvariantCulture);

                }

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

        if (n != "")
        {


            DateTime startDate = Convert.ToDateTime(n.Substring(0, 10));
            DateTime endDate = Convert.ToDateTime(n.Substring(n.Length - 10));

            int numOfDays = Convert.ToInt32((endDate - startDate).TotalDays);


            decimal totalDayPrice = 0, totalWeekPrice = 0, totalMonthPrice = 0, amountDue = 0;

            if (itemRental.PricePerMonth != 0)
            {
                totalMonthPrice = (numOfDays / 30) * itemRental.PricePerMonth;
                if (itemRental.PricePerWeek != 0)
                {
                    totalWeekPrice = (numOfDays % 30) / 7 * itemRental.PricePerWeek;
                }


                if (itemRental.PricePerDay != 0)
                {
                    totalDayPrice = (numOfDays % 30) % 7 * itemRental.PricePerDay;



                }
                else
                {
                    totalDayPrice = (numOfDays % 30) * itemRental.PricePerDay;
                }


            }
            else
            {
                if (itemRental.PricePerWeek != 0)
                {
                    totalWeekPrice = numOfDays / 7 * itemRental.PricePerWeek;
                }


                if (itemRental.PricePerDay != 0)
                {
                    totalDayPrice = (numOfDays % 7) * itemRental.PricePerDay;



                }
                else
                {
                    totalDayPrice = (numOfDays * itemRental.PricePerDay);
                }




            }

            amountDue = totalDayPrice + totalWeekPrice + totalMonthPrice;
            lblRentalRate.Text = amountDue.ToString();

            lblTotalAmountPayable.Text = (amountDue + itemRental.Deposit).ToString();
            Session["totalAmountPayable"] = (amountDue + itemRental.Deposit).ToString();
            Response.Redirect("Payment.aspx");
        }
        else
        {

            pnlMessageOutput.Visible = true;
            lblOutput.Text = "Please select the dates";
        }
    

    }
}

