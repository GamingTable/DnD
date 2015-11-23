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
using WebServiceClient1.Pages;

namespace DnDServiceClient.Pages
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
        private List<character> ListOwnedCharacters()
        {
            Service1Client client = new Service1Client();
            return new List<character>(client.GetCharacters(user_id));
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
