using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopLibrary;

namespace ShopUnitTestProject
{
    [TestClass]
    public class WarehouseUnitTests
    {
       [TestMethod]
        public void ConstructorTest()
        {
            var warehouse = new Warehouse( Data.GetQuantityRecords(), 
                new PriceList(Data.GetPriceRecords()));

            var dict = Data.GetDictionaryFromWarehouse(warehouse);
            Assert.AreEqual(2, dict.Count);
        }

        [TestMethod]
        public void AddTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var dict = Data.GetDictionaryFromWarehouse(warehouse);

            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");
            warehouse.Add(comodity, 2);

            Assert.AreEqual(2, dict.Count);
            Assert.AreEqual(7, dict[comodity]);

            comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);
            warehouse.Add(comodity, 20);
            Assert.AreEqual(3, dict.Count);
            Assert.AreEqual(20, dict[comodity]);
        }

        [TestMethod]
        public void SaleTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var dict = Data.GetDictionaryFromWarehouse(warehouse);

            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");
            warehouse.Sale(comodity, 2);
            Assert.AreEqual(2, dict.Count);
            Assert.AreEqual(3, dict[comodity]);

            warehouse.Sale(comodity, 3);
            Assert.AreEqual(1, dict.Count);
            Assert.IsFalse(dict.ContainsKey(comodity));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaleExceptionTest1()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);
 
            warehouse.Sale(comodity, 1);           
        }

        [TestMethod]
        public void SaleExceptionMessageTest1()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = new Comodity("Ноутбук", "Huawei MateBook 15", 56990);

            try
            {
                warehouse.Sale(comodity, 1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Необходимого товара нет на складе", e.Message);
            }
            
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SaleExceptionTest2()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");

            warehouse.Sale(comodity, 10);
        }

        [TestMethod]
        public void SaleExceptionMessageTest2()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");

            try
            {
                warehouse.Sale(comodity, 1);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Необходимого количества нет на складе", e.Message);
            }

        }

        [TestMethod]
        public void CountTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);
            var comodity = priceList.Get("Ноутбук", "Apple MacBook Air");

            Assert.AreEqual(5, warehouse.Count(comodity));
        }

        [TestMethod]
        public void CountAllTest()
        {
            var priceList = new PriceList(Data.GetPriceRecords());
            var warehouse = new Warehouse(Data.GetQuantityRecords(), priceList);

            Assert.AreEqual(20, warehouse.CountAll());
        }

    }
}
