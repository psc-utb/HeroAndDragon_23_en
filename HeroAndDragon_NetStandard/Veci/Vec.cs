using System;
using System.Collections.Generic;
using System.Text;

namespace hrdina_a_drak.Veci
{
    public class Vec
    {
        public string Jmeno { get; set; }

        public double Vaha { get; set; }

        public Vec(string jmeno_nazev, double vaha)
        {
            Jmeno = jmeno_nazev;
            Vaha = vaha;
        }
    }
}
