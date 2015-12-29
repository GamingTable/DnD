using DnDServicePlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DnDServicePlayer.ServiceReference1;
using System.ComponentModel;

namespace DnDServicePlayer.Pages.Character.Creation
{
    /// <summary>
    /// Logique d'interaction pour Background.xaml
    /// </summary>
    public partial class Background : UserControl, ICreationSwitcher
    {
        public Background()
        {
            InitializeComponent();
        }

        public bool condition_to_next
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string step_name
        {
            get
            {
                return "Qui incarnerez-Vous ?";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
