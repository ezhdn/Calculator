using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;

namespace Calculator.Expressions
{
    public class NumericExpression : IExpression
    {
        private readonly decimal _value;

        public NumericExpression (Decimal num)
        {
            _value = num;
        }

        public decimal Execute()
        {
            return _value;
        }
    }
}
