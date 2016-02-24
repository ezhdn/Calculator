using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    /// <summary>
    /// Интерфейс получения описания операции по строковому литералу
    /// </summary>
    public interface IOperationSelector
    {
        IOperation GetOperation(String operationToken);

        IUnaryOperation GetUnaryOperation(String operationToken);
    }
}
