using System;

namespace Lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker[] workers = new Worker[]
                {
                    new FixedWageWorker(10200,"Гавриил Брджанский"),
                    new HourlyWageWorker(120, "Святогуб Земляничкин"),
                    new FixedWageWorker(16870,"Ледоруб Саратов"),
                    new FixedWageWorker(22510,"Берлиоз Иванов"),
                    new HourlyWageWorker(58, "Ингеборга Мозгоклюева"),
                    new HourlyWageWorker(100, "Карп Головоротченко"),
                };
        
            Department department = new Department();

            Console.WriteLine("Вывод через foreach\n");
            foreach (var worker in department)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine("\nТеперь массив отсортирован\n");

            Array.Sort(workers);
            foreach (var worker in workers)
            {
                Console.WriteLine(worker);
            }
            Console.ReadKey();
        }
    }
}
