using DnDServicePlayer.ServiceReference1;
using System;
using System.Windows;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;

namespace DnDServicePlayer.Pages.Character.Creation
{
    /// <summary>
    /// Logique d'interaction pour Race.xaml
    /// </summary>
    public partial class Race : UserControl, ISwitchable
    {
        private short_entity[] race_list;
        private uint current_uid_race;
        private complete_race current_race;

        public Race()
        {
            InitializeComponent();

            // Get the races list
            Service1Client client = new Service1Client();
            race_list = client.GetRaceShortList();

            // Define them as ItemsSource for the list
            race_list_box.ItemsSource = race_list;

            // Try to display a random race
            ///////////////////////////////
            current_uid_race = 1;
            // Get the race
            current_race = client.GetRace(current_uid_race);

            // Define the image source
            image.Source = race_illustration;
            //image.DataContext = race_illustration;
            // Define the listview source
            listView.ItemsSource = current_race.template.characteristics;
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #region Race
        public ImageSource race_illustration
        {
            get{ return ImageCoder.BytesToSource(current_race.illustration); }
            set{ SetValue(System.Windows.Controls.Image.SourceProperty, value); }
        }
        private void race_list_box_Selected(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion
    }
}
