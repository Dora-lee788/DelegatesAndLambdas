using System;
using System.Collections.Generic;

namespace NumberProcessing
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nОбработка чисел\n1. Обработать числа\n0. Выход");
                Console.Write("\nВыберите действие: ");
                string choice = Console.ReadLine()!;

                try
                {
                    if (choice == "0")
                        break;

                    if (choice == "1")
                    {
                        Console.Write("\nВведите количество чисел: ");
                        int count = int.Parse(Console.ReadLine()!);

                        if (count <= 0)
                            throw new ArgumentException("Количество должно быть больше нуля.");

                        List<int> numbers = new List<int>();

                        for (int i = 0; i < count; i++)
                        {
                            Console.Write($"Введите число {i + 1}: ");
                            int number = int.Parse(Console.ReadLine()!);
                            numbers.Add(number);
                        }

                        List<int> history = new List<int>();

                        Func<int, bool> isEven = n => n % 2 == 0;
                        Func<int, int> square = n => n * n;

                        Action<int> printResult = n => Console.WriteLine($"Результат: {n}");
                        Action<int> saveResult = n => history.Add(n);

                        Action<int> reportResult = printResult;
                        reportResult += saveResult;

                        Console.WriteLine("\nОбработка:");

                        foreach (int number in numbers)
                        {
                            if (isEven(number))
                                reportResult(square(number));
                        }

                        Console.WriteLine($"\nСохранено результатов: {history.Count}");
                    }
                    else
                    {
                        Console.WriteLine("\nОшибка: такого пункта меню нет.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nОшибка: нужно ввести целое число.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"\nОшибка: {ex.Message}");
                }
            }
        }
    }
}

