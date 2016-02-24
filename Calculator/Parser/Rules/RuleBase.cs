using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;

namespace Calculator.Parser.Rules
{
    /// <summary>
    /// Базовое правило для опеределения грамматик
    /// </summary>
    public abstract class RuleBase : IRule
    {
        public abstract bool Accept(IEnumerator<string> expTokens, IExpression inExpression,
            out IExpression outExpression);

        protected bool MoveNext(IEnumerator<string> expressionTokens, bool requeredToken)
        {
            bool moveResult = expressionTokens.MoveNext();

            if (!moveResult && requeredToken)
                throw new Exception("Неправильное выражение. Наверное что-то пропущено");

            return moveResult;
        }
    }
}
