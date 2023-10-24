using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Labor
{

    public class OsztalyTerem
    {
        public int Osztalyletszam { get; set; }
        public string OsztalyNev { get; set; }

        public override string ToString()
        {
            return OsztalyNev;
        }
    }
    public class GenVerem<T_tipus> // T K X
    {
        T_tipus[] elemek;

        int db;

        public GenVerem(int meret)
        {
            elemek = new T_tipus[meret];
            db = 0;
        }

        public void Push(T_tipus elem)
        {
            elemek[db++] = elem;
        }

        public T_tipus Pop()
        {
            T_tipus vissza = elemek[--db];
            return vissza;
        }

        public T_tipus Top { get { return elemek[db - 1]; } }
    }

    public class IntVerem
    {
        int[] elemek;

        int db;

        public IntVerem(int meret)
        {
            elemek = new int[meret];
            db = 0;
        }

        public void Push(int elem)
        {
            elemek[db++] = elem;
        }

        public int Pop()
        {
            int vissza = elemek[--db];
            return vissza;
        }

        public int Top { get { return elemek[db - 1]; } }
    }

    public interface IWarrior { }
    public interface IMage { }
    public class XP
    {
        public int Mana { get; set; }
        public int HP { get; set; }
    }
    public class Cast<T, K, X> where X: class/*, IWarrior, IMage*/
    {
        public T CharacterName { get; set; }
        public K Damage { get; set; }
        public X XP { get; set; }
    }

    public class WÖRLDOFFFWARKRAFT<T>
    {
        //T[] players;
        List<T> playersList;
        int db;

        public WÖRLDOFFFWARKRAFT(int players_number)
        {
            //players = new T[players_number];
            playersList = new List<T>();
            db = 0;
        }

        public void AddCharacter(T character)
        {
            //players[db++] = character; --> Tömbnél
            playersList.Add(character);
        }

        public void RemoveCharacter(T character)
        {
            playersList.Remove(character);
        }

        public T GiveBackStrength(T character)
        {
            return character;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region GEN_1
            //IntVerem inverem = new IntVerem(3);
            //inverem.Push(1);
            //inverem.Push(2);
            //inverem.Push(3);

            //try
            //{
            //    inverem.Push(10);
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("HIBA Törtent!");
            //}

            //Console.WriteLine("Legfelso elem:" + inverem.Top);

            //Console.WriteLine("Kivett elem: " + inverem.Pop());

            //// #################################
            ////            GENERIKUSAN
            //// #################################

            //GenVerem<int> gverem1 = new GenVerem<int>(3);
            //GenVerem<string> gverem2 = new GenVerem<string>(3);
            //GenVerem<OsztalyTerem> gverem3 = new GenVerem<OsztalyTerem>(3);

            //gverem3.Push(new OsztalyTerem() { Osztalyletszam = 3, OsztalyNev = "1.c" });

            //#endregion

            #region Lista
            List<int> lista = new List<int>();

            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            lista.Add(4);

            Console.WriteLine("Tartalmazza e a 2-es szamot? >> " + lista.Contains(2));
            Console.WriteLine("Lista db szama >> " + lista.Count);
            Console.WriteLine("Lista elso eleme = " + lista[0]);

            lista.Remove(2);
            ;
            #endregion
            #region OWN_GEN


            WÖRLDOFFFWARKRAFT<Cast<string, int, XP>> gameboard =
                new WÖRLDOFFFWARKRAFT<Cast<string, int, XP>>(1);

            gameboard.AddCharacter(new Cast<string, int, XP>() 
            { CharacterName = "Öldöklö43",Damage = 1, XP = new XP() { HP = 20, Mana = 10} });

            try
            {
                gameboard.AddCharacter(new Cast<string, int, XP>()
                { CharacterName = "PisziPusziCsa", Damage = 100, XP = new XP() { HP = 500, Mana = 50 } });

                gameboard.AddCharacter(new Cast<string, int, XP>()
                { CharacterName = "XXXX", Damage = 100, XP = new XP() { HP = 500, Mana = 50 } });
            }
            catch (Exception e)
            {
                Console.WriteLine("HIBA - SERVER ERROR >>" + e.Message);
            }

            //WÖRLDOFFFWARKRAFT<Cast<string, string, string>> gameboard2 =
            //    new WÖRLDOFFFWARKRAFT<Cast<string, string, string>>(3);


            
            #endregion

            Console.ReadLine();
        }
    }
}
