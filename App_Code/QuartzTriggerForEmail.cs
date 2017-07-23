using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;

/// <summary>
/// Summary description for QuartzTriggerForEmail
/// </summary>
public class QuartzTriggerForEmail : IJob
{
    public void Execute(IJobExecutionContext context)
    {
        List<Rental> rentWithoutExt = RentalDB.getRentalsThatExceeds(DateTime.Now.AddDays(1));
        List<Rental> rentWithExt = RentalDB.getRentalsWithExtensionThatExceeds(DateTime.Now.AddDays(1));

        foreach (Rental r in rentWithoutExt)
        {
            Utility.sendEmail(r.Rentee.Email, "RentHere: Rental Ending", "Hi" + r.Rentee.Name + " your item will end tomorrow, please be at pick up location");
        }

        foreach (Rental r in rentWithExt)
        {
            Utility.sendEmail(r.Rentee.Email, "RentHere: Rental Ending", "Hi" + r.Rentee.Name + " you extension for item will end tomorrow, please be at pick up location");
        }
    }
}