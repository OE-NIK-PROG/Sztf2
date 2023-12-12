using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Hope
{
    internal class Graph<T> where T: IProfile
    {
        List<List<T>> neighbours = new List<List<T>> ();
        List<T> elements = new List<T> ();

        public void AddTop(T edge)
        {
            elements.Add (edge);
            neighbours.Add(new List<T>());
        }

        public void AddEdge(T where, T to)
        {
            int indexWhere = elements.IndexOf (where);
            int indexTo = elements.IndexOf (to);

            neighbours[indexWhere].Add(elements[indexTo]);
            neighbours[indexTo].Add(elements[indexWhere]);
        }

        public bool ExistEdge(T a, T b)
        {
            int indexWhere = elements.IndexOf(a);
            int indexTo = elements.IndexOf(b);
            return neighbours[indexWhere].Contains(elements[indexTo]);
        }

        public List<T> CheckNeighbour(T whichEdge)
        {
            int index = elements.IndexOf(whichEdge);
            return neighbours[index];
        }

        public void DeepEnter(T startElement)
        {
            List<T> F = new List<T>();
            DeepEnter(startElement, ref F);
        }

        private void DeepEnter(T k, ref List<T> F)
        {
            F.Add(k);
            Console.WriteLine(k.ToString());

            foreach (T item in CheckNeighbour(k))
            {
                if (!F.Contains(item))
                {
                    DeepEnter(item, ref F);
                }
            }
        }
    }
}
