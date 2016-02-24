using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Calculator.Parser;

namespace Calculator
{
    public class Calc
    {
        private INotation expressionNotation;

        public Calc()
        {
            IOperationSelector operationSelector = new OperationsConfiguration();

            INotation expression = new Notation(operationSelector, false);
            INotation factor = new Notation(operationSelector, true).AddNumeric().AddBracketRule(expression);
            INotation term = new Notation(operationSelector, false).Add(factor).AddOperation(new[] { "*", "/" }, factor, ExpressionRepeatType.NoneOrMore);
            expression.Add(term).AddOperation(new[] { "+", "-" }, term, ExpressionRepeatType.NoneOrMore);

            expressionNotation = expression;
        }

        public List<String> TokenizeExpression(string expression)
        {
            string parseExpression = expression.Replace(" ", "");

            var reg = new Regex(@"[\+\-/\*]|[\d]+(\.[\d]+)?|[()]");

            return reg.Matches(parseExpression).Cast<Match>().Select(x => x.Value).ToList();
        }

        public Decimal Eval(String expressionString)
        {
            IEnumerator<String> tokens = TokenizeExpression(expressionString).GetEnumerator();
            tokens.MoveNext();

            return expressionNotation.Parse(tokens).Execute();
        }
    }
}
