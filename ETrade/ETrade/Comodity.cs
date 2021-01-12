using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade
{
    public class Comodity
    {
        public string Category { get;}
        public string Name { get;}
        public int Price { get; set; }

        public Comodity(string category, string name, int price)
        {
            Category = category;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            //переопределить метод так, чтобы возвращалась строка в формате
            // категория, название, цена, количество (в этом порядке), разделенные табуляцией
            
            throw new NotImplementedException();
        }

    }
}
