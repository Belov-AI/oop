using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesUnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestTriangleArea()
        {
            var t = new Triangle(new Point(2, 1), new Point(6, 3), new Point(4, 5));

            Assert.AreEqual(6, t.Area, 1e-8);
        }

        [TestMethod]
        public void TestRectangleArea()
        {
            var r = new Rectangle(new Point(1, 2), 4, 5);

            Assert.AreEqual(20, r.Area, 1e-8);
        }

        [TestMethod]
        public void TestSquareArea()
        {
            var s = new Square(new Point(-1, 3), 8);

            Assert.AreEqual(64, s.Area, 1e-8);
        }
    }


}
