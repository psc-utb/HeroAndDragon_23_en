using System;
using System.Collections.Generic;
using System.Text;

namespace hrdina_a_drak.Nahoda
{
    public class Generator : Random
    {
        private static Generator instance;
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
