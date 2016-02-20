using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;

namespace Calculator.Expressions
{
    public class BinaryExpression : IExpression
    {
        private readonly IExpression _first;
        private readonly IExpression _second;
        private readonly IOperation _operation;

        public BinaryExpression(IExpression first, IExpression second, IOperation operation)
        {
            if (first == null)
                throw new ArgumentNullException("first");
            if (second == null)
                throw new ArgumentNullException("second");
            if (operation == null)
                throw new ArgumentNullException("operation");

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
