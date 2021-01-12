using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMRPG;

namespace MMRPGUnitTestProject
{
    [TestClass]
    public class ArmorUnitTests
    {
        [TestMethod]
        public void ChainArmorTestMethod()
        {
            var chainArmor = new ChainArmor();
            Assert.AreEqual(20, chainArmor.Defense);
            Assert.AreEqual(40, chainArmor.Durability);
        }

        [TestMethod]
        public void ClothesTestMethod()
        {
            var clothes = new Clothes();
            Assert.AreEqual(5, clothes.Defense);
            Assert.AreEqual(10, clothes.Durability);
        }

        [TestMethod]
        public void LeatherArmorTestMethod()
        {
            var leatherArmor = new LeatherArmor();
            Assert.AreEqual(10, leatherArmor.Defense);
            Assert.AreEqual(15, leatherArmor.Durability);
        }

        [TestMethod]
        public void SteelArmor()
        {
            var steelArmor = new SteelArmor();
            Assert.AreEqual(40, steelArmor.Defense);
            Assert.AreEqual(25, steelArmor.Durability);
        }
    }
}
