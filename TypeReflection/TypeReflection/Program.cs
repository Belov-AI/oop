using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TypeReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var t2 = Type.GetType("TypeReflection.Person");
           
            var person = new Person(12345);
            person.Name = "Анна";
            person.Surname = "Петрова";
            person.Age = 18;
            person.PrintInfo();

            var t3 = person.GetType();

            var t = typeof(Person);

            PrintTypeName(t);
            PrintFields(t);
            PrintPrivateFields(t);
            PrintProperties(t);
            PrintMethods(t);
            PrintInterfaces(t);
            PrintClassDescription(t);
            PrintFieldsDescription(t);
            PrintPropertiesDescription(t);

            var anna = t
                .GetConstructor(new Type[] { typeof(int) })
                .Invoke(new object[] { 12345 });

            t.GetField("Name").SetValue(anna, "Анна");

            Console.WriteLine(t.GetField("Name").GetValue(anna));

            t.GetField("Surname").SetValue(anna, "Петрова");
            t.GetProperty("Age").SetValue(anna, 18);
            t.GetMethod("PrintInfo").Invoke(anna, new object[] { });
            t.GetField("inn", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(anna, 6789);

            Console.ReadKey();
        }

        static void PrintTypeName(Type t)
        {
            Console.WriteLine("===== Тип =====");
            Console.WriteLine(t.Name);
        }

        static void PrintFields(Type t)
        {
            Console.WriteLine("===== Поля =====");
            PrintMemberNames(t
                .GetFields()
                .Select(f => f.Name)
                );
        }

        static void PrintPrivateFields(Type t)
        {
            Console.WriteLine("===== Закрытые поля =====");
            PrintMemberNames(t
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(f => f.Name)
                );
        }

        static void PrintProperties(Type t)
        {
            Console.WriteLine("===== Свойства =====");
            PrintMemberNames(t
                .GetProperties()
                .Select(f => f.Name)
                );
        }

        static void PrintMethods(Type t)
        {
            Console.WriteLine("===== Методы =====");
            PrintMemberNames(t
                .GetMethods()
                .Select(f => f.Name)
                );
        }

        static void PrintInterfaces(Type t)
        {
            Console.WriteLine("===== Интерфейсы =====");
            PrintMemberNames(t
                .GetInterfaces()
                .Select(f => f.Name)
                );
        }

        static void PrintClassDescription(Type t)
        {
            Console.WriteLine("===== Атрибуты класса =====");
            PrintMemberNames(t
                .GetCustomAttributes<DescriptionAttribute>()
                .Select(a => a.Text));
        }

        static void PrintFieldsDescription(Type t)
        {
            Console.WriteLine("===== Атрибуты полей =====");
            PrintMemberNames(t
                .GetFields()
                .Select(f => f.GetCustomAttributes<DescriptionAttribute>())
                .SelectMany(a => a)
                .Select(a => a.Text));
        }

        static void PrintPropertiesDescription(Type t)
        {
            Console.WriteLine("===== Атрибуты свойств =====");
            PrintMemberNames(t
                .GetProperties()
                .Select(f => f.GetCustomAttributes<DescriptionAttribute>())
                .SelectMany(a => a)
                .Select(a => a.Text));
        }

        static void PrintMemberNames(IEnumerable<string> sequence)
        {
            foreach (var elem in sequence)
                Console.WriteLine($"-> {elem}");
        }
    }
}
