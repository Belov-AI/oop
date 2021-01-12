using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopLibrary;

namespace ShopUnitTestProject
{
    [TestClass]
    public class ShopUnitTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var shop = Data.GetShop();
            
            var priceList = Data.GetPriceListFromShop(shop);
            Assert.AreEqual(3, Data.GetListFromPriceList(priceList).Count);

            var warehouse = Data.GetWarehouseFromShop(shop);
            Assert.AreEqual(2, Data.GetDictionaryFromWarehouse(warehouse).Count);          
        }

        [TestMethod]
        public void GetTest()
        {
            var shop = Data.GetShop();
            var comodity = shop.Get("Телефон", "Apple iPhone 12");

            Assert.IsNotNull(comodity);
            Assert.AreEqual("Телефон", comodity.Category);
            Assert.AreEqual("Apple iPhone 12", comodity.Name);
            Assert.AreEqual(84990, comodity.Price);
        }

        [TestMethod]
        public void GetNullTest()
        {
            var shop = Data.GetShop();

            var comodity = shop.Get("Телефон", "Apple iPhone 13");
            Assert.IsNull(comodity);

            comodity = shop.Get("Телевизор", "Apple iPhone 12");
            Assert.IsNull(comodity);
        }

        [TestMethod]
        public void GetManyTest()
        {
            var shop = Data.GetShop();

            var list = shop.GetMany("теле", "apple");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Телефон", list[0].Category);
            Assert.AreEqual("Apple iPhone 12", list[0].Name);
            Assert.AreEqual(84990, list[0].Price);

            list = shop.GetMany("теле", "");
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("Телевизор", list[0].Category);
            Assert.AreEqual("Samsung UE55TU7097U", list[0].Name);
            Assert.AreEqual(39990, list[0].Price);
            Assert.AreEqual("Телефон", list[1].Category);
            Assert.AreEqual("Apple iPhone 12", list[1].Name);
            Assert.AreEqual(84990, list[1].Price);

            list = shop.GetMany("", "apple");
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("Телефон", list[0].Category);
            Assert.AreEqual("Apple iPhone 12", list[0].Name);
            Assert.AreEqual(84990, list[0].Price);
            Assert.AreEqual("Ноутбук", list[1].Category);
            Assert.AreEqual("Apple MacBook Air", list[1].Name);
            Assert.AreEqual(74990, list[1].Price);
        }

        [TestMethod]
        public void GetManyEmpty()
        {
            var shop = Data.GetShop();
          
            var list = shop.GetMany("ноут", "samsung");
            Assert.AreEqual(0, list.Count);

            list = shop.GetMany("телевизор", "apple");
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void AddTest()
        {
            var shop = Data.GetShop();
            var dict = Data.GetDictionaryFromWarehouse(
                Data.GetWarehouseFromShop(shop));

            var comodity = shop.Get("Ноутбук", "Apple MacBook Air");
            shop.Add(comodity, 2);

            Assert.AreEqual(2, dict.Count);
            Assert.AreEqual(7, dict[comodity]);

            comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);
            shop.Add(comodity, 20);
            Assert.AreEqual(3, dict.Count);
            Assert.AreEqual(20, dict[comodity]);
        }

        [TestMethod]
        public void SaleTest()
        {
            var shop = Data.GetShop();
            var dict = Data.GetDictionaryFromWarehouse(
                Data.GetWarehouseFromShop(shop));

            var comodity = shop.Get("Ноутбук", "Apple MacBook Air");
            shop.Sale(comodity, 2);
            Assert.AreEqual(2, dict.Count);
            Assert.AreEqual(3, dict[comodity]);

            shop.Sale(comodity, 3);
            Assert.AreEqual(1, dict.Count);
            Assert.IsFalse(dict.ContainsKey(comodity));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaleExceptionTest1()
        {
            var shop = Data.GetShop();
            var comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);

            shop.Sale(comodity, 1);
        } 

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaleExceptionTest2()
        {
            var shop = Data.GetShop();
            var comodity = shop.Get("Ноутбук", "Apple MacBook Air");

            shop.Sale(comodity, 10);
        }

        [TestMethod]
        public void CountTest()
        {
            var shop = Data.GetShop();
            var comodity = shop.Get("Ноутбук", "Apple MacBook Air");

            Assert.AreEqual(5, shop.Count(comodity));
        }

        [DataTestMethod]
        public void CountAllTest()
        {
            var shop = Data.GetShop();

            Assert.AreEqual(20, shop.CountAll());
        }
    }
}
