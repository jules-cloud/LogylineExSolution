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
using System.Windows.Shapes;

namespace LogylineEx
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Vehicule myVehicule;
        public Window1(Vehicule pvehicule)
        {
            InitializeComponent();
            this.myVehicule = pvehicule;
            Nom.Content = myVehicule.Nom;
            chevaux.Content = myVehicule.NbChevaux;
            places.Content = myVehicule.NbPlaces;
            prix.Content = myVehicule.Prix;
            roues.Content = myVehicule.NbRoues;

        }
    }
}
