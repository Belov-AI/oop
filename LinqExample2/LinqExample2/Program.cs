using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { -789, 23, 0, 456, 1111, 798 };

            Console.WriteLine(GetMaxDigitsSumNumber(array));
            Console.WriteLine(GetMaxDigitsSumNumber2(array));

            Console.WriteLine(GetMaxDigitsSumNumber(new int[0]));

            Console.ReadKey();
        }

        static int GetMaxDigitsSumNumber(int[] numbers)
        {
            return numbers
                .OrderByDescending(x => Math.Abs(x)
                    .ToString()
                    .Aggregate(0, (s, d) => s + int.Parse(d.ToString())))
                .ThenByDescending(x => x)
                .FirstOrDefault();
        }

        static int GetMaxDigitsSumNumber2(int[] array)
        {
            return array
            .Select(x => (
                Math.Abs(x)
                .ToString()
                .Select(d => int.Parse(d.ToString()))
                .Aggregate(0, (s, y) => s + y), 
                x)
                )
            .Max()
            .Item2;
        }
    }
}
