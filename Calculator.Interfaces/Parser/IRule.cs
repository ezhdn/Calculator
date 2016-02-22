using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface IRule
    {
        bool Accept(IEnumerator<String> expTokens, IExpression inExpression, out IExpression outExpression);
    }
}
