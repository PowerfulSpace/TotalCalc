using System.ComponentModel.DataAnnotations;

namespace PS.TotalCalc.Web.Models
{
    public class CalculatorViewModel
    {
        [Display(Name = "Первое число")]
        public double? FirstNumber { get; set; }

        [Display(Name = "Второе число")]
        public double? SecondNumber { get; set; }

        [Display(Name = "Оператор")]
        public string Operator { get; set; } = null!;

        [Display(Name = "Результат")]
        public double? Result { get; set; }
    }
}
