﻿using DnDServicePlayer;
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
using DnDServicePlayer.ServiceReference1;

namespace DnDServicePlayer.Pages.Character.Creation
{
    /// <summary>
    /// Logique d'interaction pour Spells.xaml
    /// </summary>
    public partial class Spells : UserControl, ICreationSwitcher
    {
        public Spells()
        {
            InitializeComponent();
        }

        public property_observable get_properties()
        {
            throw new NotImplementedException();
        }

        public character get_step_modif()
        {
            throw new NotImplementedException();
        }
    }
}
