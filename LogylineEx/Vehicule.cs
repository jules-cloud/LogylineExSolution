using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogylineEx
{
    public class Vehicule
    {
        private string nom;

        private int nbChevaux;
        
        private int nbPlaces;
        
        private int prix;
        
        private int nbRoues;

        private int quantite;

        public string Nom { get => nom; set => nom = value; }
        public int NbChevaux { get => nbChevaux; set => nbChevaux = value; }
        public int NbPlaces { get => nbPlaces; set => nbPlaces = value; }
        public int Prix { get => prix; set => prix = value; }
        public int NbRoues { get => nbRoues; set => nbRoues = value; }
        public int Quantite { get => quantite; set => quantite = value; }

        public Vehicule()
        {
            nom = "";
            nbChevaux = 0;
            nbPlaces = 0;
            prix = 0;
            nbRoues = 0;
        }
        public Vehicule(String pNom,int pnbChevaux, int pnbPlaces,int pPrix ,int pnbRoues,int pquantite)
        {
            nom = pNom;
            nbChevaux = pnbChevaux;
            nbPlaces = pnbPlaces;
            prix = pPrix;
            nbRoues = pnbRoues;
            quantite = pquantite;
        }
        
        public override string ToString()
        {
            return Nom + "," + Quantite + ",";
        }
    }
}
