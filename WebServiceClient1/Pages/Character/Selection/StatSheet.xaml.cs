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

namespace DnDServicePlayer.Pages.Character.Selection
{
    /// <summary>
    /// Display the characteristics ordered by types according to the 3.5 official character sheet
    /// Display the list of owned aptitudes
    /// Display the avatar, background, personnality traits and physical characteristics
    /// Display the race, the list of classes, their level and the global level
    /// Display the deity, karma and alignment
    /// Could be the "public sheet" of a player if there's any
    /// </summary>
    public partial class StatSheet : UserControl, ISelectable
    {
        public StatSheet()
        {
            InitializeComponent();
        }
    }
}
