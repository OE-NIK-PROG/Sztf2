using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            YoutubeManager manager = new YoutubeManager();
            YoutubeUser user = new YoutubeUser();

            try
            {
                manager.AddVideoToUser(user, new Video() { Title = "aaaaaaa" });
            }
            catch (TooLongVideoTitleException e)
            {
                Console.WriteLine("ERROR - " + e.Message);
            }

            Console.ReadLine();
        }
    }
}
