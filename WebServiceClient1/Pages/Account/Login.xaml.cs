﻿using DnDServiceClient;
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
            Utils.infobar = "Prêt";
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
            //Start long load procedure
            Utils.infobar = "Connexion...";
            Utils.loadscreen = true;
            
            //Retrieve the field values
            string log = text_username.Text;
            string pwd = Utils.HashPass(text_password.Password);

            //Test the connexion
            uint user_id = client.AccountConnection(log, pwd);
            if (user_id != 0)
            {

                Utils.infobar = "Connecté";
                Switcher.Switch(new CharacterSelection(), user_id);
            }
            else
            {
                Utils.infobar = "Echec de la connexion";
            }

            Utils.loadscreen = false;
        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Utils.connected = false;
        }
    }
}
