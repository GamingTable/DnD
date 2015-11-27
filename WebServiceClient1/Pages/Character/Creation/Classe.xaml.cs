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

        public Classe()
        {
            InitializeComponent();

            Service1Client client = new Service1Client();
            class_list = client.GetClassShortList();
        }

        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        #region Class
        private void class_list_box_Selected(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
}
