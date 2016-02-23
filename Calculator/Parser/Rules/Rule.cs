using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Microsoft.Practices.Unity.Utility;

namespace Calculator.Parser.Rules
{
    public class Rule : IRule
    {
        private readonly INotation _notation;

        public Rule(INotation notation)
        {
            Guard.ArgumentNotNull(notation, "notation");

            _notation = notation;
        }

        public bool Accept(IEnumerator<string> expTokens, IExpression inExpression, out IExpression outExpression)
        {
            outExpression = _notation.Parse(expTokens);

            return true;
        }
    }
}
