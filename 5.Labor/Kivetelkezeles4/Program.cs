using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tombkezelo tk = new Tombkezelo(2);
            Random r = new Random();

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    tk.AddTombElem(r.Next(10));
                    Console.WriteLine($" >> [{i}]. elem: {tk.GetTombElem(i)}");
                }
                catch (KiindexelesKivetel ki)
                {
                    Console.WriteLine($"{ki.Uzenet} - {ki.KiindexelesHelye}");
                }
                catch (TeleTombKivetel tele)
                {
                    Console.WriteLine($"{tele.Uzenet} - {tele.MelyikTombrolVanSzo}");
                }
                catch (SajatKivetel ex)
                {
                    Console.WriteLine(ex.Uzenet);
                }
            }

            Console.ReadLine();
        }
    }
}
