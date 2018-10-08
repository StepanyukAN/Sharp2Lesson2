namespace Lesson_2
{
    /// <summary>
    /// Работник с фиксированной оплатой
    /// </summary>
    class FixedWageWorker : Worker
    {
        public FixedWageWorker(int rate, string name) : base(rate, name)
        {
        }

        public override string ToString() => "Работник с фиксированной оплатой " + base.ToString();

        /// <summary>
        /// Расчет зарплаты
        /// </summary>
        /// <returns>Фиксированный оклад</returns>
        public override double SalaryCalculation() => Rate;
        
    }
}
