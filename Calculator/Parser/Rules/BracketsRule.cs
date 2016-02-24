using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Microsoft.Practices.Unity.Utility;

namespace Calculator.Parser.Rules
{
    /// <summary>
    /// Правило для разбора выражений в скобках
    /// </summary>
    public class BracketsRule : RuleBase
    {
        private readonly INotation _notation;

        public BracketsRule(INotation notation)
        {
            Guard.ArgumentNotNull(notation, "notation");

            _notation = notation;
        }

        public override bool Accept(IEnumerator<string> expTokens, IExpression inExpression, out IExpression outExpression)
        {
            if (expTokens.Current == "(")
            {
                MoveNext(expTokens, true);
                outExpression = _notation.Parse(expTokens);
                 
                if (expTokens.Current != ")")
                    throw new Exception("Должна быть закрывающая скобка");

                MoveNext(expTokens, false);
            }
            else
                throw new Exception("Выражение должно начинаться с открывающей скобки");

            return true;
        }
    }
}
