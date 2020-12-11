using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTask3
{
    class Program
    {
        static void Main()
        {
            var groups = new List<Group> {
                new Group() {Students = new List<string> { "Николай", "Петр", "Иван", "Наталья", "Елена" } },
                new Group() {Students = new List<string>  {"Софья", "Андрей"} },
                new Group() {Students = new List<string> {"Софья", "Андрей", "Николай" } },
                new Group() {Students = new List<string>() },
                new Group() {Students = new List<string> {"Алексей", "Николай"} }
                };

            var students = groups
                .SelectMany(group => group.Students)
                .Distinct()
                .ToList();

            PrintSequence(students);

            //сортировка в алфавитном порядке
            students = groups
                .SelectMany(group => group.Students)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            PrintSequence(students);

            //сортировка в порядке уменьшения длины слова, а затем в алфавитном порядке
            students = groups
                .SelectMany(group => group.Students)
                .Distinct()
                .OrderByDescending(name => name.Length)
                .ThenBy(name => name)
                .ToList();

            PrintSequence(students);

            students = groups
                .SelectMany(group => group.Students)
                .Distinct()
                .ToList();

            Console.WriteLine(students.Min());
            Console.WriteLine(students.Max());
            Console.WriteLine(students.Max(name => name.Length));

            Console.ReadKey();
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine();
        }

    }
}
