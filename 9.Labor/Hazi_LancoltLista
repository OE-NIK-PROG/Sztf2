using Hazi.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazi.classes
{
    public delegate void BejarasDelegate();
    public class LancoltLista<K, T>: IComparable where T : class
    {
        // -------------------------
        // NESTED CLASS
        private ListaElem fej;

        class ListaElem
        {
            public T tartalom;
            public K kulcs;
            public ListaElem kovetkezo;

            public override string ToString()
            {
                return string.Format("{0} ", tartalom);
            }
        }
        // -------------------------

        public void Beszuras(K kulcs, T tartalom)
        {
            Beszuras(ref this.fej, kulcs, tartalom);
        }
        private void Beszuras(ref ListaElem fej, K kulcs,T tartalom)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = tartalom;
            uj.kulcs = kulcs;

            // Ures a lista
            if (fej == null)
            {
                uj.kovetkezo = null;
                fej = uj;
            }
            else
            {
                if (Convert.ToInt32(fej.kulcs) > Convert.ToInt32(kulcs))
                {
                    uj.kovetkezo = fej;
                    fej = uj;
                }
                else
                {
                    ListaElem p = fej;
                    ListaElem e = null;

                    while (p != null && Convert.ToInt32(p.kulcs) < Convert.ToInt32(kulcs))
                    {
                        e = p;
                        p = p.kovetkezo;
                    }

                    if (p != null)
                    {
                        uj.kovetkezo = null;
                        e.kovetkezo = uj;
                    }
                    else
                    {
                        uj.kovetkezo = p;
                        e.kovetkezo = uj;
                    }
                }
            }
            
        }
        public bool Kereses(K kulcs)
        {
            return Kereses(fej, kulcs);
        }
        // nev
        private bool Kereses(ListaElem fej, K kulcs)
        {
            ListaElem p = fej;

            while (p != null && Convert.ToInt32(p.kulcs) < Convert.ToInt32(kulcs))
                p = p.kovetkezo;

            if (p != null && p.kulcs.Equals(kulcs))
            {
                return true;
            }
            else
            {
                throw new Exception("[WARNING] - Nincs ilyen elem a listaban");
            }
            
        }

        // objektum alapjan torol
        public void Torles(T elem)
        {

        }

        // nev alapjan torli az objektumot
        public void Torles(string nev)
        {
            
        }

        public void Szures(T elem) { }
        public void Szures(string nev) { }
        public void Szures(Oldal oldal) { }

        public void Bejaras() { }

        public int CompareTo(object obj)
        {
            if (String.Compare((this as Szuperhos).Név, (obj as Szuperhos).Név) == 0)
            {

            }
            
        }
    }
}
