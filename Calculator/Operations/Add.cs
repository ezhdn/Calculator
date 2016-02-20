using System;
using Calculator.Interfaces;

namespace Calculator.Operations
{
    public class Add : IOperation, IUnaryOperation
    {
        Decimal IOperation.Eval(IExpression first, IExpression second)
        {
            return first.Execute() + second.Execute();
        }

        decimal IUnaryOperation.Eval(IExpression expression)
        {
            return expression.Execute();
        }

        public int Precedence
        {
            get { return 2; }
        }
    }
}
