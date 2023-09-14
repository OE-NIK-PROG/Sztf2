using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Ismetlo_ora
{
	public class Clone
	{
        private string rank = "";

        /// PROPERTIES
        public string   Legion      { get; set; }
        public string   Number      { get; set; }
        public string   UnitType    { get; set; }
        public string   Weapon      { get; set; }
        public string   Squad       { get; set; }
        public string   Group       { get; set; }
        public string   Class       { get; set; }
        public string   Rank        { get { return this.rank; } set { this.rank = ReadRankFiles("ranks.csv", value); } }
        public string[] Missions    { get; set; }


        /// CONSTRUCTOR
        public Clone() { }

        // ------------------------
        /// METHODS
         
        /// <summary>
        /// Megszamolom, hogy hany db sort tartalmaz a fajlom
        /// </summary>
        /// <param name="filename">Az adatokat tartalmazo fajl neve</param>
        /// <returns>Egy db szammal, amit kesobb atadok a tombnek, mint hossz.</returns>
        private int LinesDB(string filename)
        {
            // Megszamolas tetele
            int db = 0;
            StreamReader f = new StreamReader(filename);

            while (!f.EndOfStream)
            {
                string lines = f.ReadLine();
                db++;
            }

            f.Close();

            return db;
        }

        /// <summary>
        /// Beolvasom a Rank nevu fajl tartalmat.
        /// </summary>
        /// <param name="fileName">Beolvasando fajl neve</param>
        /// <param name="rankNumber">Az aktualis objektum ranghoz tartozo szama</param>
        /// <returns>Ha megeggyezik a rankNumber erteke a fajl valamelyik soraban levo ertekkel,
        ///             akkor a hozza tartozo rang nevet adja vissza.
        ///             pl.: rankNumber: 1  -> fajlban: {rankNum: 1, rankName: General} ->
        ///             visszateresi ertek igy a General lesz.</returns>
        private string ReadRankFiles(string fileName, string rankNumber)
        {
            bool equal = false;
            string equalRank = "";

            StreamReader sr = new StreamReader(fileName);

            while (!sr.EndOfStream && !equal)
            {
                Rank tempRank = new Rank();

                string[] tempArray = sr.ReadLine().Split(';');

                /*
                 * 71. sor-t igy is fel lehetne irni, ahelyett h 1 sorba tomoritenek mindent.
                 * string line = sr.ReadLine();
                 * string[] tempArray = line.Split(';');
                */

                tempRank.Rank_Number = int.Parse(tempArray[0]);
                tempRank.Rank_Name = tempArray[1];

                if (rankNumber == tempRank.Rank_Number.ToString())
                {
                    equalRank = tempRank.Rank_Name;
                    equal = true;
                }
            }

            sr.Close();
            return equalRank;
        }

        /// <summary>
        /// Fajl adatainak beolvasasa
        /// </summary>
        /// <param name="fileName">Fajlnak a neve</param>
        /// <returns></returns>
        public Clone[] ReadFile(string fileName)
        {
            /*
             * Itt hozom letre a tombot, ami majd a Program.cs-ben fog nekem kelleni
             * A LinesDb(fileName) lenyegeben egy olyan fuggveny, ami megszamolja a 
             * fajl sorainak szamat.
             */
            Clone[] clones = new Clone[LinesDB(fileName)];
            StreamReader f = new StreamReader(fileName);
            int idx = 0;

            while (!f.EndOfStream)
            {
                // Ahhoz h objektumokkal toltsem fel a tombot, ahhoz minden egyes
                // iteracioban letre kell hoznom egy peldanyt. Ebben az esetben
                // ez egy klon objektum, aminek mar korabban elkeszitettuk a
                // tulajdonsagait.
                Clone clone = new Clone(); // Peldanyositas
                string lines = f.ReadLine(); // egy sor kiolvasasa a fajlbol


                // Beolvasott sor feldarabolasa ; menten.
                string[] tempArray = lines.Split(';');

                // Az elobb peldanyositott objektum tulajdonsagainak feltoltese
                clone.Legion = tempArray[0];
                clone.Number = tempArray[1];
                clone.Class = tempArray[2];
                clone.Weapon = tempArray[3];
                clone.UnitType = tempArray[4];
                clone.Squad = tempArray[5];
                clone.Group = tempArray[6];
                clone.Rank = tempArray[7];
                string missionString = tempArray[8];
                clone.Missions = clone.getMissionNumber(missionString);

                clones[idx++] = clone;
            }

            f.Close();

            return clones;
        }


        /// FONTOS !!!
        /* Ha nem void szerepel a lathatosag utan, akkor az az jelenti, hogy vissza kell terni egy ertekkel!
         * Ezt onnan tudjatok a legjobban ellenorizni, hogy ha a fuggveny neve ala van huzva es raviszitek
         * az egereteket, akkor ezt a hibakodot kapjatok: NOT ALL CODE PATHS RETURN A VALUE.
        */ 

        /// <summary>
        /// Az utolso feladathoz szukseges szetvalasztas
        /// </summary>
        /// <param name="value">A string karakterlanc ami tartalmazza az informaciokat (1-2-3-4-5)</param>
        /// <returns></returns>
        public string[] getMissionNumber(string value)
        {

            // ----------------------
            // Ez a resz ahhoz kell h megszamoljam, milyen hosszu tombot hozzak letre a programban
            int db = 0;
            string[] missions;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i].ToString() != "-")
                {
                    db++;
                }
            }
            // ----------------------

            missions = new string[db]; // Letrehozom a tombot az adott hosszusaggal

            db = 0; // azert nullazom ki, mert amikor fel akarom tolteni az elozoleg
                    // letrehozot tombot azokkal az adatokkal amik kellenek, akkor
                    // minden a helyere keruljon. Most a db igazabol nekem egy index
                    // valtozoval er fel, igy felhasznaltam mar egy meglevo valtozot.

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i].ToString() != "-")
                {
                    missions[db++] = value[i].ToString();
                    // Most nem a db szamot novelem, hanem a tomb aktualis helyere
                    // behelyezem az erteket ami kell nekunk.
                }
            }

            return missions;
        }
    }
}
