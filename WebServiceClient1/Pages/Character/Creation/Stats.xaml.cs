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
        public static template current_stats { get; set; }

        public Stats()
        {
            InitializeComponent();

            client = new Service1Client();
            charac_list = client.GetCharacteristicShortList();

            //default_template.characteristics.Where

            // Define them as ItemsSource for the list
            charac_list_box.ItemsSource = default_template.characteristics;
            // Define the current_stats
            current_stats = default_template;
            current_stats.uid = 0;
            current_stats.name = null;
            current_stats.description = "AUTO GENERATED";
        }

        #region Button Handler
        private void increase_value_button_Click(object sender, RoutedEventArgs e)
        {
            //default_template.characteristics[i].value
        }
        private void decrease_value_button_Click(object sender, RoutedEventArgs e)
        {

        }
        private int get_assigned_points(uint id_characteristic)
        {
            return 0;
        }
        #endregion

        #region Default retrieving
        private template default_template
        {
            get
            {
                // 19 is the id of the default template
                // in the current DB
                return client.GetTemplate(19);
            }
        }
        private template race_template
        {
            get
            {
                return Race.current_race.template;
            }
        }
        private template class_template
        {
            get
            {
                return Classe.current_class.template;
            }
        }
        public static int get_modifier(int value)
        {
            return (int)(Math.Floor((decimal)value / 2) - 5);
        }
        /*private int str
        {
            get{
                return current_stats.characteristics.
            }
        }*/
        #endregion
    }
}
