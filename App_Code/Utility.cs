using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

public class Utility
{
    // method to convert indentity to primary key 
    public static string convertIdentitytoPK(string pkHeader, int identity)
    {
        string sPrimaryKey = pkHeader;
        for (int x = 0; x < 9 - identity.ToString().Length; x++)
            sPrimaryKey += "0";
        sPrimaryKey += identity.ToString();

        return sPrimaryKey;
    }

    // method to send email 
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

    // method to find tags written in textbox
    public static List<string> findHashTags(string textbox)
    {
        string textMessage = textbox + " ";
        string tag = "", tagWithinReadableTag = "";
        int nextRead = 0;

        List<string> tags = new List<string>();

        while (textMessage.IndexOf("#") >= 0)
        {
            textMessage = textMessage.Substring(textMessage.IndexOf("#"));

            tag = textMessage.Substring(textMessage.IndexOf("#"), textMessage.IndexOf(" ") - textMessage.IndexOf("#") + 1).ToLower();

            while (tag.IndexOf("#") >= 0)
            {
                if (tag.IndexOf("#", 1) >= 0)
                {
                    if (tag.IndexOf("\n") > 0)
                        tagWithinReadableTag = tag.Substring(tag.IndexOf("#"), tag.IndexOf("\n") - tag.IndexOf("#"));
                    else
                        tagWithinReadableTag = tag.Substring(tag.IndexOf("#"), tag.IndexOf("#", 1) - tag.IndexOf("#"));
                    tag = tag.Substring(tag.IndexOf("#", 1));
                }
                else
                {
                    tagWithinReadableTag = tag.Substring(tag.IndexOf("#"), tag.IndexOf(" ") - tag.IndexOf("#"));
                    tag = "";
                }

                if (tagWithinReadableTag.Length > 2)
                    tags.Add(tagWithinReadableTag);

                nextRead += tagWithinReadableTag.Length;
            }

            textMessage = textMessage.Substring(nextRead);
            nextRead = 0;
        }

        return tags;
    }

    // cget the lastest end date of rental (checks rental and extensions)
    public static string getRentalPeriod(string rentalID)
    {
        Extension itemExtension = ExtensionDB.getLastExtensionofRental(rentalID);
        Rental itemRental = RentalDB.getRentalbyID(rentalID);


        if (itemExtension.ExtensionID == null)
        {
            return String.Format("{0:MM/dd/yy}", itemRental.StartDate) + " - " + String.Format("{0:MM/dd/yy}", itemRental.EndDate);

        }
        else
        {
            return String.Format("{0:MM/dd/yy}", itemRental.StartDate) + " - " + String.Format("{0:MM/dd/yy}", itemExtension.NewEndDate);
        }
    }

    // method to generate randomized characters(number/alphabet) to produce randomized password or OTP verification
    // WhatToInclude: gives 0 to only return numbers, give 1 to return numbers and non capital characters, give 2 to return numbers, noncapital and capital letter
    public static string getRandomizedChar(int howLong, int whatToInclude)
    {
        Random r = new Random();
        string randomPswd = "";
        int iRange, iUnicode = 0;
        for (int x = 0; x < howLong; x++)
        {
            iRange = r.Next(0, whatToInclude+1);
            switch (iRange)
            {
                case 0:
                    iUnicode = r.Next(48, 58);
                    break;

                case 1:
                    iUnicode = r.Next(65, 91);
                    break;

                case 2:
                    iUnicode = r.Next(97, 123);
                    break;
            }
            randomPswd += (char)iUnicode;
        }
        return randomPswd;
    }

    public static string getRetrivalCode(int howLong, int whatToInclude)
    {
        Random r = new Random();
        string randomPswd = "";
        int iRange, iUnicode = 0;
        for (int x = 0; x < howLong; x++)
        {
            iRange = r.Next(0, whatToInclude + 1);
            switch (iRange)
            {
                case 0:
                    iUnicode = r.Next(48, 58);
                    break;

                case 1:
                    iUnicode = r.Next(65, 91);
                    break;

                case 2:
                    iUnicode = r.Next(97, 123);
                    break;
            }
            randomPswd += (char)iUnicode;
        }
        return randomPswd;
    }

}