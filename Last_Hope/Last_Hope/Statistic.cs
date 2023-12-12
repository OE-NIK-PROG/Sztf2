using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Hope
{
    internal class Statistic : IStatistic
    {
        public int Dexterity { get; private set; }

        public int Stamina { get; private set; }

        public int Strength { get; private set; }
        public Statistic(int dex, int stam, int strength)
        {
            this.Dexterity = dex;
            this.Stamina = stam;
            this.Strength = strength;
        }
    }
}
