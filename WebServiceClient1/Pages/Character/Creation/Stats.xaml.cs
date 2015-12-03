using DnDServicePlayer;
using DnDServicePlayer.ServiceReference1;
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

namespace DnDServicePlayer.Pages.Character.Creation
{
    /// <summary>
    /// Logique d'interaction pour Stats.xaml
    /// </summary>
    public partial class Stats : UserControl, ICreationSwitcher
    {
        private Service1Client client;
        private short_entity[] charac_list;

        public Stats()
        {
            InitializeComponent();

            client = new Service1Client();
            charac_list = client.GetCharacteristicShortList();

            // Define them as ItemsSource for the list
            charac_list_box.ItemsSource = charac_list;
        }

        
        public property_observable get_properties()
        {
            throw new NotImplementedException();
        }

        public character get_step_modif()
        {
            throw new NotImplementedException();
        }
    }
}
