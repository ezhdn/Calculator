using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Expressions;
using Calculator.Interfaces;

namespace Calculator.Parser.Rules
{
    public class NumericRule : RuleBase
    {
        public override bool Accept(IEnumerator<string> expTokens, IExpression inExpression, out IExpression outExpression)
        {
            string stringNumber = expTokens.Current;

            decimal number;

            if (!Decimal.TryParse(stringNumber, out number))
                throw new Exception("Ожидался цифровой литерал");

            outExpression = new NumericExpression(number);

            MoveNext(expTokens, false);

            return true;
        }
    }
}
