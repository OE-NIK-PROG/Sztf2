using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zh_gyak
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TermekTarolo<Termek> t = new TermekTarolo<Termek>();

            Termek t1 = new Termek() { Nev = "Kolbasz", Ar = 200 };
            Termek t2 = new Termek() { Nev = "Kenyer", Ar = 5 };
            Termek t3 = new Termek() { Nev = "Uborka", Ar = 20 };
            Termek t4 = new Termek() { Nev = "Hagyma", Ar = 10 };

            t.TermekFelvetele(t1);
            t.TermekFelvetele(t2);
            t.TermekFelvetele(t3);
            t.TermekFelvetele(t4);

            t.Bejaras();

            Console.WriteLine(new string('-',10));

            try
            {
                TermekTarolo<Termek> szurtT = t.Szures(100);
                szurtT.Bejaras();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}
