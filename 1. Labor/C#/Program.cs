using System;
using System.IO;

namespace Ismetlo_ora
{
    class Program
    {
        static void Main(string[] args)
        {
            int navyDB = 0;

            #region 1. Megoldas
            // Itt azert peldanyositok, hogy megtudjam hivni a beolvas fuggvenyt
            // amit osztalyon belul hoztam letre. Megjegyz.: Mashogyan/Mashova is
            // letre lehet ezt hozni (beolvas fuggvenyt), de a kesobbi progokban
            // majd megertitek, hogy ilyeneket miert nem ide irunk.
            // ZH-n illetve beadandoban ezert NEM veszitetek pontokat.
            Clone clone = new Clone();

            // A fo adatszerkezetem ami a beolvasott elemeket tartalmazza, igy
            // a kesobbi feladatokat mar megtudjatok oldani.
            Clone[] clones = clone.ReadFile("database.csv");// -> ez miatt peldanyositottam a fajl elejen. A beolvas fv.-t megtudtam hivni.

            // MINDIG ellenorizzuk, hogy normalisan megkaptuk-e az adatokat.
            for (int i = 0; i < clones.Length - 1; i++)
            {
                //Console.WriteLine(clones[i].Number);
                if (clones[i].UnitType == "navy")
                    navyDB++;

            }
            #endregion

            #region 1. Feladat
            /*
             * A klónokat tárolja el egy tömbben. (a klón rangját ne számként, hanem a számhoz tartozó besorolást tartalmazza, 
             * a küldetések tömbben pedig a számok külön külön szerepeljenek
             * 
             * [pl.: fájlban így szerepel -> 1-2-3-4-5 => az objektumban viszont így szerepeljen -> [1,2,3,4,5]]
            */

            // EZT A FELADATOT A BEOLVASASNAL MEGCSINALTUK!!! A Mission nevu tulajdonsagban van tarolva!

            #endregion

            #region 2. Feladat
            Console.WriteLine(new string('=',20));
            /*
             * Keresse meg azt a klónt aki a legkevesebb bevetések számával rendelkezik.
             * 
             * Megj.: ez egy minimum kivalsztas tetele lenne.
             */
            
            int minIdx = 0;

            for (int i = 0; i < clones.Length-1; i++)
            {
                if (clones[minIdx].Missions.Length > clones[i].Missions.Length)
                    minIdx = i;
            }

            Console.WriteLine($"Legkevesebb bevetesen reszt vevo katona: {clones[minIdx].Number} >> bevetesek: {clones[minIdx].Missions.Length}\n");

            #endregion

            #region 3. Feladat
            /*
             * Gyüjtse ki külön tömbbe azokat a klónokat, akik köztársasági cirkálóra lettek kiképezve. (navy)
             */

            Clone[] navy = new Clone[navyDB];   // plusz feladat lenne, hogy megszamoljuk, hany darab navy-s katonank van, de az egyszeruseg kedveert
                                                // ezt fentebb csinaltuk mar meg mikor ellenoriztuk, hogy jol megkaptuk e az adatokat.

            int idx = 0;

            for (int i = 0; i < clones.Length-1; i++)
            {
                if (clones[i].UnitType == "navy")
                    navy[idx++] = clones[i];
            }

            for (int i = 0; i < navy.Length-1; i++)
            {
                Console.WriteLine($"Klon: {navy[i].Number}");
            }

            Console.WriteLine();

            #endregion

            #region 4. Feladat
            /*
             * Számolja meg, hogy hány katona harcol DC-15x Sniper Rifle-vel.
             */

            int db = 0;

            for (int i = 0; i < clones.Length-1; i++)
            {
                if (clones[i].Weapon == "DC-15x Sniper Rifle")
                    db++;
            }

            Console.WriteLine($"DC-15x Sniper Rifle-el {db} harcoltak.\n");


            #endregion

            #region 5. Feladat
            /*
             * Írassa ki a képernyőre azokat a katonákat akik egy csoportba se lettek besorolva (jelölése: -)
             */

            for (int i = 0; i < clones.Length - 1; i++)
            {
                if (clones[i].Group == "-")
                    Console.WriteLine($" {clones[i].Number} - {clones[i].Group}");
            }

            Console.WriteLine();
            #endregion

            #region 6. Feladat
            /*
             * Kimeneti fájlba írassa ki csoportosítva az egységeket csapatnevek alapján, 
             * úgy h a hajókon szolgáló (navy) katonák ne legyenek benne.
             */
            #endregion

            StreamWriter sw = new StreamWriter("final_databas.txt");

            for (int i = 0; i < clones.Length-1; i++)
            {
                sw.WriteLine($"{clones[i].Number} =\t{clones[i].Legion}\n{clones[i].Rank}\n");
                sw.WriteLine(new string('+',20));
            }

            sw.Close();

            Console.WriteLine("Sikeresen mentettuk a formazott adatot...");

            Console.ReadKey();
        }
    }
}
