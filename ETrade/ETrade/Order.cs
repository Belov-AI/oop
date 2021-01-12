using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade
{
    public class Order
    {
        public int ID { get; }
        public Comodity Goods { get; }
        public int Quantity { get; set; }

        public Order(int id, Comodity comodity, int quantity)
        {
            ID = id;
            Goods = comodity;
            Quantity = quantity;
        }
    }
}
