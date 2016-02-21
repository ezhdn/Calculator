using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Expressions;
using Calculator.Parser;
using NUnit.Framework;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class NotationTests
    {
        [Test]
        public void ParseNumericExpression()
        {
            var numericNotation = new NumericNotation();

            IEnumerator<String> expressionTokens = new List<string>() { "34", "sdfsdfdsf", "98984" }.GetEnumerator();

            expressionTokens.MoveNext();
            Assert.IsInstanceOf<NumericExpression>(numericNotation.Parse(expressionTokens));
            expressionTokens.MoveNext();
            Assert.Throws<Exception>(() => numericNotation.Parse(expressionTokens));
            expressionTokens.MoveNext();
            Assert.IsInstanceOf<NumericExpression>(numericNotation.Parse(expressionTokens));
        }


    }
}
