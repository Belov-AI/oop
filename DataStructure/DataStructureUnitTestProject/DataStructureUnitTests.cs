using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructure;

namespace DataStructureUnitTestProject
{
    [TestClass]
    public class DataStructureUnitTests
    {
        static Category a11 = new Category("A", MessageType.Incoming, MessageTopic.Subscribe);
        static Category a21 = new Category("A", MessageType.Outgoing, MessageTopic.Subscribe);
        static Category a12 = new Category("A", MessageType.Incoming, MessageTopic.Error);
        static Category b11 = new Category("B", MessageType.Incoming, MessageTopic.Subscribe);
        static Category a11Copy = new Category("A", MessageType.Incoming, MessageTopic.Subscribe);
        static Category[] a = new[] { a11, a12, a21, b11 };

        [TestMethod]
        public void ImplementFieldsCorrectly()
        {
            var fieldsInfo = typeof(Category).GetFields();
            Assert.AreEqual(3, fieldsInfo.Count());
            Assert.IsTrue(fieldsInfo.All(f => f.IsPublic && !f.IsStatic && f.IsInitOnly));
        }

        [TestMethod]
        public void ImplementEqualsCorrectly()
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    Assert.AreEqual(i == j, a[i].Equals(a[j]), $"Error on {i} {j}");
            Assert.IsTrue(a11.Equals(a11Copy));
        }

        [TestMethod]
        public void ImplementGetHashCodeCorrectly()
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    if (i != j)
                    {
                        Assert.AreNotEqual(a[i].GetHashCode(), a[j].GetHashCode(), $"Error on {i} {j}");
                    }

            Assert.IsTrue(a11.Equals(a11Copy));
        }

        [TestMethod]
        public void ImplementIComparableInterface()
        {
            Assert.IsTrue(a11 is IComparable);
        }

        [TestMethod]
        public void ImplementCompareToCorrectly()
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    Assert.AreEqual(Math.Sign(i.CompareTo(j)), Math.Sign(a[i].CompareTo(a[j])), $"Error on {i} {j}");
            Assert.AreEqual(0, a11.CompareTo(a11Copy));
        }

        [TestMethod]
        public void ImplementOperatorsCorrectly()
        {
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                {
                    Assert.AreEqual(i <= j, a[i] <= a[j], $"Error on <=, {i} {j}");
                    Assert.AreEqual(i >= j, a[i] >= a[j], $"Error on >=, {i} {j}");
                    Assert.AreEqual(i < j, a[i] < a[j], $"Error on <, {i} {j}");
                    Assert.AreEqual(i > j, a[i] > a[j], $"Error on >, {i} {j}");
                    Assert.AreEqual(i == j, a[i] == a[j], $"Error on ==, {i} {j}");
                    Assert.AreEqual(i != j, a[i] != a[j], $"Error on !=, {i} {j}");
                }
        }

        [TestMethod]
        public void ImplementToStringCorrectly()
        {
            Assert.AreEqual("A.Incoming.Subscribe", a11.ToString());
        }
    }
}
