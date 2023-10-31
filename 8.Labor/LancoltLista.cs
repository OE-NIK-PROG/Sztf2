using System;

namespace BinarisFa
{

    public class LancoltLista<T> : IEnumerator, IEnumerable
    {
        private ListaElem fej;
        private ListaElem bejaroMutato;

        public object Current { get { return bejaroMutato.tartalom; } }

        public LancoltLista()
        {
            fej = null;
            bejaroMutato = fej;
        }

        class ListaElem
        {
            public T tartalom;
            public ListaElem kovetkezo;
            public override string ToString() { return this.tartalom.ToString(); }
        }

        public T this[int i]
        {
            get { return ElemKereses(i); }
            set { ElemModositas(i, value); }
        }

        private T ElemKereses(int index)
        {
            ListaElem p = fej;
            int count = 0;
            while (p != null && count < index)
            {
                p = p.kovetkezo;
                count++;
            }

            if (p != null && count == index)
                return p.tartalom;
            else
                throw new Exception("[ERR] - Nincs ilyen indexű elem.");
        }

        private void ElemModositas(int index, T ujErtek)
        {
            ListaElem p = fej;
            int count = 0;
            while (p != null && count < index)
            {
                p = p.kovetkezo;
                count++;
            }

            if (p != null && count == index)
                p.tartalom = ujErtek;
            else
                throw new Exception("[ERR] - Nincs ilyen indexű elem.");
        }

        public void ElemBeszuras(T elem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kovetkezo = fej;
            fej = uj;
        }

        public void Bejaras()
        {
            ListaElem p = fej;
            while (p != null)
            {
                Console.WriteLine(p);
                p = p.kovetkezo;
            }
        }

        public bool MoveNext()
        {
            if (bejaroMutato == null)
            {
                // első hívás
                bejaroMutato = fej;
                return true;
            }
            else if (bejaroMutato.kovetkezo != null)
            {
                // n. hívás
                bejaroMutato = bejaroMutato.kovetkezo;
                return true;
            }
            else
            {
                // lista vége
                this.Reset();
                return false;
            }
        }

        public void Reset()
        {
            bejaroMutato = null;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }

    public class Ember
    {
        public string Nev { get; set; }
        public override string ToString()
        {
            return this.Nev;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
