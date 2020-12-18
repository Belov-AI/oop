using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeReflection
{
    [Description("Класс человека")]
    public class Person : ICloneable
    {
        int inn;

        [Description("Имя")]
        public string Name;

        [Description("Фамилия")]
        public string Surname;

        [Description("Возраст")]
        public int Age { get; set; }

        public Person(int number)
        {
            inn = number;
        }

        public void PrintInfo()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
