using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopLibrary;

namespace ShopUnitTestProject
{
    [TestClass]
    public class PriceListTests
    {
        [TestMethod]
        public void ConstructorsTest()
        {
            var priceList = new PriceList();
            var list = Data.GetListFromPriceList(priceList);

            Assert.AreEqual(0, list.Count);

            priceList = new PriceList(Data.GetPriceRecords());
            list = Data.GetListFromPriceList(priceList);

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("Телевизор", list[0].Category);
            Assert.AreEqual("Samsung UE55TU7097U", list[0].Name);
            Assert.AreEqual(39990, list[0].Price);
            Assert.AreEqual("Телефон", list[1].Category);
            Assert.AreEqual("Apple iPhone 12", list[1].Name);
            Assert.AreEqual(84990, list[1].Price);
            Assert.AreEqual("Ноутбук", list[2].Category);
            Assert.AreEqual("Apple MacBook Air", list[2].Name);
            Assert.AreEqual(74990, list[2].Price);
        }

        [TestMethod]
        public void GetTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var list = Data.GetListFromPriceList(priceList);
            var comodity = priceList.Get("Телефон", "Apple iPhone 12");

            Assert.IsNotNull(comodity);
            Assert.AreEqual("Телефон", comodity.Category);
            Assert.AreEqual("Apple iPhone 12", comodity.Name);
            Assert.AreEqual(84990, comodity.Price);
        }

        [TestMethod]
        public void GetNull()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var list = Data.GetListFromPriceList(priceList);

            var comodity = priceList.Get("Телефон", "Apple iPhone 13");
            Assert.IsNull(comodity);

            comodity = priceList.Get("Телевизор", "Apple iPhone 12");
            Assert.IsNull(comodity);
        }

        [TestMethod]
        public void GetManyTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());

            var list = priceList.GetMany("теле", "apple");
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Телефон", list[0].Category);
            Assert.AreEqual("Apple iPhone 12", list[0].Name);
            Assert.AreEqual(84990, list[0].Price);

            list = priceList.GetMany("теле", "");
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("Телевизор", list[0].Category);
            Assert.AreEqual("Samsung UE55TU7097U", list[0].Name);
            Assert.AreEqual(39990, list[0].Price);
            Assert.AreEqual("Телефон", list[1].Category);
            Assert.AreEqual("Apple iPhone 12", list[1].Name);
            Assert.AreEqual(84990, list[1].Price);

            list = priceList.GetMany("", "apple");
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
            var priceList = new PriceList(Data.GetPriceRecords());
            var list = priceList.GetMany("ноут", "samsung");
            Assert.AreEqual(0, list.Count);

            list = priceList.GetMany("телевизор", "apple");
            Assert.AreEqual(0, list.Count);
        }
    }
}
