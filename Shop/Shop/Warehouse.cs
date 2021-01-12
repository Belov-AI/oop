using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Warehouse
    {
        Dictionary<Comodity, int> dict;

        public Warehouse(string[] records, PriceList list)
        {
            // Конструктор дожен по записям в фомате категория, название, количество
            // (именно в этом порядке) и по заданному прайс-листу заполнить словаь склада товарами
            // На склад дожлны быть помещены только товары, имеющиеся в прайс-листе.
            
            throw new NotImplementedException();
        }

        public void Add(Comodity comodity, int count)
        {
            // Метод должен добавлять на склад товар в указанном количестве

            throw new NotImplementedException();
        }

        public void Sale(Comodity comodity, int count)
        {
            // Метод должен регистрировать продажу товара со склада.
            // Если такого товара нет, то дожно выбрасываться исключение
            // с сообщением "Необходимого товара нет на складе".
            // Если товар есть, но в недостаточном количестве,
            // то должно выбрасываться исключение
            // с сообщением "Необходимого количества нет на складе".
            // Если товар полностью распродан, он не долен числиться на складе.

            throw new NotImplementedException();
        }

        public int Count(Comodity comodity)
        {
            // Метод должен подсчитывать количество заданного товара на складе;
            
            throw new NotImplementedException();
        }

        public int CountAll()
        {
            // Метод должен подсчитывать общее количество товаров на складе;

            throw new NotImplementedException();
        }
    }
}
