using DnDServicePlayer;
using DnDServicePlayer.Pages;
using DnDServicePlayer.Pages.Character.Creation;
using DnDServicePlayer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DnDServicePlayer.Pages.Character
{
    /// <summary>
    /// Logique d'interaction pour CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : UserControl, ISwitchable
    {
        private List<ICreationSwitcher> creation_steps;
        private int current_step;
        public character new_character { get; set; }
        public List<short_entity> properties { get; set; }
        private Service1Client client = new Service1Client();

        #region Define SubSwitchables
        public CharacterCreation()
        {
            InitializeComponent();

            properties_tree.ItemsSource = properties;


            new_character = new character();
            current_step = 0;
            creation_steps = new List<ICreationSwitcher> {
                                    new Race(),
                                    new Classe(),
                                    new Stats(),
                                    new Gifts(),
                                    new Skills(),
                                    new Spells(),
                                    new Background()};

        }

        public void UtilizeState(object state)
        {
            uint account_id = (uint)state;
            new_character.account = account_id;
        }
        #endregion

        #region Button Interactions
        private void previous_button_Click(object sender, RoutedEventArgs e)
        {
            // Decrement step
            --current_step;
            // Test if it is the initial step for the previous button
            if (current_step <= 0)
                previous_button.IsEnabled = false;
            // Test if it is the final step for the next button
            if (!next_button.IsDefault)
            {
                next_button.Content = "Suivant";
                next_button.IsDefault = true;
            }
            // Display the current page of the creation steps
            creation_controllers.Content = creation_steps[current_step];
        }

        private void next_button_Click(object sender, RoutedEventArgs e)
        {
            // Is the inverse method of the previous_button_Click
            ++current_step;
            if (next_button.IsDefault)
            {
                if (!previous_button.IsEnabled)
                    previous_button.IsEnabled = true;
                if (current_step >= creation_steps.Count() - 1)
                {
                    next_button.IsDefault = false;
                    next_button.Content = "Valider";
                }
                creation_controllers.Content = creation_steps[current_step];
            }
            else
            {
                add_new_character();
                Switcher.Switch(new CharacterSelection());
            }
        }
                

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CharacterSelection());
        }
        #endregion

        #region Making Character
        public void update_display()
        {
            /*<property_observable> properties = new List<property_observable>();

            //  Race
            var race_properties = new property_observable();

            var race_switcher = (Race)creation_steps[0];
            var selected_race = race_switcher.current_race; 
            if(selected_race.uid > 0)
            {
                // Define the name
                race_properties.name = selected_race.name;

                // Define the characteristics boni of the race
                var charac_list = new List<Tuple<string, string>>();
                foreach(var charac in selected_race.template.characteristics)
                {
                    charac_list.Add(new Tuple<string, string>(
                        (charac.value>0)? "+" + charac.value.ToString(): charac.value.ToString(),
                        charac.abreviation));
                }
                race_properties.members.Add(new property_member() {
                    key = "Bonus de Caractéristiques",

                    });
            }*/
        }
        #endregion

        #region Passing Character
        private void add_new_character()
        {
            client.CharacterCreate(new_character);
        }
        #endregion
    }
}
