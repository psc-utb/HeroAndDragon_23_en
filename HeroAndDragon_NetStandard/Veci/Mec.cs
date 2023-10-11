using System;
using System.Collections.Generic;
using System.Text;

namespace hrdina_a_drak.Veci
{
    public class Mec : Vec
    {
        public int Poskozeni { get; set; }

        public Mec(string nazev, double vaha, int poskozeni) : base(nazev, vaha)
        {
            Poskozeni = poskozeni;
        }
    }
}
