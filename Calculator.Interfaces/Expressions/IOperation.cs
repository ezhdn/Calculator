using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    /// <summary>
    /// Интерфейс описания операции
    /// </summary>
    public interface IOperation
    {
        decimal Eval(IExpression first, IExpression second);
    }
}
