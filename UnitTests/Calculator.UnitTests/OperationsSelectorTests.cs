using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class OperationsSelectorTests
    {
        private IOperationSelector _selector;

        [SetUp]
        public void RunBefore()
        {
            _selector = new OperationsConfiguration();
        }

        [TestCase("+", typeof(Add))]
        [TestCase("-", typeof(Sub))]
        [TestCase("/", typeof(Div))]
        [TestCase("*", typeof(Mul))]
        public void SelectOperationTest(String operationToken, Type resultType)
        {
            Assert.IsInstanceOf(resultType, _selector.GetOperation(operationToken));
        }

        [TestCase("+", typeof(Add))]
        [TestCase("-", typeof(Sub))]
        public void SelectUnaryOperationTest(String operationToken, Type resultType)
        {
            Assert.IsInstanceOf(resultType, _selector.GetUnaryOperation(operationToken));
        }
    }
}
