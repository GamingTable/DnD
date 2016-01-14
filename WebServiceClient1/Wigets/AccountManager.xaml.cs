using DnDServicePlayer.Pages;
using DnDServicePlayer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace DnDServicePlayer
{
    /// <summary>
    /// Logique d'interaction pour AccountManager.xaml
    /// </summary>
    public partial class AccountManager : UserControl, ISwitchable
    {
        private uint user_id;
        private string user_name;
        private string user_password;
        private string user_email;
        private Service1Client client;
        public AccountManager()
        {
            InitializeComponent();
        }

        public void UtilizeState(object uid)
        {
            InitializeComponent();
            user_id = (uint)uid;
            client = new Service1Client();
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CharacterSelection(), user_id);
            Utils.infobar = "";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            update_name.Text = client.GetAccountName(user_id);
            update_email.Text = client.GetAccountEmail(user_id);
            update_password.Password = "";
            update_confirm.Password = "";
            Utils.infobar = "Modification des paramètres du compte...";
        }

        private void update_button_Click(object sender, RoutedEventArgs e)
        {
            var flag = false;
            user_name = update_name.Text;

            if (update_password.Password == update_confirm.Password)
                if (string.IsNullOrWhiteSpace(update_password.Password))
                    user_password = null;
                else
                    user_password = Utils.HashPass(update_password.Password);
            else
            {
                Utils.infobar = "Erreur : Le mot de passe ne correspond pas à la confirmation";
                flag = true;
            }

            if (!Register.isEmailValid(update_email.Text))
            {
                Utils.infobar = "Erreur : L'adresse email n'est pas valide";
                flag = true;
            }
            else
                user_email = update_email.Text;

            // If no flag was raised, update
            if (!flag)
            {
                client.UpdateAccount(user_id, user_name, user_password, user_email);
                Switcher.Switch(new CharacterSelection(), user_id);
                Utils.infobar = "Compte mis à jour";
            }
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            client.AccountDelete(user_id);

            Switcher.Switch(new Login());
        }
    }
}
