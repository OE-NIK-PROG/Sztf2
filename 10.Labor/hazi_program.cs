using Hazi.classes;
using System;

namespace Hazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryExpressionTree binfa =
                new BinaryExpressionTree(new OperandNode('+',
                    new OperandNode('1'),
                    new OperandNode('-', 
                        new OperandNode('1'), 
                        new OperandNode('2'))));




            Console.ReadLine();

        }
    }
}
