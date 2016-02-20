using Calculator.Expressions;
using Calculator.Interfaces;
using Calculator.Operations;
using NUnit.Framework;
using Rhino.Mocks;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class OperationsTest
    {
        public decimal TestSimpleOperation<T>(decimal arg1, decimal arg2) where T : IOperation, new()
        {
            IOperation op = new T();

            var first = MockRepository.GenerateStub<IExpression>();
            first.Expect(e => e.Execute()).Return(arg1);

            var second = MockRepository.GenerateStub<IExpression>();
            second.Expect(e => e.Execute()).Return(arg2);

            return op.Eval(first, second);
        } 

        [TestCase(12.5555, 12, 24.5555)]
        [TestCase(0.1, 0.245, 0.345)]
        [TestCase(12, 4, 16)]
        public void SumTest(decimal arg1, decimal arg2, decimal result)
        {
            Assert.AreEqual(TestSimpleOperation<Add>(arg1, arg2), result);
        }

        [TestCase(45.5, 15.5, 30)]
        [TestCase(70, 20.25, 49.75)]
        [TestCase(12, 4, 8)]
        public void Sub(decimal arg1, decimal arg2, decimal result)
        {
            Assert.AreEqual(TestSimpleOperation<Sub>(arg1, arg2), result);
        }

        [TestCase(6.4, 4, 1.6)]
        [TestCase(1000, 0.25, 4000)]
        [TestCase(12, 4, 3)]
        public void DivTest(decimal arg1, decimal arg2, decimal result)
        {
            Assert.AreEqual(TestSimpleOperation<Div>(arg1, arg2), result);
        }

        [TestCase(1.5, 1.5, 2.25)]
        [TestCase(25000, 0.2, 5000)]
        [TestCase(12, 4, 48)]
        public void MulTest(decimal arg1, decimal arg2, decimal result)
        {
            Assert.AreEqual(TestSimpleOperation<Mul>(arg1, arg2), result);
        }

        [TestCase(100, 100)]
        public void AddUnaryTest(decimal arg, decimal result)
        {
            IUnaryOperation add = new Add();
            var exp = MockRepository.GenerateStub<IExpression>();
            exp.Expect(e => e.Execute()).Return(arg);

            Assert.AreEqual(add.Eval(exp), result);
        }

        [TestCase(100, -100)]
        public void MinusUnaryTest(decimal arg, decimal result)
        {
            IUnaryOperation add = new Sub();
            var exp = MockRepository.GenerateStub<IExpression>();
            exp.Expect(e => e.Execute()).Return(arg);

            Assert.AreEqual(add.Eval(exp), result);
        }
    }
}
