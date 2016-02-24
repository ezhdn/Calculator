using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [SetUp]
        public void SetUp()
        {
            UnityContext.Container.RegisterInstance(typeof(IOperationSelector), new OperationsConfiguration());
        }

        [TestCase("122+20*(43-(232/2323)/4)", 15)]
        [TestCase("1+5", 3)]
        [TestCase("12 2  +   20", 3)]
        [TestCase("12 . 2  +   20", 3)]
        public void TokenizeStingCountTest(String expression, int tokensCount)
        {
            var tokens = new Calc().TokenizeExpression(expression);

            Assert.AreEqual(tokens.Count, tokensCount);
        }

        [TestCase("5+6-4*9", -25)]
        [TestCase("5-6+18/9", 1)]
        [TestCase("6*(4+8)", 72)]
        [TestCase("5+6*(4-90/2.5)", -187)]
        [TestCase("4.25*(90.5-35/(12-17))", 414.375)]
        public void EvalTest(string expressionString, decimal result)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var calculator = new Calc();

            Assert.AreEqual(calculator.Eval(expressionString), result);
        }
    }
}
