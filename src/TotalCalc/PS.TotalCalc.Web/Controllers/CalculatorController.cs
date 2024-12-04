using Microsoft.AspNetCore.Mvc;
using PS.TotalCalc.Web.Models;

namespace PS.TotalCalc.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private static CalculatorViewModel _model = new CalculatorViewModel();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string input)
        {
            if ("0123456789.".Contains(input))
            {
                if (_model.Operator == null)
                    _model.FirstOperand += input;
                else
                    _model.SecondOperand += input;

                _model.Display = (_model.Operator == null ? _model.FirstOperand : _model.SecondOperand);
            }
            else if ("+-×÷".Contains(input))
            {
                _model.Operator = input;
            }
            else if (input == "=")
            {
                double.TryParse(_model.FirstOperand, out double first);
                double.TryParse(_model.SecondOperand, out double second);
                _model.Result = _model.Operator switch
                {
                    "+" => (first + second).ToString(),
                    "-" => (first - second).ToString(),
                    "×" => (first * second).ToString(),
                    "÷" => (second != 0 ? (first / second).ToString() : "Error"),
                    _ => "Error"
                };
                _model.Display = _model.Result;
                Reset();
            }
            else if (input == "C")
            {
                Reset();
            }

            return Content(_model.Display);
        }

        private void Reset()
        {
            _model = new CalculatorViewModel();
        }
    }
}
