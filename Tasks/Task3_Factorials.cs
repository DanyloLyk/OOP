using System;
using System.Numerics; // Необхідно для роботи з надвеликими числами (BigInteger)
using Lab01_Advanced.Core;
using Lab01_Advanced.Utils;

namespace Lab01_Advanced.Tasks
{
    public class Task3_Factorials : ITask
    {
        public string Name => "Завдання 3: Факторіали та їх сума (Без лімітів пам'яті)";

        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Обчислення n! та суми факторіалів ---");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Підказка: Завдяки BigInteger ліміт n=20 знято. Можете ввести хоч 100!");
            Console.ResetColor();

            // Використовуємо наш валідатор цілих чисел, обмежуємо до 500, щоб консоль не зависла від рендеру
            int n = InputValidator.ReadInt("Введіть число n (від 1 до 500): ", 1, 500);

            BigInteger currentFactorial = 1;
            BigInteger sumOfFactorials = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔══════╦════════════════════════════════════════════════════╗");
            Console.WriteLine("║  i   ║                    Поточний i!                     ║");
            Console.WriteLine("╠══════╬════════════════════════════════════════════════════╣");
            Console.ResetColor();

            // Цикл обчислень та виводу проміжних результатів
            for (int i = 1; i <= n; i++)
            {
                currentFactorial *= i;
                sumOfFactorials += currentFactorial;

                string factStr = currentFactorial.ToString();
                
                // Якщо число стає занадто довгим для таблиці (більше 48 символів), ми його візуально обрізаємо
                if (factStr.Length > 48)
                {
                    factStr = factStr.Substring(0, 45) + "...";
                }

                Console.WriteLine($"║ {i,4} ║ {factStr,50} ║");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════╩════════════════════════════════════════════════════╝\n");
            Console.ResetColor();

            // Виведення підсумкової інформації
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Фінальні результати ---");
            Console.ResetColor();
            
            Console.Write($"Факторіал числа {n}!: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(currentFactorial); // Тут виводимо повне число, яким би величезним воно не було
            Console.ResetColor();

            Console.WriteLine();

            Console.Write($"Сума всіх факторіалів від 1! до {n}!: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(sumOfFactorials);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}