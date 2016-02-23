using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Calculator.Parser.Rules;

namespace Calculator.Parser
{

    /// <summary>
    /// Класс для разбор выражений методом рекурсивного спуска
    /// 
    /// В данной реализации будет использоваться грамматика следующего вида:
    /// 
    ///     expression = ["+"|"-"] term {("+"|"-") term} .
    ///     term = factor {("*"|"/") factor} .
    ///     factor = number | "(" expression ")"
    ///
    /// </summary>
    public class Notation : INotation
    {
        private readonly IOperationSelector _operationSelector;

        private readonly bool _isMultiVariant;

        public Notation(IOperationSelector operationSelector, bool isMultivariant)
        {
            _operationSelector = operationSelector;
            _isMultiVariant = isMultivariant;
        }

        private List<IRule> _rules = new List<IRule>();

        public virtual IExpression Parse(IEnumerator<string> expressionTokens)
        {
            IExpression expression = null;
            foreach (var rule in _rules)
            {
                IExpression outExpression;

                if (_isMultiVariant)
                {
                    try
                    {
                        rule.Accept(expressionTokens, expression, out outExpression);
                        expression = outExpression;
                    }
                    catch { }
                }
                else
                {
                    rule.Accept(expressionTokens, expression, out outExpression);
                    expression = outExpression;
                }
            }
            
            if (expression == null)
                throw new Exception("Не найдено ни одного правила для разбора сообщения");
            
            return expression;
        }

        public INotation Add(INotation notation)
        {
            _rules.Add(new Rule(notation));

            return this;
        }

        public INotation MayBeOperation(string[] operations, INotation notation, ExpressionRepeatType repeatType)
        {
            _rules.Add(new OperationRule(_operationSelector, operations, notation, repeatType));

            return this;
        }

        public INotation AddUnaryOperation(string[] operations, INotation notation)
        {
            _rules.Add(new UnaryOperarationRule(_operationSelector, operations, notation));

            return this;
        }

        public INotation AddBracketRule(INotation notation)
        {
            _rules.Add(new BracketsRule(notation));

            return this;
        }

        public INotation AddNumeric()
        {
            _rules.Add(new NumericRule());

            return this;
        }
    }
}
