using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETrade;

namespace ETradeUnitTestProject
{
    [TestClass]
    public class EShopUnitTests
    {
        [TestMethod]
        public void CountTest()
        {
            var shop = GetEShop();
            Assert.AreEqual(10, shop.Count("Телевизор", "Samsung UE55TU7097U"));
            Assert.AreEqual(30, shop.Count("Телефон", "Apple iPhone 12"));
            Assert.AreEqual(5, shop.Count("Ноутбук", "Apple MacBook Air"));
            Assert.AreEqual(0, shop.Count("Пылесос", "Samsung"));
        }

        [TestMethod]
        public void CountOrdersTest()
        {
            var shop = GetEShop();
            Assert.AreEqual(5, shop.CountOrders());
        }

        [TestMethod]
        public void AddOrderTest()
        {
            var shop = new EShop(new OrderCreator());
            Assert.AreEqual(0, shop.CountOrders());

            var comodity = new Comodity("Телефон", "Apple iPhone 12", 84990);
            shop.AddOrder("Телефон\tApple iPhone 12\t84990\t10");
            Assert.AreEqual(1, shop.CountOrders());
            Assert.AreEqual(10, shop.Count("Телефон", "Apple iPhone 12"));

            shop.AddOrder("Телефон\tApple iPhone 12\t84990\t5");
            Assert.AreEqual(2, shop.CountOrders());
            Assert.AreEqual(15, shop.Count("Телефон", "Apple iPhone 12"));

            comodity = new Comodity("Телевизор", "Samsung UE55TU7097U", 39990);
            shop.AddOrder("Телевизор\tSamsung UE55TU7097U\t39990\t20");
            Assert.AreEqual(3, shop.CountOrders());
            Assert.AreEqual(15, shop.Count("Телефон", "Apple iPhone 12"));
            Assert.AreEqual(20, shop.Count("Телевизор", "Samsung UE55TU7097U"));
        }

        [TestMethod]
        public void RemoveOrderTest()
        {
            var shop = GetEShop();
            Assert.AreEqual(5, shop.CountOrders());
            Assert.AreEqual(30, shop.Count("Телефон", "Apple iPhone 12"));

            shop.RemoveOrder(2);
            Assert.AreEqual(4, shop.CountOrders());
            Assert.AreEqual(10, shop.Count("Телефон", "Apple iPhone 12"));
        }

        [TestMethod]
        public void ExecuteOrdersTest()
        {
            var shop = GetEShop();
            Assert.AreEqual(5, shop.CountOrders());

            shop.ExecuteOrders("Телефон", "Apple iPhone 12", 22);
            Assert.AreEqual(4, shop.CountOrders());
            Assert.AreEqual(8, shop.Count("Телефон", "Apple iPhone 12"));
        }

        public EShop GetEShop()
        {
            var shop = new EShop(new OrderCreator());
            var a = new Comodity("Телевизор", "Samsung UE55TU7097U", 39990);
            var b = new Comodity("Телефон", "Apple iPhone 12", 84990);
            var c = new Comodity("Ноутбук", "Apple MacBook Air", 74990);

            shop.AddOrder("Телевизор\tSamsung UE55TU7097U\t39990\t10");
            shop.AddOrder("Телефон\tApple iPhone 12\t84990\t20");
            shop.AddOrder("Ноутбук\tApple MacBook Air\t74990\t5");
            shop.AddOrder("Телефон\tApple iPhone 12\t84990\t5");
            shop.AddOrder("Телефон\tApple iPhone 12\t84990\t5");

            return shop;
        }
    }
}
