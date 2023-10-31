using System;

namespace BinarisKeresoFa
{
    public enum BejarasTipus {  preorder, inorder, postorder }

    public class BinarisKeresoFa<T> // GEN TIPUSKENT -> <T, K> -> T - tipus (tartalom) K - kulcs tipusa
    {
        // NESTED CLASS
        class FaElem
        {
            public int kulcs; // GEN TIPUSKENT K a tipusa
            public T tartalom;
            public FaElem bal;
            public FaElem jobb;

            public FaElem(int kulcs, T tartalom)
            {
                this.kulcs = kulcs; 
                this.tartalom = tartalom;
            }

            public override string ToString()
            {
                return "[" + this.kulcs.ToString() + "]" + this.tartalom.ToString();
            }
        }

        FaElem gyoker;

        public BinarisKeresoFa() { this.gyoker = null; } // ures fa

        public void Beszuras(int kulcs, T tartalom)
        {
            this.Beszuras(ref gyoker, kulcs, tartalom);
        }

        private void Beszuras(ref FaElem p, int kulcs, T tartalom)
        {
            if (p == null)
            {
                p = new FaElem(kulcs, tartalom);
            }
            else if (p.kulcs < kulcs)
            {
                Beszuras(ref p.jobb, kulcs, tartalom);
            }
            else if (p.kulcs > kulcs)
            {
                Beszuras(ref p.bal, kulcs, tartalom);
            }
            else
            {
                throw new Exception("Van mar ilyen kulcsu elem!!!");
            }
        }

        public void Bejaras(BejarasTipus tipus)
        {
            if (tipus == BejarasTipus.inorder)
            {
                InOrder(this.gyoker);
            }
            else if (tipus == BejarasTipus.preorder)
            {
                PreOrder(this.gyoker);
            }
            else if (tipus == BejarasTipus.postorder)
            {
                PostOrder(this.gyoker);
            }
        }

        private void PreOrder(FaElem p)
        {
            if (p != null)
            {
                Console.WriteLine(p);
                PreOrder(p.bal);
                PreOrder(p.jobb);
            }
        }

        private void PostOrder(FaElem p)
        {
            if (p != null)
            {
                PreOrder(p.bal);               
                PreOrder(p.jobb);
                Console.WriteLine(p);
            }
        }

        private void InOrder(FaElem p)
        {
            if (p != null)
            { 
                PreOrder(p.bal);
                Console.WriteLine(p);
                PreOrder(p.jobb);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            BinarisKeresoFa<string> bst = new BinarisKeresoFa<string>();

            try
            {
                bst.Beszuras(21, "Tony Stark");
                bst.Beszuras(212, "Thor");
                bst.Beszuras(2, "Hulk");
                bst.Beszuras(5, "Black Widow");
                bst.Beszuras(33, "Micimacko");
                bst.Beszuras(21, "Joker");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("PREORDER\n", new string(' ',10));
            bst.Bejaras(BejarasTipus.preorder);
            Console.WriteLine("POSTORDER\n", new string(' ', 10));
            bst.Bejaras(BejarasTipus.postorder);
            Console.WriteLine("INORDER\n", new string(' ', 10));
            bst.Bejaras(BejarasTipus.inorder);

            Console.ReadLine();

        }
    }
}
