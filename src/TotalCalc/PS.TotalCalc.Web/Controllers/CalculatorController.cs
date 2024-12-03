using Microsoft.AspNetCore.Mvc;
using PS.TotalCalc.Web.Models;

namespace PS.TotalCalc.Web.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorViewModel());
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorViewModel model)
        {
            if (model.FirstNumber == null || model.SecondNumber == null || string.IsNullOrEmpty(model.Operator))
            {
                ModelState.AddModelError("", "Введите все данные корректно.");
                return View("Index", model);
            }

            switch (model.Operator)
            {
                case "+":
                    model.Result = model.FirstNumber + model.SecondNumber;
                    break;
                case "-":
                    model.Result = model.FirstNumber - model.SecondNumber;
                    break;
                case "*":
                    model.Result = model.FirstNumber * model.SecondNumber;
                    break;
                case "/":
                    if (model.SecondNumber == 0)
                    {
                        ModelState.AddModelError("", "Деление на ноль невозможно.");
                    }
                    else
                    {
                        model.Result = model.FirstNumber / model.SecondNumber;
                    }
                    break;
                default:
                    ModelState.AddModelError("", "Неверный оператор.");
                    break;
            }

            return View("Index", model);
        }
    }
}
