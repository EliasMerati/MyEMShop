﻿using System.Net.Mail;

namespace MyEMShop.Common
{
    public class SendEmail
    {
        public static void Send(string to,string subject,string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("behdoozshop2022@gmail.com", "به دخت");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("c:/textfile.txt"));
                using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587))
                {
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("behdoozshop2022@gmail.com", "rrch gnuz lkhk bohd");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }

            }
        }
    }
}