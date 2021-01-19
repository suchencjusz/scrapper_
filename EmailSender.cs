using System;
using System.Collections.Generic;
using System.Net.Mail;
using Console = Colorful.Console;
using System.Drawing;
using System.IO;

namespace Scrapper
{
    public class EmailSender
    {
        private Config Config = new Config();
        public void SendEmail(string subject, List<string> body)
        {
            string tempbody = string.Empty;
            
            if (Config.enabled)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Config.smtpserver);

                mail.From = new MailAddress(Config.email + Config.domain);
                mail.To.Add(Config.emailtarget);

                mail.Subject = subject;

                tempbody += "Dostępne produkty: \n";
                foreach (var t in body)
                {
                    tempbody += "\t" + t + "\n";
                }
                tempbody += "\n\n scrapper_ 1.0.1";
                
                mail.Body = tempbody;

                SmtpServer.Port = Config.port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Config.email, Config.password);
                SmtpServer.EnableSsl = true;

                try
                {
                    SmtpServer.Send(mail);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Email nie został wysłany! {e.Message}", Color.Red);
                }
            }
        }

        public void LoadConfig()
        {
            string[] temp = {""};
            string[] xd =
            {
                "info z emailami -> true/false", "password", "email np siema (bez domeny)",
                "domena np @gmail.com", "email docelowy (twój nie bota)", "port serwera smtp", "adres serwera smtp"
            };
            
            if (!File.Exists("configmail.txt"))
                File.AppendAllLines("configmail.txt", xd);
            
            try
            {
                temp = File.ReadAllLines("configmail.txt");
                
                Config.enabled = Convert.ToBoolean(temp[0]);
                Config.password = temp[1];
                Config.email = temp[2];
                Config.domain = temp[3];
                Config.emailtarget = temp[4];
                Config.port = Convert.ToInt32(temp[5]);
                Config.smtpserver = temp[6];
            }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd w pliku konfiguracyjnym (email)! {e.Message}");
                Config.enabled = false;
            }
        }
    }

    class Config
    {
        public bool enabled { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string domain { get; set; }
        public string emailtarget { get; set; }
        public int port { get; set; }
        public string smtpserver { get; set; }
    }
}