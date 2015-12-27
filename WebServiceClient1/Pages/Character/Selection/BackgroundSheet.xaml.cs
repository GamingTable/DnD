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

            reload();
        }
        private void reload()
        {
            nom.Text = CharacterSheet.hero.name;
            race.Text = CharacterSheet.hero.race.name;
            //maclasse.Text = hero.classes.;
            vd.Text = CharacterSheet.hero.stats[12].value.ToString();
            karma.Text = CharacterSheet.hero.stats[24].value.ToString();
            align.Text = CharacterSheet.hero.stats[25].value.ToString();
            //level.Text = GetGlobalLevel(CharacterSheet.hero.classes);
            try
            {
                dieu.Text = CharacterSheet.hero.deity.name;
            }
            catch
            {
                dieu.Text = "No God Set";
            }
            try
            {
                background.Text = CharacterSheet.hero.background;
            }
            catch
            {
                background.Text = "No background Set";
            }
            try
            {
                sex.Text = CharacterSheet.hero.sex.ToString();
            }
            catch
            {
                sex.Text = "Set M or F";
            }
            try
            {
                hairs.Text = CharacterSheet.hero.hair;
            }
            catch
            {
                hairs.Text = "No hair color Set";
            }
            try
            {
                eyes.Text = CharacterSheet.hero.eyes;
            }
            catch
            {
                eyes.Text = "No eyes color set";
            }
            try
            {
                weight.Text = CharacterSheet.hero.weight.Item1.ToString();
            }
            catch
            {
                weight.Text = "No Weight Set";
            }
            try
            {
                height.Text = CharacterSheet.hero.height.Item1.ToString();
            }
            catch
            {
                height.Text = "No height set";
            }
            try
            {
                age.Text = CharacterSheet.hero.age.Item1.ToString();
            }
            catch
            {
                age.Text = "No Age Set";
            }
        }

        private void background_TextInput(object sender, TextCompositionEventArgs e)
        {
            CharacterSheet.heroUpdate.background = background.Text;
        }

        private void sex_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.ToString()[0] != 'F' && e.ToString()[0] != 'f' && e.ToString()[0] != 'M' && e.ToString()[0] != 'm')
                CharacterSheet.heroUpdate.sex = e.ToString().ToUpper()[0];
            else
                MessageBox.Show("La valeur que vous avez rentré ne convient pas.\r\nMerci de rentrer 'F' ou 'f' si votre personnage est une femme, 'M' ou 'm' si c'est un homme", "Erreur");
        }

        private void hairs_TextChanged(object sender, TextChangedEventArgs e)
        {
            CharacterSheet.heroUpdate.hair = e.ToString();
        }

        private void eyes_TextChanged(object sender, TextChangedEventArgs e)
        {
            CharacterSheet.heroUpdate.eyes = e.ToString();
        }

        private void weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            uint temp;
            if(UInt32.TryParse(e.ToString(), out temp))
                {
                    Tuple<uint, category> mytuple = new Tuple<uint, category>(temp, CharacterSheet.hero.weight.Item2);
                    CharacterSheet.heroUpdate.weight = mytuple;
                }
            else
            {
                MessageBox.Show("La valeur que vous avez rentré ne convient pas.\r\nMerci de rentrer un entier non signé", "Erreur de type");
            }
        }

        private void height_TextChanged(object sender, TextChangedEventArgs e)
        {
            uint temp;
            if (UInt32.TryParse(e.ToString(), out temp))
            {
                Tuple<uint, category> mytuple = new Tuple<uint, category>(temp, CharacterSheet.hero.height.Item2);
                CharacterSheet.heroUpdate.height = mytuple;
            }
            else
            {
                MessageBox.Show("La valeur que vous avez rentré ne convient pas.\r\nMerci de rentrer un entier non signé", "Erreur de type");
            }
        }

        private void age_TextChanged(object sender, TextChangedEventArgs e)
        {
            uint temp;
            if (UInt32.TryParse(e.ToString(), out temp))
            {
                Tuple<uint, category> mytuple = new Tuple<uint, category>(temp, CharacterSheet.hero.age.Item2);
                CharacterSheet.heroUpdate.age = mytuple;
            }
            else
            {
                MessageBox.Show("La valeur que vous avez rentré ne convient pas.\r\nMerci de rentrer un entier non signé", "Erreur de type");
            }
        }
    }
}
