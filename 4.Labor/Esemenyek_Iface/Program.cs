using System;
using Esemenyek_Iface;

namespace esemenykezeles_iface
{
    class Program
    {
        static void Main(string[] args)
        {
            IUzemanyagHelyzet jelzo = new Jelzo();
            Auto nissangtr = new Auto(80, jelzo);

            // F11-el debuggoljátok végig, és nézzétek meg, hogy mikor nem fog már "kiszólni az esemény".
            nissangtr.Verseny();
            nissangtr.Verseny();
            nissangtr.Verseny();
            nissangtr.Verseny();
            nissangtr.Verseny();

            Console.ReadLine();
        }
    }
}