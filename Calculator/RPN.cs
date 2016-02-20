using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;

namespace Calculator
{
    public class RPN
    {
        private readonly IOperationSelector _operationSelector;

        public RPN(IOperationSelector operationSelector)
        {
            _operationSelector = operationSelector;
        }

        public string Parse(string expression)
        {
            
        }
    }
}
