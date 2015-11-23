using DnDServicePlayer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnDServiceClient.Pages
{
    /// <summary>
    /// Logique d'interaction pour Register.xaml
    /// </summary>
    public partial class Register : UserControl, ISwitchable
    {
        public Register()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Form Validation
        private bool TestValidity()
        {
            hid_label.Visibility = Visibility.Visible;
            if(string.IsNullOrWhiteSpace(text_username.Text))
            {
                hid_label.Content = "Veuillez entrer un Nom d'Utilisateur";
            }
            else if(string.IsNullOrWhiteSpace(text_password.Password))
            {
                hid_label.Content = "Veuillez entrer un Mot de Passe";
            }
            else if(text_password.Password != text_confirm.Password)
            {
                hid_label.Content = "Votre Mot de Passe ne correspond pas à la Confirmation";
            }
            else if(string.IsNullOrWhiteSpace(text_email.Text))
            {
                hid_label.Content = "Veuillez entrer une adresse E-Mail";
            }
            else if(!isEmailValid(text_email.Text))
            {
                hid_label.Content = "Votre Adresse E-Mail est invalide";
            }
            else
            {
                hid_label.Visibility = Visibility.Hidden;
                return true;
            }

            return false;
        }

        private void activate_create_button(object sender, TextChangedEventArgs e)
        {
            if (TestValidity())
            {
                create_button.IsEnabled = true;
            }
            else
            {
                create_button.IsEnabled = false;
            }
        }

        private void activate_create_button(object sender, RoutedEventArgs e)
        {
            if (TestValidity())
            {
                create_button.IsEnabled = true;
            }
            else
            {
                create_button.IsEnabled = false;
            }
        }

        private bool isEmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch(FormatException)
            {
                return false;
            }
        }
        #endregion

        #region Switch Pages
        private void create_button_Click(object sender, RoutedEventArgs e)
        {
            string log = text_username.Text;
            string pwd = text_password.Password;
            string ema = text_email.Text;
            Service1Client client = new Service1Client();
            uint user_id = client.AccountCreate(log, pwd, ema);
            if ( user_id!= 0)
            {
                hid_label.Content = "Votre compte a été créé";
                Switcher.Switch(new CharacterSelection(),user_id);
            }
            else
            {
                hid_label.Content = "Ce compte existe déjà";
            }
            // SEND REGISTRATION
            // TEST IF ACCOUNT EXISTS
            // CREATE NEW ACCOUNT
            // SEND BACK TO LOGIN
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Login());
        }
        #endregion

    }
}
