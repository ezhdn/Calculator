using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class ExecutorTests
    {
        [TestCase("122+20*(43-(232/2323)/4)", 15)]
        [TestCase("1+5", 3)]
        [TestCase("12 2  +   20", 3)]
        [TestCase("12 . 2  +   20", 3)]
        public void TokenizeStingCountTest(String expression, int tokensCount)
        {
            var tokens = Executor.TokenizeExpression(expression);

            Assert.AreEqual(tokens.Count, tokensCount);
        }

    }
}
