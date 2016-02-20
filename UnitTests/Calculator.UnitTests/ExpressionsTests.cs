using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Expressions;
using Calculator.Interfaces;
using Calculator.Operations;
using NUnit.Framework;
using Rhino.Mocks;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class ExpressionsTests
    {
        [TestCase(1.5, 1.5, 2.25)]
        [TestCase(25000, 0.2, 5000)]
        public void BinaryExpressionTest(decimal arg1, decimal arg2, decimal result)
        {
            var first = MockRepository.GenerateStub<IExpression>();
            first.Expect(e => e.Execute()).Return(arg1);

            var second = MockRepository.GenerateStub<IExpression>();
            second.Expect(e => e.Execute()).Return(arg2);

            var op = MockRepository.GenerateStub<IOperation>();
            op.Expect(e => e.Eval(first, second)).Return(result);

            IExpression exp = new BinaryExpression(first, second, op);

            Assert.AreEqual(exp.Execute(), result);
        }

        [TestCase(100, -100)]
        public void UnaryExpressionTest(decimal arg, decimal result)
        {
            var unaryExp = MockRepository.GenerateStub<IExpression>();
            unaryExp.Expect(e => e.Execute()).Return(arg);

            var op = MockRepository.GenerateStub<IUnaryOperation>();
            op.Expect(e => e.Eval(unaryExp)).Return(result);

            IExpression exp = new UnaryExpression(op, unaryExp);

            Assert.AreEqual(exp.Execute(), result);
        }

        //-(arg3/arg4*arg5)
        [TestCase(20, 5, 100, 4, 2, 25)]
        public void ComplexExpressionTest(decimal arg1, decimal arg2, decimal arg3, decimal arg4, decimal arg5, decimal result)
        {
            IExpression addExp = new BinaryExpression(new NumericExpression(arg1), new NumericExpression(arg2), new Add());

            IExpression divExp = new BinaryExpression(new NumericExpression(arg3), new NumericExpression(arg4), new Div());
            IExpression mulExp = new BinaryExpression(divExp, new NumericExpression(arg5), new Mul());

            IExpression subExp = new BinaryExpression(addExp, mulExp, new Sub());

            IExpression unaryMinusExp = new UnaryExpression(new Sub(), subExp);

            Assert.AreEqual(unaryMinusExp.Execute(), result);
        }
    }
}
