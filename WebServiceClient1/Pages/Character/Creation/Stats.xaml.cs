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
using System.ComponentModel;
using Xceed.Wpf.Toolkit;

namespace DnDServicePlayer.Pages.Character.Creation
{
    /// <summary>
    /// Logique d'interaction pour Stats.xaml
    /// </summary>
    public partial class Stats : UserControl, ICreationSwitcher
    {
        private Service1Client client;
        private template _mTemplate;
        public static template current_stats { get; set; }

        public Stats()
        {
            InitializeComponent();
            client = new Service1Client();

            // Define current_stats
            // It will help transfer default template points to characteristics
            // The final user template will include sums up current_stats and default template
            // Therefore, the race and the class-level templates are to be added after
            current_stats = new template();
            current_stats.characteristics = client.GetCharacteristics(0);
        }

        public string step_name
        {
            get { return "Répartissez vos points de Caractéristiques"; }
        }


        #region Button Handler
        private void increase_value_button_Click(object sender, RoutedEventArgs e)
        {
            var s = (Button)sender;
            s.IsEnabled = increaseValue((uint)s.Tag);
            updateDisplay();
        }

        private void decrease_value_button_Click(object sender, RoutedEventArgs e)
        {
            var s = (Button)sender;
            s.IsEnabled = decreaseValue((uint)s.Tag);
            updateDisplay();
        }

        private void updateDisplay()
        {
            //this.charac_itemscontrol.ItemsSource = current_characteristics;
            this.charac_counter_display.DataContext = current_characteristic_points;
        }

        private bool increaseValue(uint id_characteristic)
        {
            // cs are the temporary characteristics value increase
            // cp is the number of points available
            var cs = current_stats.characteristics.Where(c => c.uid == id_characteristic).Single().value;
            var cp = current_characteristic_points.value;

            if (cp-(cs+1) >= 0)
            {
                // increment the characteristic and reduces the points
                ++current_stats.characteristics.Where(c => c.uid == id_characteristic).Single().value;
                current_stats.characteristics.Where(c => c.uid == current_characteristic_points.uid).Single().value -= cs+1;
            }

            //Test if it can keep increasing
            return (cp-(cs+2) >= 0);
        }

        private bool decreaseValue(uint id_characteristic)
        {
            // cs are the temporary characteristics value increase
            var cs = current_stats.characteristics.Where(c => c.uid == id_characteristic).Single().value;

            if (cs > 0)
            {
                // decrement the characteristic and restore the points
                current_stats.characteristics.Where(c => c.uid == current_characteristic_points.uid).Single().value += cs;
                --current_stats.characteristics.Where(c => c.uid == id_characteristic).Single().value;
            }

            return (cs - 1 >= 0);
        }
        #endregion

        #region Default retrieving
        // Get the lvl 1 templates from race, class and default then sum it
        private template default_template
        {
            get { return _mTemplate; }
            set
            {
                if (Race.current_race != null && Classe.current_class != null )
                {
                    var template_list = new List<template>() {
                    Race.current_race.template,
                    client.GetClassTemplate(Classe.current_class.uid,1),
                    client.GetDefaultTemplate()};

                    var output_template = new template()
                    {
                        uid = 0,
                        name = "summed_template",
                        description = "AUTO GENERATED"
                    };
                    output_template.characteristics = Utils.SumTemplates(template_list);

                    _mTemplate = output_template;
                }
                else
                    _mTemplate = new template();
            }
        }

        // Return only the abilities from characteristics
        public List<characteristic> current_characteristics
        {
            get
            {
                if (default_template.characteristics == null)
                    return new List<characteristic>();
                var filtered = default_template.characteristics.Where(cc => cc.type.uid == 1);
                if (filtered.Count() > 0)
                    return filtered.ToList();
                else
                    return new List<characteristic>();
            }
        }

        // Return the characteristic corresponding to ability points for learning
        private characteristic current_characteristic_points
        {
            get
            {
                var filtered = default_template.characteristics.Where(cc => cc.uid == 22);
                if (filtered.Count() > 0)
                {
                    var rt = client.GetCharacteristic(22);
                    var ff = filtered.First();
                    var cs = current_stats.characteristics.Where(c => c.uid == ff.uid).Single();
                    rt.value += ff.value + cs.value;
                    return rt;
                }
                else
                    return client.GetCharacteristic(22);
            }
        }

        public bool condition_to_next
        {
            get
            {
                return (current_characteristic_points.value == 0);
            }
        }

        public static int get_modifier(int value)
        {
            return (int)(Math.Floor((decimal)value / 2) - 5);
        }

        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Force the setting of default_template
            default_template = null;
            //Reset every modifier for every characteristic
            Utils.SumTemplates(new List<template>() { default_template, current_stats }).ToList().ForEach(
                k => current_stats.characteristics.Where(l => l.uid == k.uid).Single().modifier 
                = get_modifier(k.value));

            //this.charac_stack.ItemsSource = current_characteristics;
            this.charac_itemscontrol.DataContext = this;
            this.charac_counter_display.DataContext = current_characteristic_points;

            //Update condition onload
            ((CharacterCreation)DataContext).next_button.IsEnabled = condition_to_next;
        }

        private void IntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            // Variables declaration
                // cs are the temporary characteristics value increase
                // cp is the number of points available
                // s is the updown counter
                // diff is the difference of value (positive or negative)
                // uid is the characteristic id
            var s = (IntegerUpDown)sender;
            var diff = (int)e.NewValue - (int)e.OldValue;
            var uid = (uint)s.Tag;
            var cs = current_stats.characteristics.Where(c => c.uid == uid ).Single().value;
            var cp = current_characteristic_points.value;

            // Treatment implementation
            //Check if abnormal values or max is reached
            if (cp < cs + diff)
            {
                s.Maximum = current_characteristics.Where(j=>j.uid == uid).Single().value;
            }
            else
            {
                //Update charac points label --> initial charac points label is on load
                //If the characteristic increments, the charac points decrement
                if (diff > 0)
                    current_stats.characteristics.Where(c => c.uid == current_characteristic_points.uid).Single().value -= cs + 1;
                //Otherwise, it increments
                else if (diff < 0)
                    current_stats.characteristics.Where(c => c.uid == current_characteristic_points.uid).Single().value += cs;
                //Update current_stats --> default template is initialized on load
                if (diff != 0)
                    current_stats.characteristics.Where(c => c.uid == uid).Single().value += diff;
            }

            //Validate if charac points = 0
            ((CharacterCreation)DataContext).next_button.IsEnabled = condition_to_next;

            updateDisplay();

        }

        private void IntegerUpDown_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize minimum value
            var s = (IntegerUpDown)sender;
            s.Minimum = default_template.characteristics.Where(k => k.uid == (uint)s.Tag).Single().value;
        }
    }
}
