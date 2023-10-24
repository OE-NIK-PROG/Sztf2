using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZH
{
    internal class KisHal : Hal
    {
        public bool Aranyhal_e { get; private set; }

        public KisHal() { this.Aranyhal_e = false; }
        public KisHal(bool aranyhal_e) { this.Aranyhal_e = aranyhal_e; }
    }
}
