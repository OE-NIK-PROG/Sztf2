using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Hope
{
    public delegate void Registry();
    public interface IProfile
    {
        string Name { get; set; }
        int Level { get; set; }
        IStatistic Statistics {get; set;}

        event Registry RegistryChanged;

        void Shot();

    }
}
