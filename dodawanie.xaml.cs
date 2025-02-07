using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
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

namespace kres
{
    /// <summary>
    /// Logika interakcji dla klasy dodawanie.xaml
    /// </summary>
    public partial class dodawanie : Window
    {
        public dodawanie()
        {
            InitializeComponent();
        }

        private void zatwierdz(object sender, RoutedEventArgs e)
        {
            if (nazwa.Text!=""&& kontynent.Text != "" && region.Text != "" && miesszkancy.Text != "")
            {
                if (int.TryParse(miesszkancy.Text, out int mieszkancy))
                {
                    string[] dane = {nazwa.Text, kontynent.Text, region.Text, mieszkancy.ToString() };
                File.AppendAllLines("Data.txt", dane);
                Close();
                }
                else
                {
                    MessageBox.Show("pole mieszkancy musi byc liczbą mieszkanców");
                }

            }
            else
            {
                MessageBox.Show("podaj wszystkie dane");
            }
            
        }
    }
}
