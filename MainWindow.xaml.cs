
using System;
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
        public MainWindow()
        {
            InitializeComponent();
            dodajMiasta();
        }

        private void dodajMiasta()
        {
            miasta.Add(new Miasto("Jinzhou","Huanglong","Jinzhou",1000000,0,new Uri("obraz3.png")));
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
                index = miasta.Count;
            }
            
            wyswietl();
        }


        private void prawo(object sender, RoutedEventArgs e)
        {
            index++;
            if (index > miasta.Count)
            {
                index = 0;
            }
        }

        private void wyswietl()
        {
            nazwa.Text=miasta.ElementAt(index).Nazwa;
            kontynent.Text=miasta.ElementAt(index).Kontynent;
            region.Text=miasta.ElementAt(index).Region;
            mieszkancy.Text=miasta.ElementAt(index).LiczbaMieszkancow.ToString();
            polubienia.Text=miasta.ElementAt(index).LiczbaPolubien.ToString();
            zdjecie.Source = new BitmapImage(miasta.ElementAt(index).zdjecie);
        }
    }
}