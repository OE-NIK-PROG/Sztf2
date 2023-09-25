using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clone clone = new Clone();

            Clone[] clones = clone.ReadFile();

            for (int i = 0; i < clones.Length - 1; i++)
            {
                Console.WriteLine(clones[i].ToString());
            }

            Console.ReadKey();
        }
    }
}
