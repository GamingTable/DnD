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
        private uint account;
        private Service1Client client = new Service1Client();

        #region Define SubSwitchables
        public CharacterCreation()
        {
            InitializeComponent();

            current_step = 0;
            creation_steps = new List<ICreationSwitcher> {
                                    new Race(),
                                    new Classe(),
                                    new Stats(),
                                    new Gifts(),
                                    new Skills(),
                                    //new Spells(),
                                    new Background()};
            
            creation_controllers.Content = creation_steps[0];
            update_display();
        }

        public void UtilizeState(object state)
        {
            uint account_id = (uint)state;
            account = account_id;
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
            update_display();
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
                update_display();
            }
            else
            {
                add_new_character();
                Switcher.Switch(new CharacterSelection(), account);
                Utils.infobar = "Nouveau personnage créé !";
            }
        }
                

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CharacterSelection(), account);
            Utils.infobar = "Création annulée";
        }
        #endregion

        #region Making Character
        public void update_display()
        {
            Utils.infobar = "Création de personnage ( étape "+(current_step+1)+" sur " + creation_steps.Count+" )";
            creation_title.Text = creation_steps[current_step].step_name;
            next_button.DataContext = creation_steps[current_step];
        }
        #endregion

        #region Passing Character
        private void add_new_character()
        {
            // Race
            var selected_race   = Race.current_race;
            // Class
            var selected_class  = Classe.current_class;
            var selected_multiclass = new multiclass();
            //selected_multiclass.level_class = new List<Tuple<uint, complete_class>>(new Tuple<uint, complete_class>(1, selected_class))

            character new_character = new character()
            {
                account = this.account,
                /*race = selected_race,
                classes = selected_multiclass*/
            };
            /*{
                name            = ,
                avatar          = ,
                account         = this.account,

                race            = selected_race,
                classes         = selected_multiclass,
                stats           = ,
                gifts           = ,
                skills          = ,

                languages       = ,
                aptitudes       = ,
                inventory       = ,
                effects         = ,
                deity           = ,

                sex             = ,
                background      = ,
                personnality    = ,
                hair            = ,
                eyes            = ,
                skin            = ,
                height          = ,
                weight          = ,
                age             = ,
                height_category = ,       
        };*/

            client.CharacterCreate(new_character);
        }
        #endregion
    }
}
