using DnDServicePlayer;
using DnDServicePlayer.Pages;
using System;
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
        //LoadingScreen loading_screen = new LoadingScreen();
        public PageSwitcher()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new Login());
            // Display a loading screen when visible
            //loader.Content = new LoadingScreen();

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
    }
}
