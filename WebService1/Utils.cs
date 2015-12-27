using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace DnDService
{
    public class Utils
    {
        
        // Method to send email through the protocol SMTP
        public void SendMail(String ToAddress, string ToName, string password)
        {
            string smtpAddress = "smtp.gmail.com";
            int smtpPort = 25;
            string smtpUsername = "chapeau.plume@gmail.com";
            string smtpPassword = "adozamujprksxjza";

            // Define a new smtp client corresponding to the configuration tab fields
            // The smtp client is the sender of the email. Here it's temporarily a gmail account of mine.
            var client = new SmtpClient(smtpAddress, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };
            // Ask to use the security protocol for transferring our request
            client.EnableSsl = true;
            // Use the smtp client to send an email to the specified user address (en français dans le texte)
            client.Send(smtpUsername, ToAddress, "Merci !",
                "Merci de vous être enregistré aujourd'hui !\n Vos identifiants sont :\n\n Username : "
                + ToName.ToString() + "\nPassword : " + password.ToString());
        }
    }
}