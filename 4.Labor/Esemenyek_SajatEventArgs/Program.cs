using System;
using System.Threading;
using Esemenyek_SajatEventArgs;

namespace sajat_eventargs
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
        }
    }
}