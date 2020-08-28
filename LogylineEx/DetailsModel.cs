using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.IO;


namespace LogylineEx
{
    class DetailsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static ObservableCollection<Vehicule> details;
        private Vehicule currentVehicule;


        public DetailsModel()
        {
            Details = new ObservableCollection<Vehicule>();
            CurrentVehicule = new Vehicule("voiture A", 128, 4, 18000, 4, 17);
            Details.Add(CurrentVehicule);
            Details.Add(new Vehicule("voiture B", 85, 2, 17000, 4, 70));
            Details.Add(new Vehicule("voiture C", 250, 8, 125000, 4, 13));
            Details.Add(new Vehicule("voiture D", 430, 2, 250000, 4, 4));
            Details.Add(new Vehicule("Moto X", 250, 1, 180000, 2, 89));
            Details.Add(new Vehicule("Moto Y", 400, 1, 250000, 3, 50));
        }

        //ici NotifyPropertyChange n'est pas utile car les objects Vehicule ne sont jamais modifié
        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }



        public ObservableCollection<Vehicule> Details
        {
            get
            {
                return details;
            }
            set
            {
                if (value != details)
                {
                    details = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Vehicule CurrentVehicule
        {
            get
            {
                return currentVehicule;
            }
            set
            {
                if (value != currentVehicule)
                {
                    currentVehicule = value;
                    NotifyPropertyChanged();
                }
            }
        }

        //commande du boutton quitter
        private ICommand leave = new RelayCommand<MainWindow>((mainWindow) =>
        {
            mainWindow.Close();
        });

        public ICommand Export { get => export; }
        public ICommand IntoCSV { get => intoCSV; }
        public ICommand IntoXML { get => intoXML; }
        public ICommand OpenDetailWindow { get => openDetailWindow; }
        public ICommand Leave
        {
            get
            {
                return leave;
            }
        }


        /*
         * commande du boutton export
         * affiche les bouton CSV et XML
         */
        private ICommand export = new RelayCommand<Grid>((grid) =>
        {
            grid.Visibility = Visibility.Visible;
        });

        //commande du boutton CSV
        private ICommand intoCSV = new RelayCommand<ListBox>((listbox) =>
        {
            int items = listbox.Items.Count;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Nom,quantité,");
            foreach(Vehicule item in listbox.Items)
            {
                sb.AppendLine(item.ToString());
            }

            File.WriteAllText("CSVFile.csv", sb.ToString());
            MessageBox.Show("fichier sauvegardé");
        });

        //commande du boutton XML
        private ICommand intoXML = new RelayCommand<ListBox>((listbox) =>
        {
            int items = listbox.Items.Count;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<stock>");
            foreach (Vehicule item in listbox.Items)
            {
                sb.AppendLine("<vehicule>");
                sb.AppendLine("<name>" + item.Nom + "</name>");
                sb.AppendLine("<Quantite>"+ item.Quantite + "</Quantite>");
                sb.AppendLine("</vehicule>");
            }
            sb.AppendLine("</stock>");

            File.WriteAllText("XMLFile.xml", sb.ToString());
            MessageBox.Show("fichier sauvegardé");
        });


       

        //commande du boutton detail
        private ICommand openDetailWindow = new RelayCommand<int>((index) =>
        {
            if (index != -1)
            {
                Vehicule[] vehiculesList = DetailsModel.details.ToArray();
                Vehicule v = vehiculesList[index];
                Window1 newWindow = new Window1(v);
                newWindow.Show();
            }
            else
            {
                MessageBox.Show("selectioné un item");
            }
        });



}

}
