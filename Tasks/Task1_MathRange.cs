using System;
using System.Collections.Generic;
using Lab01_Advanced.Core;
using Lab01_Advanced.Utils;

namespace Lab01_Advanced.Tasks
{
    public class Task1_MathRange : ITask
    {
        // Властивість, яка відображатиметься в нашому головному меню
        public string Name => "Завдання 1: Функція f(x) = x^2 (З аналітикою та графіком)";

        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Налаштування параметрів f(x) = x^2 ---");
            Console.ResetColor();
            
            // Використовуємо наш безпечний валідатор!
            double xMin = InputValidator.ReadDouble("Введіть початкове значення xMin: ");
            double xMax = InputValidator.ReadDouble("Введіть кінцеве значення xMax: ");
            double dx = InputValidator.ReadDouble("Введіть крок dx: ");

            // Базовий захист від нескінченних циклів
            if (xMax < xMin || dx <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[Критична помилка] xMax має бути більшим за xMin, а крок dx > 0.");
                Console.ResetColor();
                return;
            }

            // Змінні для статистики (Достатній рівень)
            double minY = double.MaxValue;
            double maxY = double.MinValue;
            double sumY = 0;
            int count = 0;
            int positiveCount = 0;
            int negativeCount = 0;

            // Зберігаємо значення для побудови графіка
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔══════════╦══════════════╗");
            Console.WriteLine("║    x     ║      y       ║");
            Console.WriteLine("╠══════════╬══════════════╣");
            Console.ResetColor();

            // Цикл обчислень (+ 0.0001 компенсує машинну похибку чисел з плаваючою крапкою)
            for (double x = xMin; x <= xMax + 0.0001; x += dx)
            {
                double y = Math.Pow(x, 2); // Обчислення функції
                
                xValues.Add(x);
                yValues.Add(y);

                // Збір аналітики під час циклу
                if (y < minY) minY = y;
                if (y > maxY) maxY = y;
                sumY += y;
                count++;

                if (y > 0) positiveCount++;
                if (y < 0) negativeCount++; // У функції x^2 їх не буде, але вимога є вимога

                // Вивід з ідеальним вирівнюванням
                Console.WriteLine($"║ {x,8:F2} ║ {y,12:F2} ║");
            }
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════╩══════════════╝\n");
            Console.ResetColor();

            // Виведення аналітики (Достатній рівень)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Аналітика функції ---");
            Console.ResetColor();
            Console.WriteLine($"Максимальне значення:  {maxY:F2}");
            Console.WriteLine($"Мінімальне значення:   {minY:F2}");
            Console.WriteLine($"Середнє значення:      {(sumY / count):F2}");
            Console.WriteLine($"Додатних значень:      {positiveCount}");
            Console.WriteLine($"Від'ємних значень:     {negativeCount}\n");

            // Блок Високого рівня: Візуалізація
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("--- Візуалізація (ASCII-графік) ---");
            Console.ResetColor();
            
            int maxBarLength = 40; // Максимальна ширина графіка в символах
            
            for (int i = 0; i < xValues.Count; i++)
            {
                // Визначаємо довжину смужки відносно максимального значення
                int barLen = maxY > 0 ? (int)((yValues[i] / maxY) * maxBarLength) : 0;
                string bar = new string('█', barLen);
                
                Console.Write($"{xValues[i],6:F2} | ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(bar);
                Console.ResetColor();
            }
        }
    }
}