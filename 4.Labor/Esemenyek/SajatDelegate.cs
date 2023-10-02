using System;
namespace Esemenyek
{
    // - delegáltat osztályszinten kell kezelni,
    //      tehát azzal megegyező "mélységben" hozzuk létre!

    public delegate void SajatMetodusok(string x);

	public delegate int SajatKalkulator(int a, int b);

	public delegate string SajatSzovegFormazo(string szoveg);

	public delegate bool SajatLogika(bool a);

    public delegate void HelyzetJelentesEventHandler(int uzemanyagSzint, int kerekAllapot);

    // Másik osztály létrehozása a delegata-kel egy szinten
    // public class MasikOsztaly { }
}

