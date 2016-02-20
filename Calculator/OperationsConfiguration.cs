using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Calculator.Operations;

namespace Calculator
{
    public class OperationsConfiguration : IOperationSelector
    {
        public Dictionary<String, IOperation> _operations = new Dictionary<string, IOperation>
        {
            {"+", new Add()},
            {"-", new Sub()},
            {"/", new Div()},
            {"*", new Mul()},
        };

        public Dictionary<String, IUnaryOperation> _unaryOperations = new Dictionary<string, IUnaryOperation>
        {
            {"+", new Add()},
            {"-", new Sub()},
        };

        public IOperation GetOperation(string operationToken)
        {
            IOperation operation;

            if (!_operations.TryGetValue(operationToken, out operation))
                throw new Exception(String.Format("Операция - {0} - не поддерживается", operationToken));

            return operation;
        }

        public IUnaryOperation GetUnaryOperation(string operationToken)
        {
            IUnaryOperation operation;

            if (!_unaryOperations.TryGetValue(operationToken, out operation))
                throw new Exception(String.Format("Унарная операция - {0} - не поддерживается", operationToken));

            return operation;
        }
    }
}
