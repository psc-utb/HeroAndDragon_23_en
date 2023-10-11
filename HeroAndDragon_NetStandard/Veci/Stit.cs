using System;
using System.Collections.Generic;
using System.Text;

namespace hrdina_a_drak.Veci
{
    public class Stit : Vec
    {
        public int Zbroj { get; set; }

        public Stit(string nazev, double vaha, int zbroj) : base(nazev, vaha)
        {
            Zbroj = zbroj;
        }
    }
}
