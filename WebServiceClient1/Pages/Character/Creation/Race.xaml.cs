using DnDServicePlayer.ServiceReference1;
using System;
using System.Windows;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace DnDServicePlayer.Pages.Character.Creation
{
    /// <summary>
    /// Logique d'interaction pour Race.xaml
    /// </summary>
    public partial class Race : UserControl, ISwitchable
    {
        private short_entity[] race_list;

        public Race()
        {
            InitializeComponent();

            // Get the races list
            Service1Client client = new Service1Client();
            race_list = client.GetRaceShortList();

            // Define them as ItemsSource for the list
            race_list_box.ItemsSource = race_list;

            // Define the image source
            var client2 = new Service1Client();
            var k = client2.GetRace(4);
            Console.WriteLine(k.name+"/////prout///////////////////////////////////////");
            //image.Source = ImageCoder.BytesToSource(client.GetRace(4).illustration);
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
    }
}
