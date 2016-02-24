using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Utility;

namespace Calculator.Parser.Rules
{
    public abstract class OperationRuleBase: RuleBase
    {
        protected readonly IOperationSelector _operationSelector;
        protected readonly string[] _operations;
        protected readonly INotation _notation;

        protected OperationRuleBase(string[] operations, INotation notation)
        {
            Guard.ArgumentNotNull(operations, "operations");
            Guard.ArgumentNotNull(notation, "notation");

            _operationSelector = UnityContext.Container.Resolve<IOperationSelector>();
            _operations = operations;
            _notation = notation;
        }   

        protected bool CheckOperation(string operationToken)
        {
            return _operations.Contains(operationToken);
        }
    }
}
