using System;
using Esemenyek_Event;

namespace esemenykezeles_dgate
{
    class Program
    {

        static void Main(string[] args)
        {
            Szerviz szerviz = new Szerviz(); // publisher

            Auto bmw = new Auto { Rendszam = "ASD-123" };

            MailService ms = new MailService(); // subscriber
            FacebookService fs = new FacebookService(); // subscriber

            // feliratkozás a szervíz-re:
            szerviz.Javitva += ms.OnJavitva;
            szerviz.Javitva += fs.OnJavitva;


            szerviz.Javitas(bmw);

            Console.ReadLine();
        }
    }
}