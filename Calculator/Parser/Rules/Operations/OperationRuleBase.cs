using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Microsoft.Practices.Unity.Utility;

namespace Calculator.Parser.Rules
{
    public abstract class OperationRuleBase: RuleBase
    {
        protected readonly IOperationSelector _operationSelector;
        protected readonly string[] _operations;
        protected readonly INotation _notation;

        protected OperationRuleBase(IOperationSelector operationSelector, string[] operations, INotation notation)
        {
            Guard.ArgumentNotNull(operationSelector, "operationSelector");
            Guard.ArgumentNotNull(operations, "operations");
            Guard.ArgumentNotNull(notation, "notation");

            _operationSelector = operationSelector;
            _operations = operations;
            _notation = notation;
        }   

        protected bool CheckOperation(string operationToken)
        {
            if (!_operations.Contains(operationToken))
                throw new Exception(String.Format("Ожидались операции {0}, а не {1}", String.Join(", ", _operations),
                    operationToken));

            return true;
        }
    }
}
