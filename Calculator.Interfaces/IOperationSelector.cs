using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface IOperationSelector
    {
        IOperation GetOperation(String operationToken);

        IUnaryOperation GetUnaryOperation(String operationToken);
    }
}
