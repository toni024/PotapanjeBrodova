using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace Test
{
    [TestClass]
    public class TestPolja
    {
        [TestMethod]
        public void Polje_RedakIStupacJednakiSuArgumentimaKonstruktora()
        {
            Polje p = new Polje(2, 3);
            Assert.AreEqual(2, p.Redak);
            Assert.AreEqual(3, p.Stupac);
        }

        [TestMethod]
        public void Polje_ZaDvaPoljaKojaImajuIsteKoordinateMetodaEqualsVraćaTrue()
        {
            Polje p1 = new Polje(2, 3);
            Polje p2 = new Polje(2, 3);
            Assert.IsTrue(p1.Equals(p2));
        }

        [TestMethod]
        public void Polje_ZaDvaPoljaKojaNemajuIstiRedakMetodaEqualsVraćaFalse()
        {
            Polje p1 = new Polje(2, 3);
            Polje p2 = new Polje(1, 3);
            Assert.IsFalse(p1.Equals(p2));
        }

        [TestMethod]
        public void Polje_ZaDvaPoljaKojaNemajuIstiStupacMetodaEqualsVraćaFalse()
        {
            Polje p1 = new Polje(2, 3);
            Polje p2 = new Polje(2, 4);
            Assert.IsFalse(p1.Equals(p2));
        }
    }
}