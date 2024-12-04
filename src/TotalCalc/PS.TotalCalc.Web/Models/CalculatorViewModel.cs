namespace PS.TotalCalc.Web.Models
{
    public class CalculatorViewModel
    {
        public string Display { get; set; } = "0"; // Текущий ввод
        public string FirstOperand { get; set; } = string.Empty;
        public string SecondOperand { get; set; } = string.Empty;
        public string Operator { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
    }
}
