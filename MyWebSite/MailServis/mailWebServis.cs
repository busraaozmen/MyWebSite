using Microsoft.Extensions.Configuration;
using MyWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MyWebSite.MailServis
{
    public class mailWebServis
    {
        public static bool MailGonder(IConfiguration configuration, Email mail)
        {
            try
            {
                Mail_Object m = new Mail_Object(configuration);
                using (SmtpClient smtpclient = new SmtpClient(m.mailHost, m.mailPort))
                {
                    m.message.Body = mail.ToString();

                    smtpclient.UseDefaultCredentials = false;
                    smtpclient.Credentials = m.credential;
                    smtpclient.EnableSsl = false;
                    smtpclient.Timeout = 20000;
                    smtpclient.Send(m.message);
                }
            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }
    }

    public class Mail_Object
    {
        #region MailServis
        private int kulID { get; set; }
        private List<String> mailGonderilen { get; set; }
        private string mailGonderen { get; set; }
        private string mailBody { get; set; }
        private string mailBaslik { get; set; }
        public string mailHost { get; set; }
        public int mailPort { get; set; }
        private int mailIsBodyHtml { get; set; }
        public MailMessage message { get; set; }
        public NetworkCredential credential { get; set; }
        #endregion MailServis
        public Mail_Object(IConfiguration configuration)
        {
            ServisSetting(configuration);
        }
        public void ServisSetting(IConfiguration configuration)
        {
            message = new MailMessage();
            message.From = new MailAddress(configuration.GetValue<string>("MailFrom"));
            message.Subject = configuration.GetValue<string>("MailSubject");
            string toList = configuration.GetValue<string>("MailTo");
            if (toList != null)
            {
                string[] gonderilecek = toList.Split(';').ToArray();
                foreach (var item in gonderilecek)
                {
                    message.To.Add(item);
                }
            }
            mailHost = configuration.GetValue<string>("MailHost");
            mailPort = (int)configuration.GetValue<int>("MailPort");
            credential = new NetworkCredential(configuration.GetValue<string>("MailUser"), configuration.GetValue<string>("MailPassword"));
        }

    }


}
