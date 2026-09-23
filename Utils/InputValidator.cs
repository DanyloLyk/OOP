using System;
using System.Globalization;

namespace Lab01_Advanced.Utils
{
    public static class InputValidator
    {
        // Безпечне зчитування дробових чисел (для Завдання 1 і 2)
        public static double ReadDouble(string prompt)
        {
            double result;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(prompt);
                Console.ResetColor();
                
                string input = Console.ReadLine() ?? "";
                
                // Заміна коми на крапку, щоб не було конфліктів локалізації ПК
                if (!string.IsNullOrEmpty(input))
                {
                    input = input.Replace(',', '.');
                }

                // Використовуємо InvariantCulture, щоб крапка завжди працювала
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                {
                    return result;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  [Помилка] Введіть коректне число (наприклад: 2.5 або -10).");
                Console.ResetColor();
            }
        }

        // Безпечне зчитування цілих чисел (для Завдання 3 і 4) з можливістю задати діапазон
        public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int result;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(prompt);
                Console.ResetColor();
                
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out result))
                {
                    if (result >= min && result <= max)
                    {
                        return result; // Число валідне і входить у діапазон
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"  [Помилка] Число має бути в діапазоні від {min} до {max}.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  [Помилка] Будь ласка, введіть ціле число без дробів та літер.");
                    Console.ResetColor();
                }
            }
        }
    }
}