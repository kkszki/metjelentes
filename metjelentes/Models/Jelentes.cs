using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metjelentes.Models
{
    internal class Jelentes
    {
        public Jelentes(string telepules, string ido, string szel, byte homerseklet)
        {
            Telepules = telepules;
            Ido = ido;
            Szel = szel;
            Homerseklet = homerseklet;
        }

        public Jelentes(string sor)
        {
            string[] adatok=sor.Split(' ');
            Telepules = adatok[0];
            Ido = adatok[1];
            Szel = adatok[2];
            Homerseklet = byte.Parse(adatok[3]);
        }
        public Jelentes() { }

        public string Telepules { get; set; }
        public string Ido {  get; set; }
        public string Szel { get; set; }
        public byte Homerseklet {  get; set; }

        public string SzelIrany()
        {
            return Szel.Substring(0, 3);
        }
        public int SzelSebesseg()
        {
            return int.Parse(Szel.Substring(3));
        }
        public byte Ora()
        {
            return byte.Parse(Ido.Substring(0,2));
        }
        public byte Perc()
        {
            return byte.Parse(Ido.Substring(2));
        }

    }
}
