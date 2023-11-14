using System;

namespace Hazi.classes
{
    public abstract class Node
    {
        public char Data { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }
        public Node(char data, Node left, Node right)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }

        public Node(char data) :this(data, null, null) { }
    }
}
