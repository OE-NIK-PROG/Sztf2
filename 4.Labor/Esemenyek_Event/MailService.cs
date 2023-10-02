using System;
namespace Esemenyek_Event
{
	public class MailService
	{
        public void OnJavitva(object source, EventArgs e)
        {
            Console.WriteLine("[MAIL] - Az autó javítása kész, lehet érte jönni...");
        }
    }
}

