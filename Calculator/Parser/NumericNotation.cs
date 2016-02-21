using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Expressions;
using Calculator.Interfaces;

namespace Calculator.Parser
{
    public class NumericNotation : Notation
    {
        public override IExpression Parse(IEnumerator<string> expressionTokens)
        {
            string stringNumber = expressionTokens.Current;

            decimal number;

            if(!Decimal.TryParse(stringNumber, out number))
                throw new Exception("Ожидался цифровой литерал");

            return new NumericExpression(number);
        }
    }
}
