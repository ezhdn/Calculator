using System;
using Calculator.Interfaces;

namespace Calculator.Operations
{
    public class Div : IOperation
    {
        decimal IOperation.Eval(IExpression first, IExpression second)
        {
            return first.Execute() / second.Execute();
        }

        public int Precedence
        {
            get { return 4; }
        }
    }
}
