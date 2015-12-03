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
        property_observable get_properties();
        character get_step_modif();
    }
}
