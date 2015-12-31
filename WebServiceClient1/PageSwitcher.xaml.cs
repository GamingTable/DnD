using DnDServicePlayer;
using DnDServicePlayer.Pages;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DnDServiceClient
{
    /// <summary>
    /// Logique d'interaction pour PageSwitcher.xaml
    /// Fenêtre principale contenant l'ensemble des pages
    /// formant l'interface joueur
    /// </summary>
    public partial class PageSwitcher : Window
    {
        public static uint current_user {get; set;}
        public PageSwitcher()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new Login());
            
            Application.Current.MainWindow.BringIntoView();
        }

        public void Navigate(UserControl nextPage)
        {
            Container.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            Container.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }

        private void reduce_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DraggableWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                this.DragMove();
        }

        private void about_button_Click(object sender, RoutedEventArgs e)
        {
            if ((Visibility)FindResource("isAbout") == Visibility.Hidden)
                Resources["isAbout"] = Visibility.Visible;
            else
                Resources["isAbout"] = Visibility.Hidden;
        }

        private void button_manager_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new AccountManager(), current_user);
        }
    }
}
