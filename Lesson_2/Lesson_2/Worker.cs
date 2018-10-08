using System;

namespace Lesson_2
{
    /// <summary>
    /// Базовый абстрактный класс работник
    /// </summary>
    abstract class Worker:IComparable<Worker>
    {
        /// <summary>
        /// Свойство для тарифной ставки
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Метод для расчета зарплаты
        /// </summary>
        /// <returns>Возвращает размер заработной платы работника</returns>
        public abstract double SalaryCalculation();

        public override string ToString() => $"{FullName} c зарплатой {SalaryCalculation()}";

        /// <summary>
        /// Реализация интерфейса IComparable
        /// </summary>
        /// <param name="obj">работник с которым сравниваем</param>
        /// <returns></returns>
        public int CompareTo(Worker obj)
        {
            if (SalaryCalculation() > obj.SalaryCalculation()) return 1;
            else if (SalaryCalculation() < obj.SalaryCalculation()) return -1;
            else return 0;
        }



        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rate">Тарифная ставка</param>
        /// <param name="name">ФИО работника</param>
        public Worker(int rate, string name)
        {
            Rate = rate;
            FullName = name;
        }
    }
}
