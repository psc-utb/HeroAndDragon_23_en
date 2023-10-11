using hrdina_a_drak.Nahoda;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace hrdina_a_drak.Postavy
{
    public abstract class Postava : Object, IComparable<Postava>
    {
        public string Jmeno { get; set; }
        public int Zdravi { get; set; }
        public int MaxPoskozeni { get; set; }
        public int MaxObrana { get; set; }

        protected Generator generovani = Generator.Instance;

        public event Action<Postava, Postava, int, int> DosloKUtoku;

        public Postava(string jmeno, int zdravi, int maxPoskozeni, int maxObrana)
        {
            this.Jmeno = jmeno;
            this.Zdravi = zdravi;
            this.MaxPoskozeni = maxPoskozeni;
            this.MaxObrana = maxObrana;
        }

        public virtual int Utok(Postava oponent)
        {
            int poskozeni = Convert.ToInt32(generovani.NextDouble() * MaxPoskozeni);
            int obrana = oponent.Obrana();
            poskozeni -= obrana;
            oponent.Zdravi -= poskozeni;

            DosloKUtoku?.Invoke(this, oponent, poskozeni, obrana);

            return poskozeni;
        }

        public virtual int Obrana()
        {
            int obrana = 0;
            //postava se brani, pokud dojde k vygenerovani 0,5 a výš
            //if (Math.Round(generovani.NextDouble()) == 1)
            if (generovani.NextDouble() <= 0.5)
            {
                obrana = generovani.Next(0, MaxObrana);
                Console.WriteLine($"Obrana postavy jménem {Jmeno} v hodnotě: " + obrana);
            }
            return obrana;
        }

        public bool JeZiva()
        {
            if (Zdravi > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual Postava VyberOponenta(List<Postava> postavy)
        {
            return VyberOponentaZakladni(postavy);
        }
        /*public virtual Postava VyberOponenta(List<Postava> postavy, Predicate<Postava> kontrolaOponenta)
        {
            return VyberOponentaZakladni(postavy, kontrolaOponenta);
        }*/

        //protected abstract bool KontrolaVyberuOponenta(Postava oponent);

        public virtual bool ExistujeOponent(List<Postava> postavy)
        {
            return VyberOponentaZakladni(postavy) != null ? true : false;
        }

        private Postava VyberOponentaZakladni(List<Postava> postavy)
        {
            return VyberOponentaZakladni(postavy, null);
        }

        protected Postava VyberOponentaZakladni(List<Postava> postavy, Predicate<Postava> kontrolaOponenta)
        {
            Postava oponent = null;

            foreach (var postava in postavy)
            {
                bool vysledekSpecialniKontrolyOponenta = kontrolaOponenta != null ? kontrolaOponenta(postava) : true;
                if (this != postava && postava.JeZiva() && vysledekSpecialniKontrolyOponenta)
                {
                    oponent = postava;
                    break;
                }
            }

            return oponent;
        }

        public override string ToString()
        {
            return $"Jméno: {Jmeno}, Síla: {VypocitejSilu()}, Zdraví: {Zdravi}, Max. Poškození: {MaxPoskozeni}, Max. Obrana: {MaxObrana}";
        }

        public int CompareTo([AllowNull] Postava other)
        {
            if (other == null)
                return 1;

            return this.VypocitejSilu().CompareTo(other.VypocitejSilu());

        }

        public virtual double VypocitejSilu()
        {
            return 0.2 * Zdravi + 0.4 * MaxPoskozeni + 0.4 * MaxObrana;
        }
    }
}
