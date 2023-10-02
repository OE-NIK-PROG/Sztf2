using System;
namespace Esemenyek_Event
{
	public class Szerviz
	{
        // = = = = = = = = = = = = = = = = = = = = = = = = //
        // A 3 LÉPÉS:                                      //
        //      1. delegált definiálása                    //
        //      2. esemény a delegált alapján              //
        //      3. esemény elsütése ahol szükséges         //
        // = = = = = = = = = = = = = = = = = = = = = = = = //

        public delegate void JavitasEventHandler(object source, EventArgs args);

        public event JavitasEventHandler Javitva;

        // - a háttérben az 'event' kiváltja a fel és leiratkozást,
        //      valamint, hogy private-ként vesszük a delegáltat!

        public void Javitas(Auto auto)
        {
            Console.WriteLine("Autó javítás folyamatban...");
            Thread.Sleep(3000); // hogy szimbolizáljuk a javítás idejét...

            OnJavitva(); // esemény elsütése
        }

        protected virtual void OnJavitva()
        {
            if (Javitva != null) // vizsgálat azért kell, hogy ha nincs semmi sem feliratkozva, ne haljon meg
                Javitva(this, EventArgs.Empty);

            // source = a szervíz osztály fogja az eseményt küldeni
            // üres argumentumokkal/paraméterekkel
        }

        // A fenti részt megírtuk 5 éve, vagy megírták nekünk másik dolgozók egy másik cégben.
        // Mi ahhoz nem férünk hozzá, de ettől függetlenül szeretnénk, ha a javítást elvégezve értesítsenek minket több platformon is.
        // Ha a facebook és a sima email mellé később szeretnénk twitter, vagy bármi egyéb új dolgot integrálni, gond nélkül meg tudjuk tenni!
    }
}

