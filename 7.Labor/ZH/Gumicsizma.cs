using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    internal class Gumicsizma : IKifoghato
    {
        public double Tomeg { get { return 0.5; } }

        public bool Kifog()
        {
            return true;
        }
    }
}
