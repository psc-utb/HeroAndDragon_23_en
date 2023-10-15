using System;
using System.Collections.Generic;
using System.Text;

namespace HeroAndDragon_NetStandard.Random
{
    public class Generator : System.Random
    {
        private static Generator? instance;
        public static Generator Instance
        {
            get
            {
                if (instance == null)
                    instance = new Generator();

                return instance;
            }
        }

        private Generator()
        {

        }
    }
}
