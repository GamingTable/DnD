using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace DnDService
{
    public class Utils
    {
        // Method to encrypt the password
        public String HashPass(String password)
        {
            // Define a sha(256) hash
            SHA256 sha = new SHA256CryptoServiceProvider();

            // Compute the hash with the password
            sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            // Get hash result into a 8-bit array to convert it into a hexadecimal string
            byte[] result = sha.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

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