using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main()
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var evenNumbers = numbers.Where(x => x % 2 == 0);

            PrintSequence(numbers);
            PrintSequence(evenNumbers);

            var primeNumbers = numbers.Where(IsPrime);
            PrintSequence(primeNumbers);

            var squares = numbers.Select(x => x * x);
            PrintSequence(squares);

            //печатаем кубы нечетных чисел

            PrintSequence(numbers
                .Where(x => x % 2 != 0)
                .Select(x => x * x * x)
                );

            var list1 = new List<int>() { 1, 2, 3, 4 };
            var list2 = new List<int>() { 5, 6, 7 };
            var list3 = new List<int>() { 8, 9, 10, 11, 12, 13};

            var lists = new[] { list1, list2, list3 };

            //var resultList = new List<int>();

            //foreach (var list in lists)
            //    foreach (var number in list)
            //        resultList.Add(number);

            var resultList = lists
                .SelectMany(list => list)
                .ToList();

            PrintSequence(resultList);

            //вывести на консоль второй и третий квадрат четных чисел массива
            PrintSequence(numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * x)
                .Skip(1)
                .Take(2)
                );

            PrintSequence(resultList.OrderByDescending(x => x));

            var bits = new[] { 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0 };
            PrintSequence(bits
                .OrderBy(x => x)
                );

            PrintSequence(bits
                .OrderBy(x => x)
                .Distinct()
                );

            resultList.Add(14);

            Console.WriteLine($"Минимум: {resultList.Min()}");
            Console.WriteLine($"Максимум: {resultList.Max()}");
            Console.WriteLine($"Среднее: {resultList.Average()}");

            Console.WriteLine(resultList.All(x => x > 0));
            Console.WriteLine(resultList.All(x => x % 2 == 0));
            Console.WriteLine(resultList.Any(x => x % 2 == 0));
            Console.WriteLine(resultList.Any(x => x < 0));

            Console.WriteLine(resultList.Aggregate(1.0, (s, x) => s * x, res => Math.Pow(res, 1.0 / resultList.Count())));

            Console.ReadKey();
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (var elem in sequence)
                Console.Write($"{elem} ");

            Console.WriteLine();
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            var result = true;
            var bound = Math.Sqrt(number);

            for(var d = 2; d <= bound; d++)
                if(number % d == 0)
                {
                    result = false;
                    break;
                }

            return result;
        }


    }
}
