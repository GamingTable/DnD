using DnDServicePlayer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DnDServicePlayer.Pages.Character.Creation
{
    interface ICreationSwitcher
    {
        string step_name { get; }
        /*property_observable step_properties
        {
            get; set;
        }
        character step_character
        {
            get; set;
        }*/
    }
}
