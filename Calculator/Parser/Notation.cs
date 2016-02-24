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
        private readonly bool _isMultiVariant;

        public Notation(bool isMultivariant)
        {
            _isMultiVariant = isMultivariant;
        }

        private List<IRule> _rules = new List<IRule>();

        public virtual IExpression Parse(IEnumerator<string> expressionTokens)
        {
            if (!_isMultiVariant)
            {
                IExpression expression = null;

                foreach (var rule in _rules)
                {
                    IExpression outExpression;

                    if (rule.Accept(expressionTokens, expression, out outExpression))
                        expression = outExpression;
                }

                return expression;
            }
            else
            {
                IExpression expression = null;
                foreach (var rule in _rules)
                {
                    IExpression outExpression;

                    try
                    {
                        bool acceptResult = rule.Accept(expressionTokens, expression, out outExpression);

                        if (acceptResult)
                        {
                            expression = outExpression;
                            break;
                        }
                    }
                    catch{}
                }

                if (expression == null)
                    throw new Exception("Не найдено ни одного правила для разбора сообщения");

                return expression;
            }
        }

        /// <summary>
        /// Добавление обычного правила
        /// </summary>
        public INotation Add(INotation notation)
        {
            _rules.Add(new Rule(notation));

            return this;
        }

        /// <summary>
        /// Добавление правила с операциями
        /// </summary>
        public INotation AddOperation(string[] operations, INotation notation, ExpressionRepeatType repeatType)
        {
            _rules.Add(new OperationRule(operations, notation, repeatType));

            return this;
        }

        /// <summary>
        /// Добавление унарной операции в правило
        /// </summary>
        public INotation AddUnaryOperation(string[] operations, INotation notation)
        {
            _rules.Add(new UnaryOperarationRule(operations, notation));

            return this;
        }

        /// <summary>
        /// Добавление выражения под скобками
        /// </summary>
        public INotation AddBracketRule(INotation notation)
        {
            _rules.Add(new BracketsRule(notation));

            return this;
        }

        /// <summary>
        /// Добавление числового выражения
        /// </summary>
        /// <returns></returns>
        public INotation AddNumeric()
        {
            _rules.Add(new NumericRule());

            return this;
        }
    }
}
