using System;
using System.Collections;
using System.Collections.Generic;

namespace zh_gyak
{
    public class TermekTarolo<T> where T: Termek
    {
        private ListaElem fej;

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

        public TermekTarolo() { }

        public void TermekFelvetele(T elem)
        {
            //elem.ArValtozes += TermekValtozas;
            TermekFelvetele(ref fej, (elem as Termek).Ar, elem);
        }

        private void TermekFelvetele(ref ListaElem fej, int kulcs, T elem)
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

            elem.ArValtozes += elem.Felvetel;
            elem. ArValtozasFigyelo();
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

        private TermekTarolo<T> ListabanKereses(TermekTarolo<T> lista,  int maximumAr)
        {
            TermekTarolo<T> szurtLista = new TermekTarolo<T>();
            
            ListaElem p = lista.fej;

            while (p != null)
            {
                if (p.kulcs <= maximumAr)
                {
                    T szurtElem = p.tartalom;
                    szurtLista.TermekFelvetele(szurtElem);
                }
                p = p.kovetkezo;
                
            }
            if (szurtLista.fej != null)
            {
                
                return szurtLista;
            }
            else
            {
                throw new Exception("Nincs ilyen termek");
            }
        }

        private void Feldolgoz(ListaElem p)
        {
            Console.WriteLine("Termek" + p);
        }
    }
}
