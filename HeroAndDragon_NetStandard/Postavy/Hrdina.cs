using hrdina_a_drak.Veci;
using System;
using System.Collections.Generic;
using System.Text;

namespace hrdina_a_drak.Postavy
{
    public class Hrdina : Postava
    {
        public Mec Mec { get; set; }
        public Stit Stit { get; set; }

        public Hrdina(string jmeno, int zdravi, int maxPoskozeni, int maxObrana, Mec mec, Stit stit = null) : base(jmeno, zdravi, maxPoskozeni, maxObrana)
        {
            this.Mec = mec;
            this.Stit = stit;
        }

        public Hrdina(int zdravi, int maxPoskozeni, int maxObrana) : base (String.Empty, zdravi, maxPoskozeni, maxObrana)
        {

        }

        public Hrdina(string jmeno, int zdravi, int maxPoskozeni, int maxObrana) : this(jmeno, zdravi, maxPoskozeni, maxObrana, null, null)
        {

        }

        public override int Utok(Postava oponent)
        {
            //přidání poškození meče je na vás, toto jen volá stejnou metodu z rodičovské třídy Postava
            return base.Utok(oponent);
        }

        public override int Obrana()
        {
            //přidání obrany štítu je na vás, toto jen volá stejnou metodu z rodičovské třídy Postava
            return base.Obrana();
        }

        public override Postava VyberOponenta(List<Postava> postavy)
        {
            for (int i = 0; i < postavy.Count * 2; ++i)
            {
                int indexVygenerovany = generovani.Next(0, postavy.Count);
                if(this != postavy[indexVygenerovany] && postavy[indexVygenerovany].JeZiva())
                {
                    return postavy[indexVygenerovany];
                }
            }


            return base.VyberOponenta(postavy);
        }

        public override double VypocitejSilu()
        {
            return 0.3 * Zdravi + 0.4 * (MaxPoskozeni + Mec?.Poskozeni ?? 0) + 0.3 * (MaxObrana + Stit?.Zbroj ?? 0);
        }
    }
}
