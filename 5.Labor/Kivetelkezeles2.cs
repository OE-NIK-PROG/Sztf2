using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles2
{
    internal class Program
    {
        static void Kiiras(string x)
        {
            Console.WriteLine(new string('-', 10));
            Console.WriteLine(" " + x);
            Console.WriteLine(new string('-', 10));
        }

        static void TombKezeles()
        {
            Kiiras("Add meg a tömb meretet: ");
            int[] tomb = new int[int.Parse(Console.ReadLine())];

            for (int i = 0; i < tomb.Length; i++)
            {
                Console.Write("> ertek : ");
                tomb[i] = int.Parse(Console.ReadLine());
            }

            Kiiras("Add meg, hanyadik elem erdekel: ");
            Console.Write(tomb[int.Parse(Console.ReadLine())]);
        }
        static void Main(string[] args)
        {
            try
            {
                TombKezeles();
            }
            catch (FormatException e)
            {
                Console.WriteLine("HIBA ü formai hibát vétettél!");
                Console.WriteLine("\nrészletek: " + e.Message);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("HIBA - Kiindexeltél a tömbböl!");
            }
            catch (Exception e)
            {
                Console.WriteLine("HIBA");
            }
            finally { Console.WriteLine("Ez az ág pedig mindig le fog futni..."); }

            Console.ReadLine();
        }
    }
}
