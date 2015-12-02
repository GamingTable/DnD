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
        Service1Client client;
        complete_race current_race;

        public Race()
        {
            InitializeComponent();

            // Get the races list
            client = new Service1Client();
            race_list = client.GetRaceShortList();

            // Define them as ItemsSource for the list
            race_list_box.ItemsSource = race_list;

            // Define the image source
            //image.Source = race_illustration;
            /*// Try to display a random race
            ///////////////////////////////
            current_uid_race = 1;
            // Get the race
            current_race = client.GetRace(current_uid_race);

            // Define the listview source
            listView.ItemsSource = current_race.template.characteristics;*/
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #region Race
        public ImageSource race_illustration
        {
            get
            {
                try
                {
                    return ImageCoder.BytesToSource(current_race.illustration);
                }
                catch (Exception e) { return null; }
            }
            set{ SetValue(System.Windows.Controls.Image.SourceProperty, value); }
        }
        #endregion

        private void race_list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            short_entity selection = (sender as ListBox).SelectedItem as short_entity;
            current_race = client.GetRace(selection.uid);

            // Refresh the image source
            update_image();
        }

        private void update_image()
        {
            image.Source = race_illustration;
            image.Stretch = Stretch.Uniform;
        }
    }
}
