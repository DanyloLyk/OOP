using System;
using System.Collections.Generic;
using System.Linq; // Підключаємо для магічної обробки списків
using Lab01_Advanced.Core;
using Lab01_Advanced.Utils;

namespace Lab01_Advanced.Tasks
{
    public class Task2_TwoVariables : ITask
    {
        public string Name => "Завдання 2: Функція двох змінних (LINQ-аналітика)";

        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Налаштування параметрів f(x1, x2) = x1^2 + e^x2 ---");
            Console.ResetColor();

            // Введення даних для першої змінної
            double x1Min = InputValidator.ReadDouble("Введіть початкове значення x1Min: ");
            double x1Max = InputValidator.ReadDouble("Введіть кінцеве значення x1Max: ");
            double dx1 = InputValidator.ReadDouble("Введіть приріст dx1: ");

            // Введення даних для другої змінної
            Console.WriteLine();
            double x2Min = InputValidator.ReadDouble("Введіть початкове значення x2Min: ");
            double x2Max = InputValidator.ReadDouble("Введіть кінцеве значення x2Max: ");
            double dx2 = InputValidator.ReadDouble("Введіть приріст dx2: ");

            if (x1Max < x1Min || dx1 <= 0 || x2Max < x2Min || dx2 <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[Критична помилка] Некоректні межі або кроки (Max має бути >= Min, dx > 0).");
                Console.ResetColor();
                return;
            }

            // Використовуємо кортежі (Tuples) для збереження рядків даних перед виводом
            var results = new List<(double x1, double x2, double y)>();

            // Обчислення всіх значень
            for (double x1 = x1Min; x1 <= x1Max + 0.0001; x1 += dx1)
            {
                for (double x2 = x2Min; x2 <= x2Max + 0.0001; x2 += dx2)
                {
                    double y = Math.Pow(x1, 2) + Math.Exp(x2);
                    results.Add((x1, x2, y));
                }
            }

            // Магія LINQ: знаходимо екстремуми без ручних циклів порівняння
            double maxY = results.Max(r => r.y);
            double minY = results.Min(r => r.y);
            double avgY = results.Average(r => r.y);
            int posCount = results.Count(r => r.y > 0);
            int negCount = results.Count(r => r.y < 0);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔══════════╦══════════╦══════════════════╗");
            Console.WriteLine("║    x1    ║    x2    ║        y         ║");
            Console.WriteLine("╠══════════╬══════════╬══════════════════╣");
            Console.ResetColor();

            // Вивід таблиці з кольоровим форматуванням
            foreach (var row in results)
            {
                // Якщо значення співпадає з максимумом - фарбуємо зеленим
                if (Math.Abs(row.y - maxY) < 0.000001)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                // Якщо співпадає з мінімумом - фарбуємо червоним
                else if (Math.Abs(row.y - minY) < 0.000001)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                
                // Виводимо з високою точністю (F4), бо експонента дає багато знаків
                Console.WriteLine($"║ {row.x1,8:F2} ║ {row.x2,8:F2} ║ {row.y,16:F4} ║");
                Console.ResetColor(); // Скидаємо колір для наступного рядка
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════╩══════════╩══════════════════╝\n");
            Console.ResetColor();

            // Аналітика
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Аналітика функції ---");
            Console.ResetColor();
            
            Console.Write("Максимальне значення:  ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{maxY:F4}");
            Console.ResetColor();
            
            Console.Write("Мінімальне значення:   ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{minY:F4}");
            Console.ResetColor();
            
            Console.WriteLine($"Середнє значення:      {avgY:F4}");
            Console.WriteLine($"Додатних значень:      {posCount}");
            Console.WriteLine($"Від'ємних значень:     {negCount}\n");
        }
    }
}