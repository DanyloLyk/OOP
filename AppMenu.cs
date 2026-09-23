using System;
using System.Collections.Generic;
using Lab01_Advanced.Core;

namespace Lab01_Advanced
{
    public class AppMenu
    {
        private List<ITask> _tasks;

        public AppMenu(List<ITask> tasks)
        {
            _tasks = tasks;
        }

        public void Show()
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                
                // Шапка меню з псевдографікою
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                 ЛАБОРАТОРНА РОБОТА №1                  ║");
                Console.WriteLine("║            Розробка консольних застосунків             ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");
                Console.ResetColor();

                // Рядок підказок
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(" [↑/↓] Навігація  |  [Enter] Вибір  |  [Esc] Вихід\n");
                Console.ResetColor();

                // Рендер пунктів завдань
                for (int i = 0; i < _tasks.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        // Форматування ,-50 вирівнює блок виділення на 50 символів вшир
                        Console.WriteLine($"  ► {_tasks[i].Name,-50} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"    {_tasks[i].Name,-50} ");
                        Console.ResetColor();
                    }
                }
                
                // Окремий рендер для кнопки "Вихід"
                if (selectedIndex == _tasks.Count)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n  ► {"Вихід з програми",-50} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"\n    {"Вихід з програми",-50} ");
                    Console.ResetColor();
                }

                // Перехоплення клавіш
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0) selectedIndex = _tasks.Count;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex > _tasks.Count) selectedIndex = 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (selectedIndex == _tasks.Count) break; // Вихід
                    
                    Console.Clear();
                    Console.CursorVisible = true;
                    
                    // "Хлібні крихти" перед запуском завдання
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"=== {_tasks[selectedIndex].Name} ===\n");
                    Console.ResetColor();

                    // Запуск самого завдання
                    _tasks[selectedIndex].Execute();
                    
                    // Блок повернення
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\n[ Натисніть будь-яку клавішу для повернення в головне меню ]");
                    Console.ResetColor();
                    Console.ReadKey(true);
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }

            } while (true);
        }
    }
}