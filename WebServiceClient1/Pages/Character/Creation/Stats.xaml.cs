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
            charac_stack.DataContext = this;
            // Define the current_stats
            //current_stats = default_template;
            //current_stats.description = "AUTO GENERATED";
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
        // Get the lvl 1 templates from race, class and default
        private template default_template
        {
            get
            {
                if (Race.current_race != null && Classe.current_class != null )
                {
                    var template_list = new List<template>() {
                    Race.current_race.template,
                    client.GetClassTemplate(Classe.current_class.uid,1),
                    client.GetDefaultTemplate() };

                    var output_template = new template()
                    {
                        uid = 0,
                        name = "summed_template",
                        description = "AUTO GENERATED"
                    };
                    output_template.characteristics = Utils.SumTemplates(template_list);

                    return output_template;
                }
                else
                    return new template();
            }
        }

        public string step_name
        {
            get
            {
                return "Répartissez vos points de Caractéristiques";
            }
        }

        public static int get_modifier(int value)
        {
            return (int)(Math.Floor((decimal)value / 2) - 5);
        }

        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.charac_stack.ItemsSource = default_template.characteristics;
        }
    }
}
