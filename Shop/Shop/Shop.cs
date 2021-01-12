using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Shop
    {
        PriceList priceList;
        Warehouse warehouse;

        public Shop (Warehouse warehouse, PriceList priceList)
        {
            this.priceList = priceList;
            this.warehouse = warehouse;
        }

        public Comodity Get(string category, string name)
        {
            return priceList.Get(category, name);
        }

        public List<Comodity> GetMany(string category, string name)
        {
            return priceList.GetMany(category, name);
        }

        public void Add(Comodity comodity, int count)
        {
            warehouse.Add(comodity, count);
        }

        public void Sale(Comodity comodity, int count)
        {
            warehouse.Sale(comodity, count);
        }

        public int Count(Comodity comodity)
        {
            return warehouse.Count(comodity);
        }

        public int CountAll()
        {
            return warehouse.CountAll();
        }


    }
}
