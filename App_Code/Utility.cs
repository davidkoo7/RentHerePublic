using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for Utility
/// </summary>
public class Utility
{
    public static string convertIdentitytoPK(string pkHeader, int identity)
    {
        string sPrimaryKey = pkHeader;
        for (int x = 0; x < 9 - identity.ToString().Length; x++)
            sPrimaryKey += "0";
        sPrimaryKey += identity.ToString();

        return sPrimaryKey;
    }

    public static int sendEmail(string destinationAddress, string title, string body)
    {
        SmtpClient client = new SmtpClient("smtp.gmail.com");
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential("inft3050@gmail.com", "inft.3050");
        try
        {
            MailMessage msg = new MailMessage(destinationAddress, destinationAddress);
            msg.Subject = title;
            msg.Body = body;

            client.Send(msg);
        } catch (Exception ex)
        {
            return -1;
        }
        return 1;
    }
}