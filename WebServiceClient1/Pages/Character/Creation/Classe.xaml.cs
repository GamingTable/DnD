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

namespace DnDServicePlayer.Pages.Character.Creation
{
    /// <summary>
    /// Logique d'interaction pour Classe.xaml
    /// </summary>
    public partial class Classe : UserControl, ISwitchable
    {
        private short_entity[] class_list;
        private Service1Client client;

        public Classe()
        {
            InitializeComponent();

            client = new Service1Client();
            class_list = client.GetClassShortList();

            // Define them as ItemsSource for the list
            classe_list_box.ItemsSource = class_list;
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #region Class
        private void classe_list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id_class = classe_list_box.SelectedIndex+1;
            if(id_class>0)
            {
                //client
            }
        }
        #endregion
    }
}
