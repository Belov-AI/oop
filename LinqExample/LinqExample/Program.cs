using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LinqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { -15, 125, 356, -489, 6, 28 };

            Console.WriteLine(GetMaxDigitsSumNumber(numbers));

            var strs = File.ReadAllLines("db.txt");
            var dataBase = new List<Record>();

            foreach(var str in strs)
            {
                var data = str.Split();

                var record = new Record()
                {
                    ClientID = int.Parse(data[0]),
                    Year = int.Parse(data[1]),
                    Month = int.Parse(data[2]),
                    Duration = int.Parse(data[3])
                };

                dataBase.Add(record);
            }

            PrintNumberOfClientsPerMonth(2019, dataBase);

            Console.ReadKey();
        }

        static int GetMaxDigitsSumNumber(int[] array)
        {
            return array
            .Select(x => (Math.Abs(x).ToString()
                .Select(d => int.Parse(d.ToString()))
                .Aggregate(0, (s, y) => s + y), x))
            .Max()
            .Item2;
        }

        static void PrintNumberOfClientsPerMonth(int year, List<Record> db)
        {
            var lines = db
            .Where(r => r.Year == year)
            .GroupBy(r => r.Month)
            .Select(g => (g.Key, g.GroupBy(r => r.ClientID).Count()))
            .OrderBy(x => x.Key);
            if (lines.Count() > 0)
            {
                Console.WriteLine($"Данные за {year} г.");
                foreach (var line in lines)
                    Console.WriteLine($"В {line.Key} мес. клиентов: {line.Item2}");
            }
            else
                Console.WriteLine($"За {year} г. нет данных.");
        }
    }
}
