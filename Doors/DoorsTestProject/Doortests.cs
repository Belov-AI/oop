using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doors;

namespace DoorsTestProject
{
    [TestClass]
    public class Doortests
    {
        [TestMethod]
        public void TestDoorLock()
        {
            var door = new Door();
            door.Unlock();
            door.Lock();
            Assert.IsFalse(door.IsOpen);
        }

        [TestMethod]
        public void TestDoorUnlock()
        {
            var door = new Door();
            door.Lock();
            door.Unlock();
            Assert.IsTrue(door.IsOpen);
        }

        [TestMethod]
        public void TestTimeOut()
        {
            var door = new TimedDoor(15);
            door.Unlock();
            door.TimeOut(1);
            Assert.IsFalse(door.IsOpen);
        }
    }
}
