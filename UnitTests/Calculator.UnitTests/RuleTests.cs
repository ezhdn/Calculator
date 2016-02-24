using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Calculator.Expressions;
using Calculator.Interfaces;
using Calculator.Operations;
using Calculator.Parser;
using Calculator.Parser.Rules;
using NUnit.Framework;
using Rhino.Mocks;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class RuleTests
    {
        private INotation GetNotationStub()
        {
            var notation = MockRepository.GenerateStub<INotation>();
            notation.Stub(_ => _.Parse(Arg<IEnumerator<String>>.Is.Anything))
                .Return(null)
                .WhenCalled(_ =>
                {
                    var tokens = (IEnumerator<String>) _.Arguments[0];
                    string stringNumber = tokens.Current;

                    decimal number;

                    if (!Decimal.TryParse(stringNumber, out number))
                        throw new Exception("Ожидался цифровой литерал");
                    _.ReturnValue = new NumericExpression(number);

                    tokens.MoveNext();
                });

            return notation;
        }

        [Test]
        public void ParseNumericExpressionTest()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var numericRule = new NumericRule();

            IEnumerator<String> expressionTokens = new List<string>() { "34", "98984.5", "dfdsfdf" }.GetEnumerator();

            expressionTokens.MoveNext();
            IExpression result;
            numericRule.Accept(expressionTokens, null, out result);
            Assert.IsInstanceOf<NumericExpression>(result);

            numericRule.Accept(expressionTokens, null, out result);
            Assert.IsInstanceOf<NumericExpression>(result);

            Assert.Throws<Exception>(() => numericRule.Accept(expressionTokens, null, out result));
        }

        [Test]
        public void SimpleOperationRuleTest()
        {
            var operationSelector = MockRepository.GenerateStub<IOperationSelector>();
            operationSelector.Expect(e => e.GetOperation("-")).Return(new Sub());
            operationSelector.Expect(e => e.GetOperation("+")).Return(new Add());

            var notation = GetNotationStub();

            var operationRule = new OperationRule(operationSelector, new[] {"+", "-"}, notation, ExpressionRepeatType.NoneOrMore);

            var inExp = MockRepository.GenerateStub<IExpression>();
            inExp.Expect(e => e.Execute()).Return(5);

            IExpression outExp;
            IEnumerator<string> expressionTokens = new List<string> {"+", "40", "-", "20"}.GetEnumerator();
            expressionTokens.MoveNext();
            bool result = operationRule.Accept(expressionTokens, inExp, out outExp);

            Assert.AreEqual(result, true);
            Assert.AreEqual(outExp.Execute(), 25);

            expressionTokens = new List<string> { "+", "40", "-"}.GetEnumerator();
            expressionTokens.MoveNext();
            Assert.Throws<Exception>(() => operationRule.Accept(expressionTokens, inExp, out outExp));
        }

        [Test]
        public void UnaryOperationRuleTests()
        {
            var operationSelector = MockRepository.GenerateStub<IOperationSelector>();
            operationSelector.Expect(e => e.GetUnaryOperation("-")).Return(new Sub());
            operationSelector.Expect(e => e.GetUnaryOperation("+")).Return(new Add());

            var notation = GetNotationStub();

            var operationRule = new UnaryOperarationRule(operationSelector, new[] { "+", "-" }, notation);

            IExpression outExp;
            IEnumerator<string> expressionTokens = new List<string> { "-", "40" }.GetEnumerator();
            expressionTokens.MoveNext();
            bool result = operationRule.Accept(expressionTokens, null, out outExp);

            Assert.AreEqual(result, true);
            Assert.AreEqual(outExp.Execute(), -40);
        }

        [Test]
        public void BracketsRuleTest()
        {
            var inExp = MockRepository.GenerateStub<IExpression>();
            inExp.Expect(e => e.Execute()).Return(5);

            var notation = GetNotationStub();

            var operationRule = new BracketsRule(notation);

            IExpression outExp;

            IEnumerator<string> expressionTokens = new List<string> {"(", "40", ")" }.GetEnumerator();
            expressionTokens.MoveNext();
            bool result = operationRule.Accept(expressionTokens, inExp, out outExp);

            Assert.AreEqual(result, true);
            Assert.AreEqual(outExp.Execute(), 40);

            expressionTokens = new List<string> { "(", "40"}.GetEnumerator();
            expressionTokens.MoveNext();

            Assert.AreEqual(result, true);
            Assert.Throws<Exception>(() => operationRule.Accept(expressionTokens, inExp, out outExp));

            expressionTokens = new List<string> { "40" }.GetEnumerator();
            expressionTokens.MoveNext();

            Assert.AreEqual(result, true);
            Assert.Throws<Exception>(() => operationRule.Accept(expressionTokens, inExp, out outExp));
        }
    }
}
