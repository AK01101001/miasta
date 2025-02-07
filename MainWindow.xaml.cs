
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kres
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Miasto> miasta { get; set; } = new List<Miasto>();
        int index = 0;
        int ilosc = 0;
        string sciezka = "Data.txt";
        public MainWindow()
        {
            InitializeComponent();
            dodajMiasta();
        }

        private void dodajMiasta()
        {
            string[] dane= File.ReadAllLines(sciezka);
            for (int i = 0; i < dane.Length; i+=4)
            {               
                miasta.Add(new Miasto(dane[i], dane[i+1], dane[i+2], int.Parse(dane[i + 3])));
            }
            ilosc = (miasta.Count-1);
            wyswietl();
        }

        private void polubienie(object sender, RoutedEventArgs e)
        {
            miasta.ElementAt(index).LiczbaPolubien++;
            polubienia.Text=miasta.ElementAt(index).LiczbaPolubien.ToString();
        }

        private void lewo(object sender, RoutedEventArgs e)
        {
            index--;
            if (index<0)
            {
                index = ilosc;
            }
            
            wyswietl();
        }


        private void prawo(object sender, RoutedEventArgs e)
        {
            index++;
            if (index > ilosc)
            {
                index = 0;
            }
            wyswietl() ;
        }

        private void wyswietl()
        {
            nazwa.Text="nazwa: "+miasta.ElementAt(index).Nazwa;
            kontynent.Text= "kontynent: " + miasta.ElementAt(index).Kontynent;
            region.Text= "region: " + miasta.ElementAt(index).Region;
            mieszkancy.Text= "mieszkancy: " + miasta.ElementAt(index).LiczbaMieszkancow.ToString();
            polubienia.Text= "polubienia: " + miasta.ElementAt(index).LiczbaPolubien.ToString();
            zdjecie.Source = new BitmapImage(miasta.ElementAt(index).zdjecie);
        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            dodawanie dodawanie = new dodawanie();
            dodawanie.ShowDialog();
            // aktualizacja listy
            string[] dane = File.ReadAllLines(sciezka);
            miasta.Add(new Miasto(dane[dane.Length-4], dane[dane.Length - 3], dane[dane.Length - 2], int.Parse(dane[dane.Length-1])));
            ilosc = (miasta.Count - 1);
            MessageBox.Show(ilosc.ToString());
            wyswietl();
        }
    }
}