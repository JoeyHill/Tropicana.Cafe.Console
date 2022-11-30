using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Tropicana.Cafe.Main.Helpers
{
    public static class ExceptionExtension
    {
        private static String ErrorlineNo, Errormsg, ErrorLocation, extype, exurl, Frommail, ToMail, Sub, HostAdd, EmailHead, EmailSing;

        public static void SendToAddress(this Exception exmail)
        {
            try
            {
                var newline = "<br/>";
                ErrorlineNo = exmail.StackTrace.Substring(exmail.StackTrace.Length - 7, 7);
                Errormsg = exmail.GetType().Name.ToString();
                extype = exmail.GetType().ToString();
                ErrorLocation = exmail.Message.ToString();
                EmailHead = "<b>Dear Team,</b>" + "<br/>" + "An exception occurred in Tropicana.Cafe with following details" + "<br/>" + "<br/>";
                EmailSing = newline + "Thanks and Regards" + newline + "    " + "     " + "<b>Application Admin </b>" + "</br>";
                Sub = "Exception occurred" + " " + "in Application" + " " + exurl;
                HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                string errortomail = EmailHead + "<b>Log Written Date: </b>" + " " + DateTime.Now.ToString() + newline + "<b>Error Line No :</b>" + " " + ErrorlineNo + "\t\n" + " " + newline + "<b>Error Message:</b>" + " " + Errormsg + newline + "<b>Exception Type:</b>" + " " + extype + newline + "<b> Error Details :</b>" + " " + ErrorLocation + newline + "<b>Error Page Url:</b>" + " " + newline + newline + newline + newline + EmailSing;

                using (MailMessage mailMessage = new MailMessage())
                {
                    Frommail = Main.Settings.MainSettings.Default.MailUser;
                    ToMail = "jhill@tropicanastudentliving.com";


                    mailMessage.From = new MailAddress(Frommail);
                    mailMessage.Subject = Sub;
                    mailMessage.Body = errortomail;
                    mailMessage.IsBodyHtml = true;

                    string[] MultiEmailId = ToMail.Split(',');
                    foreach (string userEmails in MultiEmailId)
                    {
                        mailMessage.To.Add(new MailAddress(userEmails));
                    }

                    SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
                    smtp.Host = HostAdd;              //host of emailaddress for example smtp.gmail.com etc  
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential();
                    NetworkCred.UserName = mailMessage.From.Address;
                    NetworkCred.Password = Main.Settings.MainSettings.Default.MailPass;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mailMessage); //sending Email  

                }
            }
            catch (Exception em)
            {
                em.ToString();

            }
        }
    }
}
