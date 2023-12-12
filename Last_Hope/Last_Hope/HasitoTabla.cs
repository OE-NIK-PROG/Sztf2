using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Hope
{
    class HasitoKivetel : Exception { }
    class NincsHelyHasitoKivetel : HasitoKivetel { }
    class NincsIlyenKulcsHasitoKivetel : HasitoKivetel { }

    public abstract class HasitoTablazat<K, T>
    {
        protected int m;

        public HasitoTablazat(int m)
        {
            this.m = m;
        }

        protected virtual int h(K kulcs)
        {
            return Math.Abs(kulcs.GetHashCode() % m);
        }

        abstract public void Beszuras(K kulcs, T ertek);
        abstract public T Kereses(K kulcs);
        abstract public void Torles(K kulcs);
    }

    internal class HasitoTabla<K, T> : HasitoTablazat<K, T>
    {
        class HasitoElem
        {
            public K kulcs;
            public T tart;
            public bool torolt = false;
        }

        HasitoElem[] A;

        public HasitoTabla(int m) : base(m)
        {
            A = new HasitoElem[m];
            for (int i = 0; i < m; i++)
                A[i] = new HasitoElem();
        }

        protected virtual int h(K kulcs, int j)
        {
            return (base.h(kulcs) + j * 31) % m;
        }

        public override void Beszuras(K kulcs, T ertek)
        {
            int j = 0;
            while (j < m && A[h(kulcs, j)].kulcs != null && !A[h(kulcs, j)].torolt) j++;

            if (j < m)
            {
                A[h(kulcs, j)].kulcs = kulcs;
                A[h(kulcs, j)].tart = ertek;
                A[h(kulcs, j)].torolt = false;
            }
            else throw new NincsHelyHasitoKivetel();
        }

        public override T Kereses(K kulcs)
        {
            int j = 0;
            while (j < m && A[h(kulcs, j)].kulcs != null && !(A[h(kulcs, j)].kulcs.Equals(kulcs) && !A[h(kulcs, j)].torolt)) j++;

            if (j < m && A[h(kulcs, j)].kulcs != null)
            {
                return A[h(kulcs, j)].tart;
            }
            else
                throw new NincsIlyenKulcsHasitoKivetel();
        }

        public override void Torles(K kulcs)
        {
            int j = 0;
            while (j < m && A[h(kulcs, j)].kulcs != null && !(A[h(kulcs, j)].kulcs.Equals(kulcs) && !A[h(kulcs, j)].torolt)) j++;

            if (j < m && A[h(kulcs, j)].kulcs != null)
            {
                A[h(kulcs, j)].torolt = true;
            }
            else
                throw new NincsIlyenKulcsHasitoKivetel();
        }
    }
}
