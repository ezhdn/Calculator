using System;
using Calculator.Interfaces;

namespace Calculator.Operations
{
    /// <summary>
    /// Операция вычитания
    /// </summary>
    public class Sub : IOperation, IUnaryOperation
    {
        decimal IOperation.Eval(IExpression first, IExpression second)
        {
            return first.Execute() - second.Execute();
        }

        decimal IUnaryOperation.Eval(IExpression expression)
        {
            return - expression.Execute();
        }
    }
}
