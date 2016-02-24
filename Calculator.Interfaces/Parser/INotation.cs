using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    /// <summary>
    /// Интерфейс описания правил грамматики
    /// </summary>
    public interface INotation
    {
        IExpression Parse(IEnumerator<string> expressionTokens);

        INotation Add(INotation notation);

        INotation AddOperation(string[] operations, INotation notation, ExpressionRepeatType repeatType);

        INotation AddUnaryOperation(string[] operations, INotation notation);

        INotation AddBracketRule(INotation notation);

        INotation AddNumeric();
    }
}
