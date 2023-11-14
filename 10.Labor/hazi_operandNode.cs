using Hazi.enums;
using System;

namespace Hazi.classes
{
    internal class OperandNode : Node
    {
        public Operator Operator { get; private set; }
        public OperandNode(char data, Node left, Node right) : base(data, left, right) 
        { 
            switch (data) 
            {
                case '+': this.Operator = Operator.ADD;
                    break;
                case '-': this.Operator = Operator.SUB;
                    break;
                case '*': this.Operator = Operator.MUL;
                    break;
                case '/': this.Operator = Operator.DIV;
                    break;
                case '^': this.Operator = Operator.POW;
                    break;
            }
        }
        public OperandNode(char data) : base(data) { }
    }
}
