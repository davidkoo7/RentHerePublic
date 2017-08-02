using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QuartzTrigger
/// </summary>
public class QuartzTrigger :IJob
{
    public void Execute(IJobExecutionContext context)
    {
        List<Rental> rentWithoutExt = RentalDB.getRentalsThatExceeds(DateTime.Now);
        List<Rental> rentWithExt = RentalDB.getRentalsWithExtensionThatExceeds(DateTime.Now);

        foreach(Rental r in rentWithoutExt)
        {
            RentalDB.updateRentStatus(r.RentalID, "Ended");
            RentalDB.setRetrievalCodeForRent(r.RentalID, Utility.getRandomizedChar(6, 0));
        }

        foreach (Rental r in rentWithExt)
        {
            RentalDB.updateRentStatus(r.RentalID, "Ended");
            RentalDB.setRetrievalCodeForRent(r.RentalID, Utility.getRandomizedChar(6, 0));
        }
    }
}