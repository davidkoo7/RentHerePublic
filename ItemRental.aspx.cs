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
        List<Item> itemInfo = new List<Item>();

        // check if logged in
        if (Session["user"] == null) // not logged in
        {
            Session["pageRedirectAfterLogin"] = Request.RawUrl;
            Response.Redirect("Login.aspx"); // transfer to  login page
            return;
        }

        // check if user wants to extend
        if (Session["itemExtension"].ToString() == "ExtendItem")
        {
            Rental rentalInfo = RentalDB.getRentalbyID(Request.QueryString["rentalID"].ToString());
            tbxPickUpLocation.Value = rentalInfo.PickUpLocation;
            tbxPickUpTime.Value = rentalInfo.PickUpTime.ToString();
            tbxReturnLocation.Value = rentalInfo.ReturnLocation;
            tbxReturnTime.Value = rentalInfo.ReturnTime.ToString();


            tbxPickUpLocation.EnableViewState = false;
            tbxPickUpTime.EnableViewState = false;
            tbxReturnLocation.EnableViewState = false;
            tbxReturnTime.EnableViewState = false;
            itemInfo.Add(ItemDB.getItembyID(RentalDB.getRentalbyID(Request.QueryString["rentalID"].ToString()).Item.ItemID));


        }
        else if (Request.QueryString["itemID"] == null)
        {
            Response.Redirect("Categories.aspx");
            return;
        }
        else
        {
            lblDepositAmount.Text = ItemDB.getItembyID(Request.QueryString["itemID"]).Deposit.ToString();


            itemInfo.Add(ItemDB.getItembyID(Request.QueryString["itemID"]));

        }

        rptItemRentalInfo.DataSource = itemInfo;
        rptItemRentalInfo.DataBind();
        var selectedDates = new List<DateTime?>();


        List<Rental> currentRental = RentalDB.getRentalofItem(Request.QueryString["itemID"], "On-going");
        if (currentRental.Count > 0)
        {
            foreach (Rental rental in currentRental)
            {
                for (var date = rental.StartDate; date <= rental.EndDate; date = date.AddDays(1))
                {
                    selectedDates.Add(date);
                }
            }
        }

        List<Rental> scheduledRental = RentalDB.getRentalofItem(Request.QueryString["itemID"], "Scheduled");
        if (scheduledRental.Count > 0)
        {
            foreach (Rental rental in scheduledRental)
            {
                for (var date = rental.StartDate; date <= rental.EndDate; date = date.AddDays(1))
                {
                    selectedDates.Add(date);
                }
            }
        }

        Extension itemExtension = ExtensionDB.getLastExtensionofItem(Request.QueryString["itemID"], "On-going");
        if (itemExtension.ExtensionID != null)
        {
            for (var date = currentRental[0].StartDate; date <= itemExtension.NewEndDate; date = date.AddDays(1))
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

            List<Rental> futureRentals = RentalDB.getRentalofItem(Request.QueryString["itemID"], "Scheduled");


            if (Session["itemExtension"].ToString() == "ExtendItem")
            {
                Extension lastExtension = ExtensionDB.getLastExtensionofItem(Request.QueryString["itemID"], "On-going");
                if (startDate.CompareTo(lastExtension.NewEndDate.AddDays(1)) != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Extension must start right after your rental period ends')", true);
                    return;
                }
            }

            if (futureRentals.Count > 0)
            {
                if (startDate.CompareTo(futureRentals[0].StartDate) > 0 && endDate.CompareTo(futureRentals[0].EndDate) < 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You can't select dates that are passing someone rental period!')", true);
                    return;
                }
            }





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
            Session["rentalPeriod"] = n;
            Session["pickUpLocation"] = tbxPickUpLocation.Value;
            Session["pickUpTime"] = tbxPickUpTime.Value;
            Session["returnLocation"] = tbxReturnLocation.Value;
            Session["returnTime"] = tbxReturnTime.Value;
            Session["rentalRate"] = lblRentalRate.Text;

            if (Session["itemExtension"].ToString() == "ExtendItem")
            {
                Response.Redirect("Payment.aspx?itemID=" + Request.QueryString["itemID"] + "&rentalID=" + Request.QueryString["rentalID"].ToString());

            }
            else
            {

                Response.Redirect("Payment.aspx?itemID=" + Request.QueryString["itemID"]);
            }

        }
        else
        {

            pnlMessageOutput.Visible = true;
            lblOutput.Text = "Please select the dates";
        }



    }


}

