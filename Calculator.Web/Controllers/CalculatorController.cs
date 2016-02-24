using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Calculator.Web.Controllers
{
    public class CalculatorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Eval(string expression)
        {
            var calculator = new Calc();

            try
            {
                return Ok(calculator.Eval(expression));
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
