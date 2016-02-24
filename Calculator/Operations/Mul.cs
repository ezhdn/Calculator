using System;
using Calculator.Expressions;
using Calculator.Interfaces;

namespace Calculator.Operations
{
    /// <summary>
    /// Операция умножения
    /// </summary>
    public class Mul : IOperation
    {
        decimal IOperation.Eval(IExpression first, IExpression second)
        {
            return first.Execute() * second.Execute();
        }
    }
}
