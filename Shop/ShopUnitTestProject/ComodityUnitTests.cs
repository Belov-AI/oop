using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopLibrary;

namespace ShopUnitTestProject
{
    [TestClass]
    public class ComodityUnitTests
    {
        [TestMethod]
        public void ConstrutorTest()
        {
            var comodity = new Comodity("Телевизор", "Samsung UE55TU7097U", 39990);
            Assert.AreEqual("Телевизор", comodity.Category);
            Assert.AreEqual("Samsung UE55TU7097U", comodity.Name);
            Assert.AreEqual(39990, comodity.Price);
        }

        [TestMethod]
        public void ParseTest()
        {
            var comodity = Comodity.Parse("Телевизор\tSamsung UE55TU7097U\t39990");
            Assert.AreEqual("Телевизор", comodity.Category);
            Assert.AreEqual("Samsung UE55TU7097U", comodity.Name);
            Assert.AreEqual(39990, comodity.Price);
        }

        [TestMethod]
        public void ToStringTest()
        {
            var comodity = new Comodity("Телевизор", "Samsung UE55TU7097U", 39990);
            Assert.AreEqual("Телевизор\tSamsung UE55TU7097U\t39990", comodity.ToString());
        }
    }
}
