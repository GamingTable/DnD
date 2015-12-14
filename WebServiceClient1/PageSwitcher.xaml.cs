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
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! "
                  + nextPage.Name.ToString());
        }
    }
}
