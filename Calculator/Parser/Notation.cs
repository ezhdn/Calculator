using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;

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


        public virtual IExpression Parse(IEnumerator<string> expressionTokens)
        {
            throw new NotImplementedException();
        }

        public INotation AddRule(INotation notation)
        {
            throw new NotImplementedException();
        }

        public INotation MayBeOperation(string[] operators, INotation notation)
        {
            throw new NotImplementedException();
        }

        public INotation AddUnaryOperation(string[] operators, INotation notation)
        {
            throw new NotImplementedException();
        }
    }
}
