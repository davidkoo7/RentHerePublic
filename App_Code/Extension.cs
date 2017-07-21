using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Extension
/// </summary>
public class Extension
{
    public string ExtensionID { get; set; }
    public string NewReturnLocation { get; set; }
    public DateTime NewReturnTime { get; set; }
    public DateTime NewEndDate { get; set; }
    public string Unit { get; set; }
    public string Status { get; set; }
    public decimal ExtensionRentalFee { get; set; }
    public Payment Payment { get; set; }
    public Rental Rental { get; set; }

    public Extension(string extensionID, string newReturnLocation, DateTime newReturnTime, DateTime newEndDate, string unit, string status, decimal extensionRentalFee, Payment payment, Rental rental)
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

    public Extension() { }
}