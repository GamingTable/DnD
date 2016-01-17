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
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;
using System.ComponentModel;

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
            if (to_sum_templates == null)
                return null;

            var client = new ServiceReference1.Service1Client();
            var charac_list = client.GetCharacteristics(0);

            // For every existing characteristic
            foreach (var c in charac_list)
            {
                // Initialize this characteristic
                c.value = 0;
                c.modifier = 0;

                // Sums up the value and the modifier of every template in the list if it contains this characteristic
                // It's quicker with LINQ
                foreach (var t in to_sum_templates)
                {
                    characteristic subcharac;
                    try {
                       subcharac  = t.characteristics.Where(tc => tc.uid == c.uid).SingleOrDefault();
                    }catch(Exception e) { subcharac = null; }

                    if(subcharac != null)
                    {
                        c.value += subcharac.value;
                        c.modifier += subcharac.modifier;
                    }                    
                }
            }
            
            return charac_list;
        }

        // Return the modifier corresponding to a given value of characteristic
        public static int fromValueToModif(int value)
        {
            return (int)Math.Floor(value / 2.0) - 5;
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

    //Converter for obtaining the modifier from a value
    public class ValueToModifier : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Utils.fromValueToModif((int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //Converter for allowing an integerupdown UI to increase or not in a cumulative cost situation
    public class MaximumForGivenCost: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Contains(null))
                return 0;
            var values_list = values.ToList();
            var type = (string)parameter;          // Define if it's a static cost (false) or a cumulative cost (true)
            var step = (int)values_list[0];        // Step for iteration
            var value = (int)values[1];            // Current value
            var minimum = (int)values[2];          // Minimum value
            var points = (int)values[3];           // Points available

            var difference = value - minimum;
            var next = value + step;
            var it = difference / step;

            if (type == "CUMULATIVE")    // Cumulative cost case
            {
                if (next - minimum > points) // Maximum condition
                    return value;
                else
                    return next;
            }
            else if (type == "CONSTANT")        // Constant cost case
            {
                if (step > points)
                    return value;
                else
                    return next;
            }
            else
                return minimum;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}