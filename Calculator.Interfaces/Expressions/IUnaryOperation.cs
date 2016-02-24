using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    /// <summary>
    /// Интерфейс унарной операции
    /// </summary>
    public interface IUnaryOperation
    {
        decimal Eval(IExpression expression);
    }
}
