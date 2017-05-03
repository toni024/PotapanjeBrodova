using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace Test
{
    [TestClass]
    public class TestMreža
    {
        [TestMethod]
        public void Mreža_DajSlobodnaPoljaVračaSvaPoljaZaPočetnuMrežu()
        {
            Mreža m = new Mreža(5, 5);
            Assert.AreEqual(25, m.DajSlobodnaPolja().Count());
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaVrača24PoljaZaMrežu5x5NakonJednogUkolnjenogPoljaZadanogRetkomIStupcem()
        {
            Mreža m = new Mreža(5, 5);
            m.UkloniPolje(1, 1);
            Assert.AreEqual(24, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaVrača23PoljaZaMrežu5x5NakonJednogUkolnjenogPolja()
        {
            Mreža m = new Mreža(5, 5);
            m.UkloniPolje(1, 1);
            m.UkloniPolje(4, 4);
            Assert.AreEqual(23, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(4, 4)));
        }

        [TestMethod]
        public void Mreža_UkloniPoljeBacaIznimkuZaNepostoječiRedak()
        {
            try
            {
                Mreža m = new Mreža(5, 5);
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
        public void Mreža_DajSlobodnaPoljaVrača24PoljaZaMrežu5x5NakonJednogUkolnjenogPolja()
        {
            Mreža m = new Mreža(5, 5);
            m.UkloniPolje(new Polje(1, 1));
            Assert.AreEqual(24, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
        }

        [TestMethod]
        public void Mreža_UkloniPoljeBacaIznimkuZaNepostoječiStupac()
        {
            try
            {
                Mreža m = new Mreža(5, 5);
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
        public void MrežaDajNizovePoljaVrača3NizaPoljaZaBrodDuljine3UHorizontalnomRetkuDuljine5()
        {
            Mreža m = new Mreža(1, 5);
            Assert.Equals(3, m.DajNizoveSlobodnihPolja(3).Count());
        }

        [TestMethod]
        public void MrežaDajNizovePoljaVračaVračaPrazanNizZaBrodDuljine5UHorizontalnomRetkuDuljine4()
        {
            Mreža m = new Mreža(1, 4);
            Assert.Equals(0, m.DajNizoveSlobodnihPolja(5).Count());
        }

        [TestMethod]
        public void MrežaDajNizovePoljaVrača3NizaPoljaZaBrodDuljine3UVertikalnomStupcuDuljine5()
        {
            Mreža m = new Mreža(5, 1);
            Assert.Equals(3, m.DajNizoveSlobodnihPolja(3).Count());
        }

        [TestMethod]
        public void MrežaDajNizovePoljaVračaVračaPrazanNizZaBrodDuljine5UVertikalnomStupcuDuljine4()
        {
            Mreža m = new Mreža(4, 1);
            Assert.Equals(0, m.DajNizoveSlobodnihPolja(5).Count());
        }

    }
}