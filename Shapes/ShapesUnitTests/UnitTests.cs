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

            SetWidth(r, 7);
            Assert.AreEqual(35, r.Area, 1e-8);
        }

        [TestMethod]
        public void TestSquareArea()
        {
            var s = new Square(new Point(-1, 3), 8);

            Assert.AreEqual(64, s.Area, 1e-8);

            SetWidth(s, 5);
            Assert.AreEqual(25, s.Area, 1e-8);
        }

        [TestMethod]
        public void TestIsAreaCorrect()
        {
            var r = new Rectangle(new Point(1, 2), 4, 5);
            Assert.IsTrue(IsAreaCorrect(r));

            var s = new Square(new Point(-1, 3), 8);
            Assert.IsTrue(IsAreaCorrect(s));
        }

        [TestMethod]
        public void TestLineProperties()
        {
            var line = new Line(new Point(0, 1), new Point(1, 3));

            Assert.AreEqual(2, line.K, 1e-8);
            Assert.AreEqual(1, line.B, 1e-8);
        }

        [TestMethod]
        public void TestLineIsOn()
        {
            var line = new Line(new Point(0, 1), new Point(1, 3));

            Assert.IsTrue(line.IsOn(new Point(2, 5)));
            Assert.IsFalse(line.IsOn(new Point(2, 3)));
        }

        [TestMethod]
        public void TestLineSegmentLength()
        {
            var segment = new LineSegment(new Point(0, 1), new Point(1, 3));

            Assert.AreEqual(Math.Sqrt(5), segment.Length, 1e-8);
        }

        [TestMethod]
        public void TestLineSegmentIsOn()
        {
            var segment = new LineSegment(new Point(0, 1), new Point(1, 3));
            Assert.IsFalse(segment.IsOn(new Point(2, 5)));
            Assert.IsFalse(segment.IsOn(new Point(2, 3)));
            Assert.IsTrue(segment.IsOn(new Point(0.5, 2)));
        }

        [TestMethod]
        public void TestOyIntersection()
        {
            var line = new Line(new Point(1, 3), new Point(2, 5));
            Assert.IsTrue(IsOyIntersectionOn(line));
        }


        void SetWidth(Rectangle r, double newWidth)
        {
            r.Width = newWidth;
        }

        void SetWidth(Square s, double newWidth)
        {
            s.Side = newWidth;
        }

        bool IsAreaCorrect(Rectangle r)
        {
            r.Width = 3;
            r.Height = 4;
            return Math.Abs(r.Area - 12) < 1e-8;
        }

        bool IsAreaCorrect(Square s)
        {
            s.Side = 5;
            return Math.Abs(s.Area - 25) < 1e-8;
        }

        bool IsOyIntersectionOn(Line line)
        {
            return line.IsOn(new Point(0, line.B));
        }
    }


}
