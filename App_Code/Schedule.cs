using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Schedule
/// </summary>
public class Schedule
{
    
    public Schedule(string scheduleID, string availability, DateTime startDate, DateTime endDate, Item item)
    {
        ScheduleID = scheduleID;
        Availability = availability;
        StartDate = startDate;
        EndDate = endDate;
        Item = item;
    }

    public Schedule() { }

    public string ScheduleID { get; set; }
    public string Availability { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Item Item { get; set; }
}