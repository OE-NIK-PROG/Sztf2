using System;
namespace Esemenyek_SajatEventArgs
{
	public class FacebookService
	{
        public void OnJavitva(object source, AutoEventArgs e)
        {
            Console.WriteLine("[MAIL] - A {0} frsz. autó javítása kész, lehet érte jönni!", e.Auto.Rendszam);
        }
    }
}

