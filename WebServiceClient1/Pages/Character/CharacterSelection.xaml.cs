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

namespace DnDServicePlayer.Pages
{
    /// <summary>
    /// Logique d'interaction pour CharacterSelection.xaml
    /// </summary>
    public partial class CharacterSelection : UserControl, ISwitchable
    {
        private uint user_id;
        public CharacterSelection()
        {
            InitializeComponent();
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            user_id = (uint)state;
        }
        #endregion

        #region List Characters
        /*private List<short_character> ListOwnedCharacters()
        {
            DnDServiceClient client = new DnDServicePlayer();
            Service1Client client = new Service1Client();
            return new List<short_character>(client.GetCharacters(user_id));
        }*/
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
