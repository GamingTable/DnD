using DnDServiceClient;
using System.Windows.Controls;

namespace DnDServicePlayer
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    public static class Switcher
    {
        public static PageSwitcher pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(UserControl newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }
}