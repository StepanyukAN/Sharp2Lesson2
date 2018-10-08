namespace Lesson_2
{
    /// <summary>
    /// Работник с почасовой оплатой
    /// </summary>
    class HourlyWageWorker : Worker
    {
        public HourlyWageWorker(int rate, string name) : base(rate, name)
        {
        }

        /// <summary>
        /// Расчет зарплаты
        /// </summary>
        /// <returns>Расчет производится по формуле: 20.8 * 8 * Почасовая оплата</returns>
        public override double SalaryCalculation() => 20.8 * 8 * Rate;

        public override string ToString()=> "Работник с почасовой оплатой " + base.ToString();
        
    }
}
