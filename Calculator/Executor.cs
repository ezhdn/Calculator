using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Executor
    {
        public static List<String> TokenizeExpression(string expression)
        {
            string parseExpression = expression.Replace(" ", "");

            var reg = new Regex(@"[\+\-/\*]|[\d]+(\.[\d]+)?|[()]");

            return reg.Matches(parseExpression).Cast<Match>().Select(x => x.Value).ToList();
        }
    }
}
