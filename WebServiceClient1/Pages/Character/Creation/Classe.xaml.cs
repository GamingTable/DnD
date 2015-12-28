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
    public partial class Classe : UserControl, ICreationSwitcher
    {
        public short_entity[] class_list { get; set; }
        private Service1Client client;
        public static complete_class current_class { get; set; }
        //private CharacterCreation parent;

        public Classe()
        {
            InitializeComponent();

            // Get the races list
            client = new Service1Client();
            class_list = client.GetClassShortList();

            // Define them as ItemsSource for the list
            class_list_box.DataContext = this;

            // Retrieve the current_class if selected
            if (current_class != null)
            {
                update_display();
            }
        }

        #region Display
        public ImageSource class_illustration
        {
            get
            {
                try
                {
                    return ImageCoder.BytesToSource(current_class.illustration);
                }
                catch (Exception e) { return null; }
            }
            set { SetValue(System.Windows.Controls.Image.SourceProperty, value); }
        }
        public string class_description
        {
            get { return current_class.description; }
            set { }
        }
        #endregion
        #region Events
        private void class_list_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            short_entity selection = (sender as ListBox).SelectedItem as short_entity;
            current_class = client.GetClass(selection.uid);

            // Refresh the image source
            update_display();
        }

        private void update_display()
        {
            image.Source = class_illustration;
            image.Stretch = Stretch.Uniform;

            description_display.Text = class_description;
        }
        #endregion
    }
}
