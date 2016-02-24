using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    /// <summary>
    /// Интерфейс выражения, может быть как узлом так и листом дерева разбора
    /// </summary>
    public interface IExpression
    {
        decimal Execute();
    }
}
