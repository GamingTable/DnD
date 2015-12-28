using System.Windows;
using System.Windows.Controls;

namespace DnDServicePlayer
{
    /// <summary>
    /// Logique d'interaction pour AboutUs.xaml
    /// </summary>
    public partial class AboutUs : UserControl
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Resources["isAbout"] = Visibility.Hidden;
        }
    }
}
