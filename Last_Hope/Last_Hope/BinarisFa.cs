using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last_Hope
{
    public enum BejarasTipus { preorder, inorder, postorder }
    internal class BinarisFa<T>
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

        public BinarisFa() { this.gyoker = null; } // ures fa

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
}
