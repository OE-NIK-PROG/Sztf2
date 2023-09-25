using System;
using KlonDatabase;

namespace ConsoleApp1
{
    public sealed class Clone : BasicInfo, IFileReader
    {

        private int fileLenght = 0;

        public string Filename { get; set; } = "database.csv";

        public Clone() { fileLenght = LinesDB(); }


        public Clone(string filename, string _number, string _legion, string _unittype, string _weapon, string _squad, string _group, string _class, Rank _rank)
            : base(_number, _legion, _unittype, _weapon, _squad, _group, _class, _rank)
        {
            this.Filename = filename;

            fileLenght = LinesDB();
        }

        public int LinesDB()
        {
            // Megszamolas tetele
            int db = 0;
            StreamReader f = new StreamReader(this.Filename);

            while (!f.EndOfStream)
            {
                string lines = f.ReadLine();
                db++;
            }

            f.Close();

            return db;
        }

        public override Rank ReadRankFiles(string rankNumber)
        {
            bool equal = false;

            StreamReader sr = new StreamReader("ranks.csv");

            Rank tempRank = new Rank() { Rank_Number = 99, Rank_Name = "unknown" };

            while (!sr.EndOfStream && !equal)
            {


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
                    equal = true;
                }
            }

            sr.Close();
            return tempRank;
        }

        public Clone[] ReadFile()
        {
            /*
             * Itt hozom letre a tombot, ami majd a Program.cs-ben fog nekem kelleni
             * A LinesDb(fileName) lenyegeben egy olyan fuggveny, ami megszamolja a 
             * fajl sorainak szamat.
             */
            Clone[] clones = new Clone[this.fileLenght];
            StreamReader f = new StreamReader(Filename);
            int idx = 0;

            while (!f.EndOfStream)
            {
                // Ahhoz h objektumokkal toltsem fel a tombot, ahhoz minden egyes
                // iteracioban letre kell hoznom egy peldanyt. Ebben az esetben
                // ez egy klon objektum, aminek mar korabban elkeszitettuk a
                // tulajdonsagait.

                string lines = f.ReadLine(); // egy sor kiolvasasa a fajlbol


                // Beolvasott sor feldarabolasa ; menten.
                string[] tempArray = lines.Split(';');

                Clone clone = new Clone(); // Peldanyositas
                clone._number = tempArray[1];
                clone.Legion = tempArray[0];
                clone.Class = tempArray[2];
                clone.Weapon = tempArray[3];
                clone.UnitType = tempArray[4];
                clone.Squad = tempArray[5];
                clone.Group = tempArray[6];
                clone.Rank = ReadRankFiles(tempArray[7]);
                string missionString = tempArray[8];
                clone.missions = clone.getMissionNumber(missionString);

                clones[idx++] = clone;
            }

            f.Close();

            return clones;
        }

        public override string[] getMissionNumber(string value)
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

        private string WriteMission()
        {
            string output = "";
            for (int i = 0; i < this.missions.Length - 1; i++)
            {
                output += missions[i] + "\n";
            }
            return output;
        }

        public override string ToString()
        {
            return $"Clone number = {this.Number}\t Legion = {this.Legion}\nMission = \n{WriteMission()}";
        }
    }
}
