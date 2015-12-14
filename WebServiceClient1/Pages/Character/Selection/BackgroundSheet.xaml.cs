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

namespace DnDServicePlayer.Pages.Character.Selection
{
    /// <summary>
    /// Background, character particularities
    /// </summary>
    public partial class BackgroundSheet : UserControl, ISelectable
    {
        public BackgroundSheet()
        {
            InitializeComponent();

            nom.Text = CharacterSheet.hero.name;
            race.Text = CharacterSheet.hero.race.name;
            //maclasse.Text = hero.classes.;
            vd.Text = CharacterSheet.hero.stats[12].value.ToString();
            karma.Text = CharacterSheet.hero.stats[24].value.ToString();
            align.Text = CharacterSheet.hero.stats[25].value.ToString();
            level.Text = CharacterSheet.hero.classes.global_level.ToString();
            dieu.Text = CharacterSheet.hero.deity.name;
        }
    }
}
