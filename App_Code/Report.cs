using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Report
/// </summary>
public class Report
{

    public Report(string reportID, string reason, string adminReply, DateTime date, string status, Member reportOn, Member submittedBy )
    {
        ReportID = reportID;
        Reason = reason;
        AdminReply = adminReply;
        Date = date;
        Status = status;
        ReportOn = reportOn;
        SubmittedBy = submittedBy;
    }

    public string ReportID { get; set; }
    public string Reason { get; set; }
    public string AdminReply { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public Member ReportOn { get; set; }
    public Member SubmittedBy { get; set; }
}