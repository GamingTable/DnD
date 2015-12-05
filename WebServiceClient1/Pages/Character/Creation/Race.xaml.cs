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
        private short_entity[] race_list;
        private Service1Client client;
        public static complete_race current_race { get; set; }
        //private CharacterCreation parent;

        public Race()
        {
            InitializeComponent();

            // Get the races list
            client = new Service1Client();
            race_list = client.GetRaceShortList();

            // Define them as ItemsSource for the list
            race_list_box.ItemsSource = race_list;

            // Keep the parent to make the character
            //parent = ((this.Parent as Grid).Parent as CharacterCreation);
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
        public string race_description { get; set; }
        #endregion
        #region Events
        private void race_list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            short_entity selection = (sender as ListBox).SelectedItem as short_entity;
            current_race = client.GetRace(selection.uid);

            race_description = selection.description;

            // Refresh the image source
            update_display();
        }

        private void update_display()
        {
            image.Source = race_illustration;
            image.Stretch = Stretch.Uniform;

            description_display.Text = race_description;
            //parent.update_display();

        }
        #endregion
        /*#region Communication
        public property_observable step_properties
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public character step_character
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion*/

    }
}
