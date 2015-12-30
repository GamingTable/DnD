using DnDServicePlayer.ServiceReference1;
using System;
using System.Windows;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;

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
            get { return (current_race != null)?current_race.description:null; }
        }

        public string step_name
        {
            get { return "Choisissez Votre Race"; }
        }

        public bool condition_to_next
        {
            get
            {
                if (current_race != null)
                    return (current_race.uid > 0);
                else
                    return false;
            }
        }
        #endregion
        #region Events
        private void race_list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            short_entity selection = (sender as ListBox).SelectedItem as short_entity;
            current_race = client.GetRace(selection.uid);
            // A class is selected, condition is now true
            ((CharacterCreation)DataContext).next_button.IsEnabled = condition_to_next;

            // Refresh the image source
            update_display();
        }

        private void update_display()
        {
            image.Source = race_illustration;
            image.Stretch = Stretch.Uniform;
            description_display.Text = race_description;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Update condition onload
            ((CharacterCreation)DataContext).next_button.IsEnabled = condition_to_next;
        }
        #endregion

    }
}
