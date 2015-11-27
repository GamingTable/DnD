using DnDServicePlayer.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DnDServicePlayer.Pages.Character.Creation
{
    /// <summary>
    /// Logique d'interaction pour RaceClasse.xaml
    /// </summary>
    public partial class RaceClasse : UserControl, ISwitchable
    {
        private short_entity[] race_list;
        private short_entity[] class_list;

        public RaceClasse()
        {
            InitializeComponent();

           Service1Client client = new Service1Client();

            race_list = client.GetRaceShortList();
            class_list = client.GetClassShortList();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #region Race
        private void race_list_box_Selected(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion

        #region Class
        private void class_list_box_Selected(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
