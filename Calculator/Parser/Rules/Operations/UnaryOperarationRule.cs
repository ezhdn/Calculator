﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Expressions;
using Calculator.Interfaces;

namespace Calculator.Parser.Rules
{
    /// <summary>
    /// Правило для определения унарной операции над выражением
    /// </summary>
    public class UnaryOperarationRule : OperationRuleBase
    {
        public UnaryOperarationRule(string[] operations, INotation notation)
            : base(operations, notation)
        {
        }

        public override bool Accept(IEnumerator<string> expTokens, IExpression inExpression,
            out IExpression outExpression)
        {
            IUnaryOperation operation = _operationSelector.GetUnaryOperation(expTokens.Current);
            MoveNext(expTokens, true);
            IExpression expression = _notation.Parse(expTokens);

            outExpression = new UnaryExpression(operation, expression);

            return true;
        }
    }
}
