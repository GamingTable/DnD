﻿using DnDServicePlayer.Pages.Character;
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
using DnDServicePlayer.Pages;

namespace DnDServicePlayer.Pages
{
    /// <summary>
    /// Logique d'interaction pour CharacterSelection.xaml
    /// </summary>
    public partial class CharacterSelection : UserControl, ISwitchable
    {
        private uint user_id;
        private Service1Client client = new Service1Client();

        public CharacterSelection()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            user_id = (uint)state;
            characters_list.ItemsSource = owned_characters;
        }
        #endregion

        #region List Characters
        public List<short_character> owned_characters
        {
            get
            {
                var new_list_char = new List<short_character>();
                foreach (var c in client.GetCharacters(user_id))
                    new_list_char.Add(c);
                return new_list_char;
            }
        }
        #endregion

        #region Switch Pages
        private void create_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CharacterCreation());
        }

        private void select_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CharacterSheet());
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Login());
        }
        #endregion
    }
}
