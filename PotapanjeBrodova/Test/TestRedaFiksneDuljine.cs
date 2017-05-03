using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace Test
{
    [TestClass]
    public class TestRedaFiksneDuljine
    {
        [TestMethod]
        public void RedFiksneDuljine_DodavanjeJednog»lanaPoveÊavaDuljinuReda()
        {
            RedFiksneDuljine<Polje> r = new RedFiksneDuljine<Polje>(3);
            Assert.AreEqual(0, r.Count);
            r.Enqueue(new Polje(0, 0));
            Assert.AreEqual(1, r.Count);
        }

        [TestMethod]
        public void RedFiksneDuljine_Dodavanje»etvrtog»lanaNePoveÊavaRedDuljine3()
        {
            RedFiksneDuljine<Polje> r = new RedFiksneDuljine<Polje>(3);
            r.Enqueue(new Polje(0, 0));
            r.Enqueue(new Polje(1, 0));
            r.Enqueue(new Polje(2, 0));
            Assert.AreEqual(3, r.Count);
            r.Enqueue(new Polje(3, 0));
            Assert.AreEqual(3, r.Count);
        }

        [TestMethod]
        public void RedFiksneDuljine_Dodavanje»etvrtog»lanaIzbacujePrvi»lanIzRedaDuljine3()
        {
            RedFiksneDuljine<Polje> r = new RedFiksneDuljine<Polje>(3);
            r.Enqueue(new Polje(0, 0));
            r.Enqueue(new Polje(1, 0));
            r.Enqueue(new Polje(2, 0));
            Assert.IsTrue(r.Contains(new Polje(0, 0)));
            r.Enqueue(new Polje(3, 0));
            Assert.IsFalse(r.Contains(new Polje(0, 0)));
        }

        [TestMethod]
        public void RedFiksneDuljine_BrisanjeUklanjaSve»lanoveIzReda()
        {
            RedFiksneDuljine<Polje> r = new RedFiksneDuljine<Polje>(3);
            r.Enqueue(new Polje(0, 0));
            r.Enqueue(new Polje(1, 0));
            r.Enqueue(new Polje(2, 0));
            r.Clear();
            Assert.AreEqual(0, r.Count);
        }

    }
}