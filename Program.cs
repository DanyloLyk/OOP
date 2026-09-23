using System;
using System.Collections.Generic;
using Lab01_Advanced.Core;
using Lab01_Advanced.Tasks;

namespace Lab01_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            // Обов'язково для коректного відображення української мови та псевдографіки
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Поки список порожній, сюди будемо додавати наші Task1, Task2 і т.д.
            var tasks = new List<ITask>
            {
                new Task1_MathRange(),
                new Task2_TwoVariables(),
                new Task3_Factorials(),
                new Task4_PerfectNumbers(),
                new Task5_TextAnalyzer(),
            };

            AppMenu menu = new AppMenu(tasks);
            menu.Show();
        }
    }
}