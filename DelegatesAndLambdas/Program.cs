using System;
using System.Collections.Generic;

namespace MessageProcessing
{
    public class Program
    {
        public static void Main()
        {
            const int MinimumLength = 3; // минимальная длина строки по заданию

            while (true)
            {
                Console.WriteLine("\nОбработка сообщений\n1. Обработать сообщения\n0. Выход");
                Console.Write("\nВыберите действие: ");
                string choice = Console.ReadLine()!;

                try
                {
                    if (choice == "0")
                        break;

                    if (choice == "1")
                    {
                        Console.Write("\nВведите количество сообщений: ");
                        int count = int.Parse(Console.ReadLine()!);

                        if (count <= 0)
                            throw new ArgumentException("Количество должно быть больше нуля.");

                        List<string> messages = new List<string>();

                        for (int i = 0; i < count; i++)
                        {
                            Console.Write($"Введите сообщение {i + 1}: ");
                            string message = Console.ReadLine()!;
                            messages.Add(message);
                        }

                        List<string> history = new List<string>();

                        Func<string, bool> isLongMessage = message => message.Length > MinimumLength;
                        Func<string, string> prepareMessage = message => "[LOG] " + message.ToUpper();

                        Action<string> printResult = message => Console.WriteLine($"Результат: {message}");
                        Action<string> saveResult = message => history.Add(message);

                        Action<string> reportResult = printResult;
                        reportResult += saveResult;

                        Console.WriteLine("\nОбработка:");

                        foreach (string message in messages)
                        {
                            if (isLongMessage(message))
                                reportResult(prepareMessage(message));
                        }

                        Console.WriteLine($"\nСохранено сообщений: {history.Count}");
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

