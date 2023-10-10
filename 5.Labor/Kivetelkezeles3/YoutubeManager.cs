using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelkezeles3
{
    internal class YoutubeManager
    {
        public void AddVideoToUser(YoutubeUser user, Video video)
        {
            if (video.Title.Length > 5)
            {
                throw new TooLongVideoTitleException("Tul hosszu a cim...", video);
            }
            else
            {
                // ha minden oke, akkor feltoltjuk a videot.
            }
        }
    }
}
