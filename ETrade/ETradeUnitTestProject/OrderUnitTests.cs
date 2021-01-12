using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ETrade;

namespace ETradeUnitTestProject
{
    [TestClass]
    public class OrderUnitTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var comodity = new Comodity("Телевизор", "Samsung UE55TU7097U", 39990);
            var order = new Order(1, comodity, 15);
            Assert.AreEqual("Телевизор", order.Goods.Category);
            Assert.AreEqual("Samsung UE55TU7097U", order.Goods.Name);
            Assert.AreEqual(15, order.Quantity);
        }

        [TestMethod]
        public void OrderCreatorTest()
        {
            var creator = new OrderCreator();

            var order = creator.Create(1, "Телевизор\tSamsung UE55TU7097U\t39990\t15");
            Assert.AreEqual(1, order.ID);
            Assert.AreEqual("Телевизор", order.Goods.Category);
            Assert.AreEqual("Samsung UE55TU7097U", order.Goods.Name);
            Assert.AreEqual(15, order.Quantity);
        }
    }
}
