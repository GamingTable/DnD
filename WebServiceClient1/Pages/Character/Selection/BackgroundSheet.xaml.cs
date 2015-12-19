﻿using DnDServicePlayer;
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

            background.Text = CharacterSheet.hero.background;

            sex.Text = CharacterSheet.hero.sex.ToString();
            hairs.Text = CharacterSheet.hero.hair;
            eyes.Text = CharacterSheet.hero.eyes;
            weight.Text = CharacterSheet.hero.weight.Item1.ToString();
            height.Text = CharacterSheet.hero.height.Item1.ToString();
            age.Text = CharacterSheet.hero.age.Item1.ToString();
        }

        private void background_TextInput(object sender, TextCompositionEventArgs e)
        {
            CharacterSheet.heroUpdate.background = background.Text;
        }

        private void sex_TextChanged(object sender, TextChangedEventArgs e)
        {
            CharacterSheet.heroUpdate.sex = e.ToString()[0];
        }

        private void hairs_TextChanged(object sender, TextChangedEventArgs e)
        {
            CharacterSheet.heroUpdate.hair = e.ToString();
        }

        private void eyes_TextChanged(object sender, TextChangedEventArgs e)
        {
            CharacterSheet.heroUpdate.eyes = e.ToString();
        }

        /*private void weight_TextChanged(object sender, TextChangedEventArgs e)
        {
            uint temp;
            string tmp = e.ToString();
            if(UInt32.TryParse(tmp, out temp))
                {
                    CharacterSheet.heroUpdate.weight.Item1 = temp;//it works
                }
        }*/
    }
}
