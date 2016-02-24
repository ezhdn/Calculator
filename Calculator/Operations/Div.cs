using System;
using Calculator.Interfaces;

namespace Calculator.Operations
{
    /// <summary>
    /// Операция деления
    /// </summary>
    public class Div : IOperation
    {
        decimal IOperation.Eval(IExpression first, IExpression second)
        {
            return first.Execute() / second.Execute();
        }
    }
}
