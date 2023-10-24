using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancoltLista
{
    class LancoltLista<T>
    {
        private ListaElem fej;

        class ListaElem
        {
            public T tartalom;

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
    internal class Program
    {
        static void Main(string[] args)
        {
            LancoltLista<string> lista = new LancoltLista<string>();

            lista.ElejereBeszur("alma");
            lista.ElejereBeszur("birsalma");
            lista.VegereBeszuras("korte");
            lista.VegereBeszuras("szamoca");
            lista.ElejereBeszur("tok");

            lista.Bejaras();

            Console.ReadLine();
        }
    }
}
