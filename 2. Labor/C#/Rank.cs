using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public sealed class Rank
    {
        public int Rank_Number { get; set; }
        public string Rank_Name { get; set; }

        public Rank() { } // Peldanyositas utan kell megadni az ertekeket.

        public Rank(int rank_number, string rank_name) // Peldanyositasnal is letrehozhato.
        {
            Rank_Number = rank_number;
            Rank_Name = rank_name;
        }
    }
}
