using System;
namespace Esemenyek_Event
{
	public class FacebookService
	{
        public void OnJavitva(object source, EventArgs e)
        {
            Console.WriteLine("[FB] - Az autó javítása kész, lehet érte jönni...");
        }
    }
}

