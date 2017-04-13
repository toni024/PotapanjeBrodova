using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Linq;

namespace Test
{
    [TestClass]
    public class TestMreza
    {
        [TestMethod]
        public void Mreza_DajSlobodnaPoljaVracaSvaPoljaZaPocetnuMrezu()
        {
            Mreza m = new Mreza(5, 5);
            Assert.AreEqual(25, m.DajSlobodnaPolja().Count());

        }
        [TestMethod]
        public void Mreza_DajSlobodnaPoljaVraca24PoljaZaMrezu5x5NakonJednogUklonjenogPoljaZadanimRedkomIStupcem()
        {
            Mreza m = new Mreza(5, 5);
            m.UkloniPolje(1, 1);
            Assert.AreEqual(24, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));

        }
        [TestMethod]
        public void Mreza_DajSlobodnaPoljaVraca23PoljaZaMrezu5x5NakonDvaUklonjenaPolja()
        {
            Mreza m = new Mreza(5, 5);
            m.UkloniPolje(1, 1);
            m.UkloniPolje(4, 4);
            Assert.AreEqual(23, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(4, 4)));
        }
        [TestMethod]
        public void Mreza_UkloniPoljeBacaIznimkuZaNepostojeciRedak()
        {

            try
            {
                Mreza m = new Mreza(5, 5);
                m.UkloniPolje(6, 1);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }
        [TestMethod]
        public void Mreza_UkloniPoljeBacaIznimkuZaNepostojeciStupac()
        {

            try
            {
                Mreza m = new Mreza(5, 5);
                m.UkloniPolje(1, 6);
                Assert.Fail();
            }
            catch (IndexOutOfRangeException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }
        [TestMethod]
        public void Mreza_DajSlobodnaPoljaVraca24PoljaZaMrezu5x5NakonJednogUklonjenogPolja()
        {
            Mreza m = new Mreza(5, 5);
            m.UkloniPolje(new Polje(1, 1));
            Assert.AreEqual(24, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));

        }
        [TestMethod]
        public void Mreza_DajNizovrPoljaVraca3UHorizontalnomRetkuDuljine5()
        {
            Mreza m = new Mreza(1, 5);
            Assert.AreEqual(3, m.DajNizoveSlobodnihPolja(3).Count());

        }
        [TestMethod]
        public void Mreza_DajNizovrPoljaVracaPrazanNizZaBrodDuljine5UHorizontalnomRetkuDuljine4()
        {
            Mreza m = new Mreza(1, 4);
            Assert.AreEqual(0, m.DajNizoveSlobodnihPolja(5).Count());

        }
        [TestMethod]
        public void Mreza_DajNizovrPoljaVraca3UVertikalnomStupcuDuljine5()
        {
            Mreza m = new Mreza(5, 1);
            Assert.AreEqual(3, m.DajNizoveSlobodnihPolja(3).Count());

        }
        [TestMethod]
        public void Mreza_DajNizovrPoljaVracaPrazanNizZaBrodDuljine5UVertikalnomStupcuDuljine4()
        {
            Mreza m = new Mreza(4, 1);
            Assert.AreEqual(0, m.DajNizoveSlobodnihPolja(5).Count());

        }

    }
}