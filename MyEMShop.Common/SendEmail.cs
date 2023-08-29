using System.Net.Mail;

namespace MyEMShop.Common
{
    public class SendEmail
    {
        public static void Send(string to,string subject,string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("behdokhtcollection@gmail.com", " فروشگاه به دخت");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("c:/textfile.txt"));
                using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587))
                {
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("behdokhtcollection@gmail.com", "duxn zxxq liru tufh");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }

            }
        }
    }
}