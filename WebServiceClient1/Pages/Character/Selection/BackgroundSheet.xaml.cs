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
    /// Logique d'interaction pour BackgroundSheet.xaml
    /// </summary>
    public partial class BackgroundSheet : UserControl, ISelectable
    {
        private ServiceReference1.Service1Client client;
        public BackgroundSheet()
        {
            InitializeComponent();

            /*nom.Text = hero.name;
            race.Text = hero.race.name;
            karma.Text = charac.stats.
            vd.Text =
            classe.Text = charac.classes;
            niveau.Text = charac.
            god.Text = hero.deity.name ;
            alignement.Text =
            background.Text = hero.background;*/
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            client = new ServiceReference1.Service1Client();
            /*if (client.updateBackground(background.Text, character_id.Text))
                MessageBox.Show("Mis à jour avec succès");
            else
                MessageBox.Show("échec de la mise à jour");*/
        }
    }
}
