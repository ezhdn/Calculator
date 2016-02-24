using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Microsoft.Practices.Unity.Utility;

namespace Calculator.Expressions
{
    /// <summary>
    /// Бинарное выражение
    /// </summary>
    public class BinaryExpression : IExpression
    {
        private readonly IExpression _first;
        private readonly IExpression _second;
        private readonly IOperation _operation;

        public BinaryExpression(IExpression first, IExpression second, IOperation operation)
        {
            Guard.ArgumentNotNull(operation, "operation");
            Guard.ArgumentNotNull(first, "expression");
            Guard.ArgumentNotNull(second, "second");

            _first = first;
            _second = second;
            _operation = operation;
        }

        public decimal Execute()
        {
            return _operation.Eval(_first, _second);
        }
    }
}
