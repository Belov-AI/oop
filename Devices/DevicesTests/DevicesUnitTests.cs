using System;
using Devices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevicesTests
{
    [TestClass]
    public class DevicesUnitTests
    {
        [TestMethod]
        public void TestLamp()
        {
            var lamp = new Lamp();
            TestButtonManagedDevice(lamp);
        }

        [TestMethod]
        public void TestElectircMotor()
        {
            var motor = new ElectricMotor(2000);
            TestButtonManagedDevice(motor);
        }

        private static void TestButtonManagedDevice(ISwitchableDevice device)
        {
            Assert.IsFalse(device.IsActive);

            var button = new Button(device);
            button.Press();
            Assert.IsTrue(device.IsActive);
            button.Press();
            Assert.IsFalse(device.IsActive);
        }
    }
}
