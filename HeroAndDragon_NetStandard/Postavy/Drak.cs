using System;
using System.Collections.Generic;
using System.Text;

namespace hrdina_a_drak.Postavy
{
    public class Drak : Postava
    {
        public Drak(string jmeno, int zdravi, int maxPoskozeni, int maxObrana) : base(jmeno, zdravi, maxPoskozeni, maxObrana)
        {

        }

        public override Postava VyberOponenta(List<Postava> postavy)
        {
            return this.VyberOponentaZakladni(postavy, oponent => oponent.GetType() != this.GetType());
        }

        public override bool ExistujeOponent(List<Postava> postavy)
        {
            return base.VyberOponentaZakladni(postavy, oponent => oponent.GetType() != this.GetType()) != null ? true : false;
        }
    }
}
