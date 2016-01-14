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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FOR.Text = CharacterSheet.hero.stats[1].value.ToString();
            CON.Text = CharacterSheet.hero.stats[2].value.ToString();
            DEX.Text = CharacterSheet.hero.stats[3].value.ToString();
            INT.Text = CharacterSheet.hero.stats[4].value.ToString();
            SAG.Text = CharacterSheet.hero.stats[5].value.ToString();
            CHA.Text = CharacterSheet.hero.stats[6].value.ToString();

            modFOR.Text = (((int)CharacterSheet.hero.stats[0].value / 2) - 5).ToString();
            modCON.Text = (((int)CharacterSheet.hero.stats[1].value / 2) - 5).ToString();
            modDEX.Text = (((int)CharacterSheet.hero.stats[2].value / 2) - 5).ToString();
            modINT.Text = (((int)CharacterSheet.hero.stats[3].value / 2) - 5).ToString();
            modSAG.Text = (((int)CharacterSheet.hero.stats[4].value / 2) - 5).ToString();
            modCON.Text = (((int)CharacterSheet.hero.stats[5].value / 2) - 5).ToString();

            REF.Text = "0";
            VOL.Text = "0";
            VIG.Text = "0";
            CA.Text = "0";
            RM.Text = "0";
            INI.Text = "0";
            BA.Text = "0";
            BM.Text = "0";

            /*Personnage incomplet, ces valeurs ne pourraient pas s'afficher :s
            REF.Text = CharacterSheet.hero.stats[10].value.ToString();
            VOL.Text = CharacterSheet.hero.stats[11].value.ToString();
            VIG.Text = CharacterSheet.hero.stats[9].value.ToString();
            CA.Text = CharacterSheet.hero.stats[8].value.ToString();
            RM.Text = CharacterSheet.hero.stats[13].value.ToString();
            INI.Text = CharacterSheet.hero.stats[7].value.ToString();
            BA.Text = CharacterSheet.hero.stats[18].value.ToString();
            BM.Text = "0";*/
        }
    }
}
