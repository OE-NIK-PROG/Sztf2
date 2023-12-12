using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Hope
{
    public class Profile : IProfile
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public IStatistic Statistics { get; set; }

        public event Registry RegistryChanged;

        public void Shot()
        {
            RegistryChanged?.Invoke();
        }
    }
}
