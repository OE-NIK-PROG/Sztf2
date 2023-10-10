using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles4
{
    internal class Tombkezelo
    {
        private int tombIndex;
        private int[] tomb;
        private int tombMeret;

        public int TombMeret { get { return tombMeret; } }

        public Tombkezelo(int meret)
        {
            this.tombMeret = meret;

            tomb = new int[this.tombMeret];
            tombIndex = 0;

        }

        public int GetTombElem(int tombIndex)
        {
            if (tombIndex < 0 || tombIndex > tombMeret)
                throw new KiindexelesKivetel() { Uzenet = "Hiba keletkezett", KiindexelesHelye = tombIndex };
            else
                return tomb[tombIndex];
        }

        public void AddTombElem(int elem)
        {
            if (tombIndex == tomb.Length)
                throw new TeleTombKivetel() { Uzenet = "Hiba keletkezett", MelyikTombrolVanSzo = this.tomb };
            else
                tomb[tombIndex++] = elem;
        }
    }
}
