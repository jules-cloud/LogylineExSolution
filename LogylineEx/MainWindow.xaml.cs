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
using System.Threading;
using System.IO;

namespace LogylineEx
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Thread newThread = new Thread(new ThreadStart(TrieTable));
            Thread newThread2 = new Thread(new ThreadStart(FiboWrite));
            Thread newThread3 = new Thread(new ThreadStart(Palindrome));
            newThread.Start();
            newThread2.Start();
            newThread3.Start();
            InitializeComponent();



        }
        
        /**
         * creée un tableau de 100000cases et le remplit
         * 
         **/
        private void TrieTable()
        {
            var rand = new Random();
            int n = 100000;
            int[] table = new int[n];
            for(int x=0; x<n; x++)
            {
                table[x] = rand.Next(101);
            }


            for (int i = 2; i <= n-1; i++)
            {
                int c = table[i];
                int j = i;
                while (j>0 && table[j - 1] > c)
                {
                    table[j] = table[j - 1];
                    j = j - 1;
                }
                table[j] = c;
            }
        }
        /*****************************************************************************************************************
        *ecrit les 20 premiers thermes de la suite de fibonacci
        *
        **/

        private void FiboWrite()
        {
            File.WriteAllText("Fibo.txt", "");
            for(int i=0;i<20;i++)
            {
                using (StreamWriter sw = File.AppendText("Fibo.txt"))
                {
                    sw.WriteLine(Fibo(i));
                    sw.Close();
                }
            }
           
        }

        /**
         * renvoie l'entier correspondant au therme de fibonacci a l'index n
         **/
        private int Fibo(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            int res = Fibo(n - 1) + Fibo(n - 2);
            return res;
        }
        /*****************************************************************************************************************/
        /**
         * crée un tableau de mot aleatoire et ecrit les mots palindromes de ce tableau dans un fichier
         **/
        private void Palindrome()
        {
            File.WriteAllText("Palindrome.txt", "");
            string tmp;
            Random rand = new Random();
            string[] strTable = new string[50000];
            for (int j = 0; j < 50000; j++)
            {
                tmp = "";
                int length = rand.Next(2, 7);
                for (int i = 0; i < length; i++)
                {
                    tmp += (char)('a' + rand.Next(14));
                }
                strTable[j] = tmp;
                
            }

            for (int k = 0; k < 50000; k++)
            {
                if (IsPalindrome(strTable[k]) == true)
                {
                    using (StreamWriter sw = File.AppendText("Palindrome.txt"))
                    {
                        sw.WriteLine(strTable[k]);
                        sw.Close();
                    }
                }
            }
        }
        /**
         * determine si un mot est un palindrome ou non
         **/
        private Boolean IsPalindrome(String str)
        {
            int half = (int)str.Length/2;
            string start = str.Substring(0, half);
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);

            string tmp = new string(arr);
            string end = tmp.Substring(0, half);
            bool res = end.Equals(start);
            return res;

        }

    }
}
