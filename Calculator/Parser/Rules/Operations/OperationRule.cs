using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Expressions;
using Calculator.Interfaces;

namespace Calculator.Parser.Rules
{
    public class OperationRule : OperationRuleBase
    {
        private readonly ExpressionRepeatType _repeatType;

        public OperationRule(IOperationSelector operationSelector, string[] operations, INotation notation,
            ExpressionRepeatType repeatType) : base(operationSelector, operations, notation)
        {
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

                if(_repeatType == ExpressionRepeatType.One)
                    break;
            }

            outExpression = resultExp;

            return true;
        }
    }
}
