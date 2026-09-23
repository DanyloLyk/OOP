using System;
using System.Collections.Generic;
using Lab01_Advanced.Core;
using Lab01_Advanced.Utils;

namespace Lab01_Advanced.Tasks
{
    public class Task4_PerfectNumbers : ITask
    {
        public string Name => "Завдання 4: Досконалі числа (З анімацією пошуку)";

        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Пошук досконалих чисел ---");
            Console.ResetColor();

            // Введення початку та кінця діапазону з валідацією
            int start = InputValidator.ReadInt("Введіть початок діапазону: ", 1);
            int end = InputValidator.ReadInt("Введіть кінець діапазону: ", start); // Кінець не може бути меншим за початок

            Console.WriteLine($"\nПошук досконалих чисел в діапазоні від {start} до {end}...\n");

            bool foundAny = false;
            
            // Масив символів для анімації завантаження
            string[] spinner = { "/", "-", "\\", "|" };
            int spinnerCounter = 0;

            // Перебір всіх чисел в діапазоні
            for (int number = start; number <= end; number++)
            {
                // Анімація: оновлюємо UI кожні 10 ітерацій, щоб не перевантажувати консоль
                if (number % 10 == 0 || number == end)
                {
                    // \r повертає курсор на початок рядка, не переносячи його вниз
                    Console.Write($"\r[ {spinner[spinnerCounter % 4]} ] Сканування: {number} з {end}...");
                    spinnerCounter++;
                }

                int sum = 0;
                List<int> divisors = new List<int>();

                // Пошук всіх дільників числа
                for (int i = 1; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        sum += i;
                        divisors.Add(i);
                    }
                }

                // Перевірка, чи є число досконалим
                if (sum == number && number > 1) 
                {
                    // Затираємо рядок зі спінером перед виводом знайденого числа
                    Console.Write("\r".PadRight(Console.WindowWidth) + "\r");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[+] Знайдено досконале число: {number}");
                    Console.ResetColor();
                    
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"    Його дільники: {string.Join(", ", divisors)}\n");
                    Console.ResetColor();
                    
                    foundAny = true;
                }
            }

            // Затираємо фінальний кадр спінера
            Console.Write("\r".PadRight(Console.WindowWidth) + "\r");

            // Виведення результатів пошуку
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Пошук завершено! ---");
            Console.ResetColor();
            
            if (!foundAny)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("На жаль, досконалих чисел у заданому діапазоні не знайдено.");
                Console.ResetColor();
            }
        }
    }
}