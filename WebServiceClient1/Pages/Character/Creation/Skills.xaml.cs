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
    /// Logique d'interaction pour Skills.xaml
    /// </summary>
    public partial class Skills : UserControl, ICreationSwitcher
    {
        public Skills()
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
                return "Choisissez vos Compétences";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
