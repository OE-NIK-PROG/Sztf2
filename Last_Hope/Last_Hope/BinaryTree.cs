using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Last_Hope
{
    public enum BinaryTreeEnterType { preorder, inorder, postorder }
    internal class BinaryTree<T> where T : IProfile
    {
        // --------------------------
        // Nested class
        private class TreeNode
        {
            public T element;
            public int key;
            public TreeNode LeftChild;
            public TreeNode RightChild;

            public TreeNode(int key, T element)
            {
                this.key = key;
                this.element = element;
            }

            public override string ToString()
            {
                return $"[PROFILE] >> {element.Name}";
            }
        }
        // --------------------------
        private TreeNode root;

        public BinaryTree()
        {
            
        }

        public void Insert(int key, T element)
        {
            this.Insert(ref root, key, element);
            element.RegistryChanged += Log;
            element.Shot();
        }

        private void Insert(ref TreeNode root, int key, T element)
        {
            // if ( key < 10 )
            if (root is null)
            {
                root = new TreeNode(key, element);
            }
            else if (root.key < key)
            {
                Insert(ref root.RightChild, key, element);
            }
            else if (root.key > key)
            {
                Insert(ref root.LeftChild, key, element);
            }
            else
            {
                throw new Exception("This item is exist!...");
            }
        }

        public void Enter(BinaryTreeEnterType type)
        {
            if (type == BinaryTreeEnterType.inorder)
                Inorder(root);
        }

        private void Inorder(TreeNode root)
        {
            
            if (root != null)
            {
                // if (root.key < 10)
                Inorder(root.LeftChild);
                Console.WriteLine(root);
                Inorder(root.RightChild);
            }
        }

        private void Log()
        {
            Console.WriteLine($"User registry success...");
        }
    }
}
