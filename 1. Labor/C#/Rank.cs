using System;
namespace Ismetlo_ora
{
	public class Rank
	{
        /// PROPERTY

        /*
         * public / private                     -> lathatosag
         * public (+)                           -> nyilvanos
         * private (-)                          -> rejtett
         * 
         * int / string / bool/ double / char   -> tipus
         * 
         * Rank_Number / Rank_Name              -> tulajdonsag (property) neve
         */
        public int Rank_Number { get; set; }
        public string Rank_Name { get; set; }

        /*
            get -> visszaadja az erteket ezert ide egy return kell akkor, ha
                   nem ebben a formaban hasznaljuk mint a 18. sorban.

            set -> beallitok neki egy erteket. A 19. sorban a rovidebb verziot
                   latod, viszont ennek egy hosszabb  verziojat lentebb fejtek
                   ki.
         */

        // ---------------

        /// CONSTRUCTOR
        /* Ures constructor. Ha ezt a sort kihagyom, akkor ures az
         * alapertelmezett.
        */
        public Rank() { } // -> Ha ures, akkor kitorolheto, de jo ha latjuk
                           //    es ott van.



        /// TULAJDONSAG / PROPERTY leirasa mashogyan.

        private int rank_num; // adatelem
        private string rank_nam; // adatelem

        public int Rank_Num { get { return rank_num; } set { rank_num = value; } }
        public string Rank_Nam { get { return rank_nam; } set { rank_nam = value; } }

        /*
         * A get resznel a return visszaadja a rank_num / rank_nam tartalmat. Ennek
         * a beallitasa a set resznel tortenik. Olyan mintha egy sima valtozonak 
         * adnal erteket (pl.: valtozoNev = 2;). Itt a value dinamikus, meghivaskor
         * az ott atadott ertek veszi at. Ebben az esetben:
         *          pl.: Rank r = new Rank();
         *               r.Rank_Nam = "tizedes";
         *   
         *  Megj.: A fenti veriacioban ugyan ez tortenik, csak az egy rovidebb 
         *         verzioja ennek az ertekadasnak, illetve nyelv fuggo.
         */
    }
}

