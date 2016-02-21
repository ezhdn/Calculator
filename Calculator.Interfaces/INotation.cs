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

        INotation AddRule(INotation notation);

        INotation MayBeOperation(string[] operators, INotation notation);

        INotation AddUnaryOperation(string[] operators, INotation notation);
    }
}
