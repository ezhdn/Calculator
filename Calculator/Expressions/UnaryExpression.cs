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
    /// Унарное выражение
    /// </summary>
    public class UnaryExpression : IExpression
    {
        private readonly IExpression _expression;
        private readonly IUnaryOperation _operation;

        public UnaryExpression(IUnaryOperation operation, IExpression expression)
        {
            Guard.ArgumentNotNull(operation, "operation");
            Guard.ArgumentNotNull(expression, "expression");

            _operation = operation; 
            _expression = expression;
        }

        public decimal Execute()
        {
            return _operation.Eval(_expression);
        }
    }
}
