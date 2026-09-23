using System;
using System.Linq;
using Lab01_Advanced.Core;

namespace Lab01_Advanced.Tasks
{
    public class Task5_TextAnalyzer : ITask
    {
        public string Name => "Завдання 5: Аналізатор тексту (Мультимовний сканер)";

        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Інтелектуальний аналіз тексту ---");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введіть текст для аналізу (можна використовувати українську та англійську):");
            Console.ResetColor();
            
            string text = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[Помилка] Текст не може бути пустим. Немає що аналізувати.");
                Console.ResetColor();
                return;
            }

            // 1. Кількість символів (включно з пробілами)
            int charCount = text.Length;

            // 2. Кількість слів (розбиваємо по пробілах та знаках пунктуації)
            char[] wordSeparators = { ' ', '\r', '\n', '\t', ',', ';', ':', '-', '\"', '\'', '(', ')' };
            int wordCount = text.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries).Length;

            // 3. Кількість речень (розбиваємо по крапках, знаках оклику та питання)
            char[] sentenceSeparators = { '.', '!', '?' };
            int sentenceCount = text.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries).Length;

            // 4. Голосні та приголосні (Підтримка UA + EN)
            string vowels = "аеєиіїоуюяaeiou";
            string consonants = "бвгґджзйклмнпрстфхцчшщbcdfghjklmnpqrstvwxyz";

            // Переводимо текст у нижній регістр для простішого пошуку
            string lowerText = text.ToLower();

            int vowelCount = lowerText.Count(c => vowels.Contains(c));
            int consonantCount = lowerText.Count(c => consonants.Contains(c));

            // Відмальовка красивої таблиці результатів
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔══════════════════════════════════════╦════════════╗");
            Console.WriteLine("║ Метрика                              ║ Значення   ║");
            Console.WriteLine("╠══════════════════════════════════════╬════════════╣");
            Console.ResetColor();

            PrintRow("Загальна кількість символів", charCount);
            PrintRow("Кількість слів", wordCount);
            PrintRow("Кількість речень", sentenceCount);
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╠══════════════════════════════════════╬════════════╣");
            Console.ResetColor();
            
            PrintRow("Кількість голосних літер", vowelCount);
            PrintRow("Кількість приголосних літер", consonantCount);
            
            // Рахуємо "інші" символи (цифри, пробіли, розділові знаки)
            int otherChars = charCount - (vowelCount + consonantCount);
            PrintRow("Інші символи (пробіли, цифри, знаки)", otherChars);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════════════════════════════════╩════════════╝\n");
            Console.ResetColor();
        }

        // Допоміжний метод для красивого вирівнювання рядків таблиці
        private void PrintRow(string metricName, int value)
        {
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{metricName,-36}"); // Вирівнювання тексту зліва (36 символів)
            Console.ResetColor();
            
            Console.Write(" ║ ");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{value,10}"); // Вирівнювання чисел справа (10 символів)
            Console.ResetColor();
            
            Console.WriteLine(" ║");
        }
    }
}