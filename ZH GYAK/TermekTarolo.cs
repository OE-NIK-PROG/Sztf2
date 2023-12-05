using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minta_zh
{
    internal class TermekTarolo<T>  where T : Termek /*where K : class, IComparable<K>*/
    {

        private ListaElem fej;
        public event ArValtozasDelegate ArValtozas;

        // ------------------------------------
        // NESTED CLASS
        private class ListaElem
        {
            public T tartalom;
            //public K kulcs;
            public int kulcs;
            public ListaElem kovetkezo;

            public override string ToString()
            {
                return string.Format("{0} ", tartalom);
            }
        }
        // ------------------------------------

        public TermekTarolo() { ArValtozas += Felvetel; }

        public void TermekFelvetele(T elem)
        {
            elem.ArValtozes += TermekValtozas;
            TermekFelvetele(ref fej, (elem as Termek).Ar, elem);
        }

        private void TermekFelvetele(ref ListaElem fej, int kulcs ,T elem)
        {
            // Elem beszurasa rendezett listaba
            // https://users.nik.uni-obuda.hu/sztf2/LancoltListak.pdf  -> 21. oldal


            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kulcs = kulcs;

            if (fej == null)
            {
                uj.kovetkezo = null;
                fej = uj;
            }
            else
            {
                //if (CompareTo(kulcs) > 0)  >> with K generic type
                if (fej.kulcs > kulcs)
                {
                    uj.kovetkezo = fej;
                    fej = uj;
                }
                else
                {
                    ListaElem p = fej;
                    ListaElem e = null;

                    //while (p != null && CompareTo(kulcs) < 0) >> with K generic type
                    while (p != null && p.kulcs < kulcs)
                    {
                        e = p;
                        p = p.kovetkezo;
                    }
                    if (p == null)
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

            TermekValtozas();
        }

        private void TermekValtozas()
        {
            ArValtozas?.Invoke();
        }

        public void Bejaras()
        {
            ListaElem p = fej;

            while (p != null)
            {
                Feldolgoz(p);
                p = p.kovetkezo;
            }
        }

        public TermekTarolo<T> Szures(int maximumAr)
        {
            return ListabanKereses(this, maximumAr);
        }

        private TermekTarolo<T> ListabanKereses(TermekTarolo<T> szurtLista,  int maximumAr)
        {
            ListaElem p = szurtLista.fej;

            while (p != null && p.kulcs <= maximumAr)
            {
                szurtLista.TermekFelvetele(p as T);
                p = p.kovetkezo;
                
            }
            if (p == null)
            {
                throw new Exception("Nincs ilyen termek");
            }

            return szurtLista;
        }

        private void Feldolgoz(ListaElem p)
        {
            Console.WriteLine(">> " + p);
        }

        private void Felvetel()
        {
            Console.WriteLine("Termeket felvetelre kerult!");
        }


        #region with K generic type
        //public int CompareTo(K obj1)
        //{
        //    if (this.fej.kulcs.CompareTo(obj1) > 0)
        //    {
        //        return 1;
        //    }
        //    else if (this.fej.kulcs.CompareTo(obj1) < 0)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        #endregion
    }
}
