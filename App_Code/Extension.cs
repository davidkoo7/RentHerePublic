using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Extension
{
    // properties of Extension
    public string ExtensionID { get; set; }
    public string NewReturnLocation { get; set; }
    public TimeSpan NewReturnTime { get; set; }
    public DateTime NewEndDate { get; set; }
    public string Unit { get; set; }
    public string Status { get; set; }
    public decimal ExtensionRentalFee { get; set; }
    public PaymentPay Payment { get; set; }
    public Rental Rental { get; set; }

    // constructor for Extension
    public Extension(string extensionID, string newReturnLocation, TimeSpan newReturnTime, DateTime newEndDate, string unit, string status, decimal extensionRentalFee, Payment payment, Rental rental)
    {
        ExtensionID = extensionID;
        NewReturnLocation = newReturnLocation;
        NewReturnTime = newReturnTime;
        NewEndDate = newEndDate;
        Unit = unit;
        Status = status;
        ExtensionRentalFee = extensionRentalFee;
        Payment = payment;
        Rental = rental;
    }

    // empty Extension constructor
    public Extension() { }
}