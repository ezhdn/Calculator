﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Expressions;
using Calculator.Interfaces;

namespace Calculator.Parser.Rules
{
    public class OperationRule : RuleBase
    {
        private readonly IOperationSelector _operationSelector;
        private readonly string[] _operations;
        private readonly INotation _notation;
        private readonly ExpressionRepeatType _repeatType;

        public OperationRule(IOperationSelector operationSelector, string[] operations, INotation notation, ExpressionRepeatType repeatType)
        {
            _operationSelector = operationSelector;
            _operations = operations;
            _notation = notation;
            _repeatType = repeatType;
        }

        public override bool Accept(IEnumerator<string> expTokens, IExpression inExpression, out IExpression outExpression)
        {
            IExpression resultExp = inExpression;
            while (expTokens.Current != null && CheckOperation(expTokens.Current))
            {
                IOperation operation = _operationSelector.GetOperation(expTokens.Current);
                MoveNext(expTokens, true);
                IExpression expression = _notation.Parse(expTokens);

                resultExp = new BinaryExpression(resultExp, expression, operation);

                expTokens.MoveNext();
            }

            outExpression = resultExp;

            return true;
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
