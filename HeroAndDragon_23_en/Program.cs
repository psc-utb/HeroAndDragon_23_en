using hrdina_a_drak.Postavy;
using hrdina_a_drak.Veci;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hrdina_a_drak
{
    class Program
    {
        static void Main(string[] args)
        {
            //vybava
            Mec mec1 = new Mec("Stříbrný meč", 2.5, 175);
            Mec mec2 = new Mec("Daedrický meč", 4, 150);
            Stit stit2 = new Stit("Elfský štít", 2.5, 150);


            //Postava postava = new Postava("", 545, 484, 48);
            //hrdinove a draci
            Hrdina hrdina = new Hrdina("Geralt", 500, 175, 50);
            Drak drak = new Drak("Alduin", 350, 100, 40);
            Drak drak2 = new Drak("Šmak", 450, 75, 25);
            Hrdina hrdina2 = new Hrdina("Dovahkiin", 150, 75, 35, mec1);
            //Vlk vlk = new Vlk("Vlk", 50);


            List<Postava> postavy = new List<Postava>();
            postavy.Add(hrdina);
            postavy.Add(drak);
            postavy.Add(drak2);
            postavy.Add(hrdina2);

            postavy.Sort();
            Console.WriteLine(String.Join(Environment.NewLine, postavy));
            Console.WriteLine(Environment.NewLine + Environment.NewLine);

            double prumernaSila = postavy.Average(pos => pos.VypocitejSilu());
            Console.WriteLine($"Průměrná síla postav: {prumernaSila}");

            double nejmensiSila = postavy.Min(pos => pos.VypocitejSilu());
            Console.WriteLine($"Nejmenší síla postavy je: {nejmensiSila}");
            Postava nejslabsiPostava = postavy.Find(postava => postava.VypocitejSilu() == nejmensiSila);
            Console.WriteLine($"Nejslabší postava je: {nejslabsiPostava.ToString()}");

            List<Postava> silnePostavy = postavy.FindAll(postava => postava.VypocitejSilu() > prumernaSila);
            Console.WriteLine("Silné postavy (postavy se silou větší než průměr):");
            Console.WriteLine(String.Join(Environment.NewLine, silnePostavy));


            Console.WriteLine(Environment.NewLine + Environment.NewLine);


            postavy.ForEach(postava => postava.DosloKUtoku += VypisInformaciOUtoku);


            for (int i = 0; JeMozneVybratOponenta(postavy); ++i)
            {
                Console.WriteLine("Kolo č. " + i);

                for (int j = 0; j < postavy.Count; ++j)
                {
                    Postava utocnik = postavy[j];
                    if (utocnik.JeZiva())
                    {
                        Postava oponent = utocnik.VyberOponenta(postavy);
                        if (oponent != null)
                            utocnik.Utok(oponent);
                        else
                            continue;

                        Console.WriteLine(Environment.NewLine + Environment.NewLine);
                    }
                }
            }

            Console.WriteLine("Vítězové:");
            foreach (var pos in postavy)
            {
                if (pos.JeZiva())
                {
                    Console.WriteLine(pos.ToString());
                }
            }
            Console.WriteLine("Poražení:");
            foreach (var pos in postavy)
            {
                if (!pos.JeZiva())
                {
                    Console.WriteLine(pos.ToString());
                }
            }

            /*
            if (PocetZivychHrdinu(postavy) > 0)
            {
                Console.WriteLine("hrdinové vyhráli");
            }
            else if (PocetZivychDraku(postavy) > 0)
            {
                Console.WriteLine("draci vyhráli");
            }
            else
            {
                Console.WriteLine("Nikdo nevyhrál");
            }*/

        }

        public static bool JeMozneVybratOponenta(List<Postava> postavy)
        {
            foreach (Postava postava in postavy)
            {
                if (postava.JeZiva() && postava.ExistujeOponent(postavy))
                {
                    return true;
                }
            }
            return false;
        }

        /*
        public static int PocetZivychHrdinu(List<Postava> postavy)
        {
            int pocetZivychHrdinu = 0;
            foreach (Postava postava in postavy)
            {
                if (postava is Hrdina && postava.JeZiva())
                {
                    ++pocetZivychHrdinu;
                }
            }
            return pocetZivychHrdinu;
        }

        public static int PocetZivychDraku(List<Postava> postavy)
        {
            int pocetZivychHrdinu = 0;
            foreach (Postava postava in postavy)
            {
                if (postava is Drak && postava.JeZiva())
                {
                    ++pocetZivychHrdinu;
                }
            }
            return pocetZivychHrdinu;
        }*/

        public static void VypisInformaciOUtoku(Postava utocnik, Postava oponent, int poskozeni, int obrana)
        {
            Console.WriteLine($"Utok {utocnik.Jmeno} v hodnotě: " + poskozeni);
            Console.WriteLine($"Oponentovi jménem {oponent.Jmeno} zbývá zdraví o hodnotě: " + oponent.Zdravi);
        }
    }
}
