using DnDServicePlayer.Pages.Character.Selection;
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

namespace DnDServicePlayer.Pages
{
    /// <summary>
    /// Frame where every subsheet displays
    /// </summary>
    public partial class CharacterSheet : UserControl
    {
        private List<ISelectable> sheet_pages;
        private int current_page;
        public static character hero { get; set; }
        private Service1Client client = new Service1Client();

        #region Define Pages
        public CharacterSheet()
        {
            InitializeComponent();

            current_page = 0;
            sheet_pages = new List<ISelectable> {
                                    new StatSheet(),
                                    new SpecialSheet(),
                                    new InventorySheet(),
                                    new SpellbookSheet(),
                                    new AdventureSheet(),
                                    new DiscussionSheet(),
                                    new OptionSheet() };
        }

        public void UtilizeState(object state)
        {
            hero = (character)state;

        }

        private void change_page(object sender, RoutedEventArgs e)
        {
            var b = e.Source as Button;
            current_page = (int)b.Tag;
            sheet_controllers.Content = sheet_pages[current_page];
        }
        #endregion

        #region Button Interactions
        /*private void previous_button_Click(object sender, RoutedEventArgs e)
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
        }*/


        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new CharacterSelection());
        }
        #endregion

    }
}
