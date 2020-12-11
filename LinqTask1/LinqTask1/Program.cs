using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace LinqTask1
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Введите имя файла");

            var fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                var text = File.ReadAllLines(fileName);
                PrintSequence(GetIntArray(text));
            }
            else
                Console.WriteLine("Файл не найден"); 

            Console.ReadKey();
        }

        static int[] GetIntArray(string[] lines)
        {
            return lines
                .Where(line => line.Length > 0)
                .Select(line => int.Parse(line))
                .ToArray();
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine();
        }
    }
}
