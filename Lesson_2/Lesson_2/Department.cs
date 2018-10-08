using System.Collections;
using System.Collections.Generic;

namespace Lesson_2
{
    /// <summary>
    /// Класс для вывода списка работников через foreach
    /// с помощью реализации интерфейсов IEnumerable и IEnumerator
    /// </summary>
    class Department : IEnumerable, IEnumerator
    {
        private readonly List<Worker> department;
        private int count = -1;

        public Department()
        {
            department = new List<Worker>();
            department.AddRange(new Worker[]
                {
                    new FixedWageWorker(10200,"Гавриил Брджанский"),
                    new HourlyWageWorker(120, "Святогуб Земляничкин"),
                    new FixedWageWorker(16870,"Ледоруб Саратов"),
                    new FixedWageWorker(22510,"Берлиоз Иванов"),
                    new HourlyWageWorker(58, "Ингеборга Мозгоклюева"),
                    new HourlyWageWorker(100, "Карп Головоротченко"),
                });
        }

        public object Current => department[count];



        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < department.Count; i++)
            {
                yield return department[i];
            }
        }
       

        public bool MoveNext()
        {
            bool isMove = count < department.Count-1;
            if (isMove) Reset();
            else count++;

            return isMove;
        }

        public void Reset()
        {
            count = -1;
        }

    }
}
