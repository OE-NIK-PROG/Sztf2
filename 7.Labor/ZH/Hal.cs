using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    public class Hal : IKifoghato
    {
        double tomeg;
        bool szalkas;
        public double Tomeg { get { return tomeg; } }

        public bool Szalkas { get { return szalkas; } }

        public Hal(double tomeg) { this.tomeg = tomeg; }
        public Hal(double tomeg, bool szalkas) { this.tomeg = tomeg; this.szalkas = szalkas; }
        public virtual bool Kifog()
        {
            return true;
        }
    }
}
