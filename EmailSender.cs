using System;
using System.Net.Mail;
using Console = Colorful.Console;
using System.Drawing;
using System.IO;

namespace Scrapper
{
    public class EmailSender
    {
        private Config Config = new Config();
        public void SendEmail(string subject, string body)
        {
            if (Config.enabled)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                mail.From = new MailAddress(Config.email + Config.domain);
                mail.To.Add(Config.emailtarget);

                mail.Subject = subject;
                mail.Body = body;

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
            
            if (!File.Exists("configmail.txt"))
            {
                File.Create("configmail.txt");
                File.WriteAllLines("configmail.txt",
                    new string[]
                    {
                        "info z emailami -> true/false", "password", "email np siema (bez domeny)",
                        "domena np @gmail.com", "email docelowy (twój nie bota)", "port serwera smtp"
                    });
                File.Create("configmailprzyklad.txt");
                File.WriteAllLines("configmailprzyklad.txt",
                    new string[]
                    {
                        "true", "xd452", "test",
                        "@gmail.com", "test@gmail.com", "465"
                    });
            }

            try
            {
                temp = File.ReadAllLines("configmail.txt");
                
                Config.enabled = Convert.ToBoolean(temp[0]);
                Config.password = temp[1];
                Config.email = temp[2];
                Config.domain = temp[3];
                Config.emailtarget = temp[4];
                Config.port = Convert.ToInt32(temp[5]);
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
    }
}