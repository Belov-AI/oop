using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapObjects;

namespace MapObjectsTests
{
    [TestClass]
    public class MapObjectsUnitTests
    {
        [TestMethod]
        public void TakeResources()
        {
            var player = new Player();
            Interaction.Make(player, new ResourcePile { Treasure = new Treasure { Amount = 10 } });
            Assert.AreEqual(false, player.Dead);
            Assert.AreEqual(10, player.Gold);
        }

        [TestMethod]
        public void BeatWeakCreepsAndCollectTreasure()
        {
            var player = new Player();
            Interaction.Make(player, new Creeps { Treasure = new Treasure { Amount = 10 }, Army = new Army { Power = 1 } });
            Assert.AreEqual(false, player.Dead);
            Assert.AreEqual(10, player.Gold);
        }

        [TestMethod]
        public void LoseToPowerfulCreeps()
        {
            var player = new Player();
            Interaction.Make(player, new Creeps { Treasure = new Treasure { Amount = 10 }, Army = new Army { Power = 10 } });
            Assert.AreEqual(true, player.Dead);
            Assert.AreEqual(0, player.Gold);
        }

        [TestMethod]
        public void OwnDwelling()
        {
            var player = new Player { Id = 1 };
            var dwelling = new Dwelling();
            Interaction.Make(player, dwelling);
            Assert.AreEqual(false, player.Dead);
            Assert.AreEqual(player.Id, dwelling.Owner);
            Assert.AreEqual(0, player.Gold);
        }

        [TestMethod]
        public void BeatWeakGuardAndOwnMine()
        {
            var player = new Player { Id = 1 };
            var mine = new Mine
            {
                Army = new Army { Power = 1 },
                Treasure = new Treasure { Amount = 2 },
            };
            Interaction.Make(player, mine);
            Assert.AreEqual(false, player.Dead);
            Assert.AreEqual(player.Id, mine.Owner);
            Assert.AreEqual(2, player.Gold);
        }

        [TestMethod]
        public void LoseToPowerfulGuard()
        {
            var player = new Player { Id = 1 };
            var mine = new Mine
            {
                Army = new Army { Power = 10 },
                Treasure = new Treasure { Amount = 2 },
            };
            Interaction.Make(player, mine);
            Assert.AreEqual(true, player.Dead);
            Assert.AreEqual(0, mine.Owner);
            Assert.AreEqual(0, player.Gold);
        }
    }
}
