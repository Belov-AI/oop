using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Comodity
    {
        public string Category { get; }
        public string Name { get; }
        public int Price { get;}

        public Comodity(string category, string name, int price)
        {
            Category = category;
            Name = name;
            Price = price;
        }

        public static Comodity Parse(string record)
        {
            // написать метод, который по строке в формате
            // категория, название, цена (в этом порядке), разделенные табуляцией,
            // возвращает объект товара
            
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            //переопределить метод так, чтобы возвращалась строка в формате
            // категория, название, цена (в этом порядке), разделенные табуляцией
            
            throw new NotImplementedException();
        }

    }
}
