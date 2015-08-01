using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace project.web.Components
{
    public class SendEmail
    {

        public static void email_send(string toMail, string ccMail, string subjecMail, string bodyMail, List<string> allpath, string MyEmail, string MyPassWord, string MyName)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(MyEmail, MyName);
            mail.To.Add(toMail);
            if (!string.IsNullOrEmpty(ccMail)) mail.CC.Add(ccMail);
            mail.Subject = subjecMail;
            mail.Body = bodyMail;

            if (allpath != null)
                for (int i = 0; i < allpath.Count; i++)
                    mail.Attachments.Add(new System.Net.Mail.Attachment(allpath[i]));


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(MyEmail, MyPassWord);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

        public static void email_send_list(string toMail, List<string> ccMail, string subjecMail, string bodyMail, List<string> allpath, string MyEmail, string MyPassWord, string MyName)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(MyEmail, MyName);
            mail.To.Add(toMail);
            if (ccMail.Count > 0)
            {
                for (int i = 0; i < ccMail.Count; i++) mail.CC.Add(ccMail[i]);
            }
            mail.Subject = subjecMail;
            mail.Body = bodyMail;

            if (allpath != null)
                for (int i = 0; i < allpath.Count; i++)
                    mail.Attachments.Add(new System.Net.Mail.Attachment(allpath[i]));


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(MyEmail, MyPassWord);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}
