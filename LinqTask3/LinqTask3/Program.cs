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
            var students1 = groups
                .SelectMany(group => group.Students)
                .OrderByDescending(name => name.Length)
                .ThenBy(name => name)
                .ToList();
            PrintSequence(students1);

            //var students2 = groups
            //    .SelectMany(group => group.Students)
            //    .OrderBy(name => (-name.Length, name))
            //    .ToList();
            //PrintSequence(students2);

            PrintSequence(students);

            students = groups
                .SelectMany(group => group.Students)
                .Distinct()
                .ToList();

            Console.WriteLine(students.Min());
            Console.WriteLine(students.Max());
            Console.WriteLine(students.Max(name => name.Length));

            //самое длинное лексикографически первое имя
            Console.WriteLine(students
                .Min(name => (-name.Length, name))
                .Item2);

            var dict = students
                .GroupBy(name => name.Length)
                .ToDictionary(group => group.Key);
            //.ToDictionary(name => name.Length); //так нельзя

            var lookUp = students.ToLookup(name => name.Length);

            PrintSequence(dict[5]);
            PrintSequence(lookUp[5]);

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
