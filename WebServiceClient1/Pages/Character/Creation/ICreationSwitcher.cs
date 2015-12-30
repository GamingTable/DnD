using DnDServicePlayer.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DnDServicePlayer.Pages.Character.Creation
{
    interface ICreationSwitcher
    {
        string step_name { get; }
        bool condition_to_next { get; }
        Object DataContext { get; set; }
    }
}
