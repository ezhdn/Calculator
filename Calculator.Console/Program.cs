using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var calculator = new Calc();
            bool runned = true;

            while (runned)
            {
                System.Console.Write("Введите выражение: ");

                String expression = System.Console.ReadLine();

                if (expression.ToLower() == "q")
                    runned = false;
                else
                {
                    decimal result = calculator.Eval(expression);

                    System.Console.WriteLine(String.Format("Результат: {0}", result));
                }
            }
        }
    }
}
