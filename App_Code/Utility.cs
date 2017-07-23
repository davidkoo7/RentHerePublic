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
}