using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    internal class Program
    {

        static void Main(string[] args)
        {
            TermekTarolo<Termek> t = new TermekTarolo<Termek>();

            Termek t1 = new Termek() { Ar = 200 };
            Termek t2 = new Termek() { Ar = 5 };
            Termek t3 = new Termek() { Ar = 20 };
            Termek t4 = new Termek() { Ar = 10 };

            t.TermekFelvetele(t1);
            t.TermekFelvetele(t2);
            t.TermekFelvetele(t3);
            t.TermekFelvetele(t4);

            t.Bejaras();

            Console.WriteLine(new string('-',10));

            try
            {
                t.Szures(100);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadLine();

            
        }
    }
}
