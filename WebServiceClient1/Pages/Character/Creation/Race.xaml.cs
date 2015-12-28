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
    public partial class Race : UserControl, ICreationSwitcher
    {
        public short_entity[] race_list { get; set; }
        private Service1Client client;
        public static complete_race current_race { get; set; }

        public Race()
        {
            InitializeComponent();

            // Get the races list
            client = new Service1Client();
            race_list = client.GetRaceShortList();

            // Define them as ItemsSource for the list
            race_list_box.DataContext = this;

            // Retrieve the current_race if selected
            if(current_race != null)
            {
                update_display();
            }
        }

        #region Display
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
        public string race_description
        {
            get { return current_race.description; }
        }
        #endregion
        #region Events
        private void race_list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            short_entity selection = (sender as ListBox).SelectedItem as short_entity;
            current_race = client.GetRace(selection.uid);

            // Refresh the image source
            update_display();
        }

        private void update_display()
        {
            image.Source = race_illustration;
            image.Stretch = Stretch.Uniform;

            description_display.Text = race_description;
        }
        #endregion
    }
}
