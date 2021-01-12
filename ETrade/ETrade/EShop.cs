using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade
{
    public class EShop
    {
        List<Order> orders;
        OrderCreator creator;
        int nextID;

        public EShop(OrderCreator creator)
        {
            this.orders = new List<Order>();
            this.creator = creator;
            nextID = 1;
        }

        public void AddOrder(string record)
        {
            orders.Add(creator.Create(nextID++, record));
        }

        public void RemoveOrder(int id)
        {
            // Написать удаление заказа из списка по заданому ID
            
            throw new NotImplementedException();
        }


        public void ExecuteOrders(string category, string name, int totalQuantity)
        {
            // totalQuantity — общее количество данного товара, поступившее от поставщиков, 
            // т. е. которое можно выдать по заказам.
            // Определить метод, который находит заказы на данный товар
            // и, если в заказе количество не больше, чем оставшееся общее колличество,
            // то удаляет заказ из списка. Если количество в заказе больше, 
            // чем оставшееся общее колличество (заказ будет выполнен частично),
            // то уменьшает количество товаров в заказе, оставляя заказ в списке

            throw new NotImplementedException();
        }

        public int Count(string category, string name)
        {
            // Метод должен возвращать общее количество данного товара,
            // заказанного во всех имеющихся заказах

            throw new NotImplementedException();
        }

        public int CountOrders()
        {
            // Мтеод должен возвращать общще количество заказов
            
            throw new NotImplementedException();
        }
    }
}
