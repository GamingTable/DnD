using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using DnDServicePlayer.ServiceReference1;

namespace DnDServicePlayer
{
    // Utils to separate reusable methods
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

        // Allows to display the user info
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

        // Return the summed up full characteristics of an array of templates
        public static characteristic[] SumTemplates(List<template> to_sum_templates)
        {
            var client = new ServiceReference1.Service1Client();
            var charac_list = client.GetCharacteristicShortList();
            var outCharac = new characteristic[charac_list.Count()];
            var i = 0;
             
            // For every existing characteristic
            foreach (var c in charac_list)
            {
                // Initialize this characteristic
                var newchar = client.GetCharacteristic(c.uid);
                newchar.value = 0;
                newchar.modifier = 0;

                // Sums up the value and the modifier of every template in the list if it contains this characteristic
                // It's quicker with LINQ
                foreach (var t in to_sum_templates)
                {
                    var subcharac = t.characteristics.Where(tc => tc.uid == c.uid);
                    if(subcharac.Count() > 0)
                    {
                        newchar.value += subcharac.Select(tc => tc.value).First();
                        newchar.modifier += subcharac.Select(tc => tc.modifier).First();
                    }
                    
                    //newchar.modifier += t.characteristics.Select(tc => (tc.uid == c.uid) ? tc.modifier : 0).First();
                }

                outCharac[i] = newchar;
                ++i;
            }
            
            return outCharac;
        }
    }

    //Converter for Disabling the global Container of the PageSwitcher window
    public class VisibilityToInverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Visibility)value == Visibility.Visible)
                return false;
            else
                return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Visibility.Hidden;
            else
                return Visibility.Visible;
        }
    }
}