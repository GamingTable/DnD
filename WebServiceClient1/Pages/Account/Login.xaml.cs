using DnDServiceClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DnDServicePlayer.Pages
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : UserControl, ISwitchable
    {
        private ServiceReference1.Service1Client client;
        public Login()
        {
            InitializeComponent();
            client = new ServiceReference1.Service1Client();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Switch Pages
        private void register_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Register());
        }

        private void connection_button_Click(object sender, RoutedEventArgs e)
        {
            string log = text_username.Text;
            string pwd = text_password.Password;

            uint user_id = client.AccountConnection(log, pwd);
            if (user_id != 0)
            {
                hid_label.Content = "connecté";
                Switcher.Switch(new CharacterSelection(), user_id);
            }
            else
            {
                hid_label.Content = "Echec de la connexion";
            }
            hid_label.Visibility = Visibility.Visible;
        }
        #endregion
    }
}
