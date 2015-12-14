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
        private character hero;
        public BackgroundSheet()
        {
            InitializeComponent();

            template messtats = hero.stats;
            nom.Text = hero.name;
            race.Text = hero.race.name;
            //maclasse.Text = hero.classes.;
            vd.Text = hero.stats.characteristics[12].value.ToString();
            karma.Text = hero.stats.characteristics[24].value.ToString();
            align.Text = hero.stats.characteristics[25].value.ToString();
            level.Text = hero.stats.characteristics[12].value.ToString();
            dieu.Text = hero.deity.name;
        }
    }
}
