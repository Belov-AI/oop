using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class PriceList
    {
        List<Comodity> list;

        public PriceList(string[] records)
        {
            // Конструктор должен заполнять список товаров
            // по массиву строк в формате категория, название, цена (в этом порядке),
            // разделенные табуляцией.
            
            throw new NotImplementedException();
        }

        public PriceList()
        {
            list = new List<Comodity>();
        }

        public Comodity Get(string category, string name)
        {
            // Метод должен вернуть товар, соответсвующий заданным категории и имени
            // Если такого товара нет, то должен возвращаться null
            
            throw new NotImplementedException();
        }

        public List<Comodity> GetMany(string category, string name)
        {
            // Метод должен вернуть список товаров, соответсвующий заданным категории и имени
            // Если таких товаров нет, то должнен возпращаться пустой список.
            // Поиск должен быть контекстным и независимым от регистра.

            throw new NotImplementedException();
        }
    }
}
