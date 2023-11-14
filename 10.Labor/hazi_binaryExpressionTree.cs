using Hazi.enums;
using System;

namespace Hazi.classes
{
    internal class BinaryExpressionTree
    {
        private Node Root { get; set; }
        private BinaryExpressionTree(Node root)
        {
            this.Root = root;
        }
        public static BinaryExpressionTree Build(string expression)
        {
            return Build(expression.ToCharArray());
        }

        static BinaryExpressionTree Build(char[] expression)
        {
            Stack<Node> stack = new Stack<Node>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsNumber(expression[i]))
                {
                    stack.Push(new OperandNode(expression[i]));
                }
                else
                {
                    if(CheckOperand(expression[i]))
                    {
                        Node lefChild = stack.Pop().Left;
                        Node rightChild = stack.Pop().Right;

                        stack.Push(new OperandNode(expression[i], lefChild, rightChild));
                    }
                }
            }

            return null;
        }

        private static bool CheckOperand(char v)
        {
            switch (v)
            {
                case '+': return true;               
                case '-': return true;
                case '*': return true;
                case '/': return true;
                case '^': return true;
                default : return false;
            }
        }
    }
}
