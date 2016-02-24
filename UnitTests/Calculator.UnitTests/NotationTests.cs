using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Calculator.Parser;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace Calculator.UnitTests
{
    [TestFixture]
    //Тут больше интеграционный тест, чем модульный
    public class NotationTests
    {
        [SetUp]
        public void SetUp()
        {
            UnityContext.Container.RegisterInstance(typeof (IOperationSelector), new OperationsConfiguration());
        }

        [TestCase("5+6-4+9", 16)]
        [TestCase("5-6+4-9", -6)] 
        public void SimpleNatationTest(string expressionString, decimal result)
        {
            IOperationSelector selector = new OperationsConfiguration();

            INotation number = new Notation(false).AddNumeric();
            INotation expression = new Notation(false);

            expression.Add(number).AddOperation(new[] {"+", "-"}, number, ExpressionRepeatType.NoneOrMore);

            var expressionTokens = new Calc().TokenizeExpression(expressionString).GetEnumerator();
            expressionTokens.MoveNext();

            IExpression exp = expression.Parse(expressionTokens);
            Assert.AreEqual(exp.Execute(), result);
        }

        [TestCase("5+6-4*9", -25)]
        [TestCase("5-6+18/9", 1)]
        [TestCase("6*(4+8)", 72)]
        [TestCase("5+6*(4-90/2.5)", -187)]
        [TestCase("4.25*(90.5-35/(12-17))", 414.375)]
        public void NotationTest(string expressionString, decimal result)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            IOperationSelector selector = new OperationsConfiguration();

            INotation expression = new Notation(false);
            INotation factor = new Notation(true).AddNumeric().AddBracketRule(expression);
            INotation term = new Notation(false).Add(factor).AddOperation(new[] {"*", "/"}, factor, ExpressionRepeatType.NoneOrMore);
            expression.Add(term).AddOperation(new[] { "+", "-" }, term, ExpressionRepeatType.NoneOrMore);

            var expressionTokens = new Calc().TokenizeExpression(expressionString).GetEnumerator();
            expressionTokens.MoveNext();

            IExpression exp = expression.Parse(expressionTokens);
            Assert.AreEqual(exp.Execute(), result);
        }
    }
}
