using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MMRPG;

namespace MMRPGUnitTestProject
{
    [TestClass]
    public class CharactersUnitTests
    {
        [TestMethod]
        public void HumanTest()
        {
            var hero = new CharacterCreator(new HumanFactory()).Create("Арагорн");
            Assert.IsInstanceOfType(hero, typeof(Human));
            Assert.AreEqual("Арагорн", hero.Name);
            Assert.AreEqual(40, hero.Health);
            Assert.AreEqual(30, hero.Strength);
            Assert.AreEqual(30, hero.Dexterity);
            Assert.IsInstanceOfType(hero.Armor, typeof(SteelArmor));
        }

        [TestMethod]
        public void DwarfTest()
        {
            var hero = new CharacterCreator(new DwarfFactory()).Create("Торин");
            Assert.IsInstanceOfType(hero, typeof(Dwarf));
            Assert.AreEqual("Торин", hero.Name);
            Assert.AreEqual(40, hero.Health);
            Assert.AreEqual(40, hero.Strength);
            Assert.AreEqual(20, hero.Dexterity);
            Assert.IsInstanceOfType(hero.Armor, typeof(ChainArmor));
        }

        [TestMethod]
        public void ElfTest()
        {
            var hero = new CharacterCreator(new ElfFactory()).Create("Элронд");
            Assert.IsInstanceOfType(hero, typeof(Elf));
            Assert.AreEqual("Элронд", hero.Name);
            Assert.AreEqual(20, hero.Health);
            Assert.AreEqual(30, hero.Strength);
            Assert.AreEqual(50, hero.Dexterity);
            Assert.IsInstanceOfType(hero.Armor, typeof(LeatherArmor));
        }

        [TestMethod]
        public void OrcTest()
        {
            var hero = new CharacterCreator(new OrcFactory()).Create("Шаграт");
            Assert.IsInstanceOfType(hero, typeof(Orc));
            Assert.AreEqual("Шаграт", hero.Name);
            Assert.AreEqual(50, hero.Health);
            Assert.AreEqual(40, hero.Strength);
            Assert.AreEqual(10, hero.Dexterity);
            Assert.IsInstanceOfType(hero.Armor, typeof(Clothes));
        }
    }
}
