using DnDServicePlayer.Pages.Character;
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
using System.ServiceModel;

namespace DnDServicePlayer.Pages
{
    /// <summary>
    /// Logique d'interaction pour CharacterSelection.xaml
    /// </summary>
    public partial class CharacterSelection : UserControl, ISwitchable
    {
        private uint user_id;
        private Service1Client client = new Service1Client();
        private character current_character;

        public CharacterSelection()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            user_id = (uint)state;
            characters_list.DataContext = this;
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
            Switcher.Switch(new CharacterCreation(), user_id);
        }

        private void select_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CharacterSheet(), current_character);
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Login());
            Utils.infobar = "Déconnecté";
            Utils.connected = false;
        }
        #endregion

        private void characters_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            short_character selection = (sender as ListBox).SelectedItem as short_character;
            current_character = client.GetCharacter(selection.uid);
            select_button.IsEnabled = true;
        }
    }
}
