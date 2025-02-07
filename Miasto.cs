using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kres
{
    public class Miasto
    {
        public string Nazwa { get; set; }
        public string Kontynent { get; set; }
        public string Region { get; set; }
        public int LiczbaMieszkancow { get; set; }
        public int LiczbaPolubien { get; set; }
        public Uri zdjecie { get; set; }
        static int licznik = 0;

        public Miasto(string nazwa, string kontynent, string region, int liczbaMieszkancow)
        {
            Nazwa = nazwa;
            Kontynent = kontynent;
            Region = region;
            LiczbaMieszkancow = liczbaMieszkancow;
            LiczbaPolubien = 0;
            licznik++;
            zdjecie = new Uri("m" + licznik + ".png",UriKind.Relative);           
        }
    }
}
