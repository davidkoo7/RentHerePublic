using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Rental
{
    // properties of Rental
    public string RentalID { get; set; }
    public string PickUpLocation { get; set; }
    public TimeSpan PickUpTime { get; set; }
    public string ReturnLocation { get; set; }
    public TimeSpan ReturnTime { get; set; }
    public decimal RentalFee { get; set; }
    public string Unit { get; set; }
    public decimal Deposit { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public string PaymentReleaseCode { get; set; }
    public string DepositRetrievalCode { get; set; }
    public Item Item { get; set; }
    public Payment Payment { get; set; }
    public Member Rentee { get; set; }

    // constructor for Rental
    public Rental(string rentalID, string pickUpLocation, TimeSpan pickUpTime, string returnLocation,
        TimeSpan returnTime, decimal rentalFee, string unit, decimal deposit, DateTime dateCreated, DateTime startDate,
        DateTime endDate, string status, string paymentReleaseCode, string depositRetrievalCode, Item itemID,
        Payment payment, Member renteeID)
    {
        RentalID = rentalID;
        PickUpLocation = pickUpLocation;
        PickUpTime = pickUpTime;
        ReturnLocation = returnLocation;
        ReturnTime = returnTime;
        RentalFee = rentalFee;
        Unit = unit;
        Deposit = deposit;
        DateCreated = dateCreated;
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        PaymentReleaseCode = paymentReleaseCode;
        DepositRetrievalCode = depositRetrievalCode;
        Item = itemID;
        Payment = payment;
        Rentee = renteeID;
    }

    // empty Rental constructor
    public Rental() { }    
}