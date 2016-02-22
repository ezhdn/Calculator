using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface IOperation
    {
        decimal Eval(IExpression first, IExpression second);
    }
}
