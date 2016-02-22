using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface INotation
    {
        IExpression Parse(IEnumerator<string> expressionTokens);

        INotation Add(INotation notation);

        INotation MayBeOperation(string[] operations, INotation notation, ExpressionRepeatType repeatType);

        INotation AddUnaryOperation(string[] operations, INotation notation);
    }
}
