using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles
{
    internal class Program
    {
        static int Osztas(int osztando, int oszto)
        {
            return osztando / oszto;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Osztas(10, 0));
            }
            catch (Exception)
            {
                Console.WriteLine("Ne legyel hülye....");
            }
           
            Console.ReadLine();
        }
    }
}
