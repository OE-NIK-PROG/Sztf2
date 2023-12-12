using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Hope
{
    internal class LancoltLista<T>
    {
        private ListaElem fej;

        class ListaElem
        {
            public T tartalom;
            public int kulcs;

            public ListaElem kovetkezo;

            public override string ToString()
            {
                return string.Format("{0}", tartalom);
            }
        }

        public void ElejereBeszur(T elem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kovetkezo = fej;
            fej = uj;
        }

        public void VegereBeszuras(T elem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kovetkezo = null;

            if (fej == null)
                fej = uj;
            else
            {
                ListaElem p = fej;
                while (p.kovetkezo != null)
                {
                    p = p.kovetkezo;
                }

                p.kovetkezo = uj;
            }
        }

        public void TermekFelvetele(T elem)
        {
            // Itt azert van hiba, mert hianyzik az osztaly tetejen a megszoritas: where T : {sajat class amit a feladat ker, hogy helyezd el az adatszerkezetben}
            TermekFelvetele(ref fej, elem.kulcs, elem);
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
                if (fej.kulcs > kulcs)
                {
                    uj.kovetkezo = fej;
                    fej = uj;
                }
                else
                {
                    ListaElem p = fej;
                    ListaElem e = null;
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

        private void Feldolgoz(ListaElem elem)
        {
            Console.WriteLine(">> " + elem);
        }
    }
}
