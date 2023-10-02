using System;

namespace Esemenyek
{
    // - delegáltat osztályszinten kell kezelni,
    //      tehát azzal megegyező "mélységben" hozzuk létre!
    public delegate void Metodusok(string x);

    class Program
    {

        #region SajatMetodusok
        static void MetodusEgy(string a)
        {
            Console.WriteLine(">>" + a);
        }

        static void MetodusKetto(string b)
        {
            Console.WriteLine("Bemenet: " + b);
        }

        static void MetodusHarom(string a)
        {
            Console.WriteLine("::::::" + a);
        }

        static void SokadikMetodus(int szam1, int szam2)
        {
            Console.WriteLine(szam1 + szam2);
        }
        #endregion

        #region SajatKalkulator

        static int Osszeadas(int a, int b)
        {
            Console.WriteLine($"Lefutok Osszeadas >> {a + b}");
            return a + b;
        }

        static int Kivonas(int a, int b)
        {
            Console.WriteLine($"Lefutok Kivonas >> {a - b}");
            return a - b;
        }

        static int Szorzas(int a, int b)
        {
            Console.WriteLine($"Lefutok Szorzas >> {a * b}");
            return a * b;
        }

        #endregion

        #region SajatSzovegFormazo

        static string Szoveg1(string x)
        {
            Console.WriteLine($"Szoveg {x} meghivva");
            return "Hello " + x;
        }

        #endregion

        #region SajatLogika

        static bool Logika(bool a)
        {
            a = !a;
            return a;
        }
        #endregion

        #region Osztalyszinten
        // 1. esethez
        static void HelyzetJelentes(int uzemanyag, int kerekallapot)
        {
            Console.WriteLine("Maradék üzemanyag: " + uzemanyag +
                " Kerek allapot: " + kerekallapot + "\t");
        }
        #endregion

        static void Main(string[] args)
        {
            #region SajatMetodusok
            // - egyszerűen egyesével tudunk metódusokat hívogatni
            MetodusEgy("alma");
            MetodusKetto("körte");

            // - példányt ebből is lehet létrehozni
            // - viszont fontos, hogy alapból egy metódust paraméterként át kell adni neki
            // - figyeljünk, hogy az átadott metódus (és a később feliratkoztatott metódusok)
            //      mind egyforma szignatúrával kell rendelkezzenek!
            SajatMetodusok metodusok = new SajatMetodusok(MetodusEgy);
            metodusok += MetodusKetto; // feliratkoztatás, "gyűjtőbe belerakás"
            metodusok += MetodusHarom;
            metodusok -= MetodusEgy; // leiratkoztatás, "gyűjtőből kivétel"


            // - erre már problémázna, mert a szignatúra nem egyezik meg
            // metodusok += SokadikMetodus;


            metodusok("barack");
            // - lefuttatva látható, hogy tulajdonképpen minden metódust "lefuttathatunk"
            //      amelyet előzetesen a "gyűjtőbe" belerakunk
            #endregion

            #region SajatKalkulator


            SajatKalkulator kalkulatorok = new SajatKalkulator(Osszeadas);

            
            kalkulatorok += Kivonas;
            kalkulatorok += Szorzas;
      

            Console.WriteLine(kalkulatorok(10,10));

            #endregion

            #region SajatSzovegFormazo
            SajatSzovegFormazo szovegek = new SajatSzovegFormazo(Szoveg1);

            szovegek += Szoveg1;
            szovegek += Szoveg1;
            szovegek += Szoveg1;
            szovegek += Szoveg1;

            szovegek("alma");
            szovegek("Korte");
            #endregion

            #region SajatLogika
            SajatLogika logikak = new SajatLogika(Logika);

            Console.WriteLine(logikak(false));
            #endregion

            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Osztalyban hasznalva");
            Console.WriteLine(new string('-',20));

            #region Osztalyszinten

            Auto auto = new Auto(100, 100);

            // FELIRATÁS (1. eset)
            auto.helyzet += HelyzetJelentes;

            auto.helyzet(100, 100);
            // Probléma adódik viszont (1. esetben), ha publikus a delegált, mert ez esetben innen kívülről meghívhatom
            //      tetszőlegesen, ezáltalá fals programot készítve.
            // Ekkor tehát, minden feliratkozott metódus, ahogy néztük is lefut a 100-as paraméterrel.

            // Ezt kiküszöbölve, csinálunk feliratkozás és leiratkozás metódusokat az auto osztályban!

            Console.WriteLine('|');
            Console.WriteLine(" -> Private szintu delegate");

            Ertesito ert = new Ertesito();
            auto.Feliratkozas(ert.HelyzetJelentes);

            int aktKor = 0;

            while (aktKor < 10)
            {
                auto.Verseny();
                if(auto.KerekAllapot < 50)
                {
                    auto.Kerekcsere();
                }

                aktKor++;
            }


            #endregion


            Console.ReadKey();
        }

    }
}
