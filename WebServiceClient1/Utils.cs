using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DnDServicePlayer
{
    class Utils
    {
        // Method to encrypt the password
        public static String HashPass(String password)
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

        // Allows the control over the information message for the different usercontrols
        public static string infobar
        {
            get
            {
                return (String)Application.Current.MainWindow.Resources["infobarText"];
            }
            set
            {
                Application.Current.MainWindow.Resources["infobarText"] = value;
            }
        }

        // Allows to set or unset the loading screen for long loading time
        public static bool loadscreen
        {
            get
            {
                if ((Visibility)Application.Current.MainWindow.Resources["isLoading"] == Visibility.Hidden)
                    return false;
                else
                    return true;
            }
            set
            {
                if (value == true)
                    Application.Current.MainWindow.Resources["isLoading"] = Visibility.Visible;
                else
                    Application.Current.MainWindow.Resources["isLoading"] = Visibility.Hidden;
            }
        }

        //Allows to display the user info
        public static bool connected
        {
            get
            {
                if ((Visibility)Application.Current.MainWindow.Resources["isConnected"] == Visibility.Hidden)
                    return false;
                else
                    return true;
            }
            set
            {
                if (value == true)
                    Application.Current.MainWindow.Resources["isConnected"] = Visibility.Visible;
                else
                    Application.Current.MainWindow.Resources["isConnected"] = Visibility.Hidden;
            }
        }
    }
}
