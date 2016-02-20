using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;

namespace Calculator.Expressions
{
    public class UnaryExpression : IExpression
    {
        private readonly IExpression _expression;
        private readonly IUnaryOperation _operation;

        public UnaryExpression(IUnaryOperation operation, IExpression expression)
        {
            if (operation == null)
                throw new ArgumentNullException("operation");

            if (expression == null)
                throw new ArgumentNullException("expression");

            _operation = operation; 
            _expression = expression;
        }

        public decimal Execute()
        {
            return _operation.Eval(_expression);
        }
    }
}
