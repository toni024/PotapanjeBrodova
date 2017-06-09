using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class TestMreže
    {
        [TestMethod]
        public void Mreža_DajSlobodnaPoljaVraćaSvaPoljaZaPočetnuMrežu()
        {
            Mreža m = new Mreža(5, 5);
            Assert.AreEqual(25, m.DajSlobodnaPolja().Count());
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaVraća24PoljaZaMrežu5x5NakonJednogUklonjenogPolja()
        {
            Mreža m = new Mreža(5, 5);
            m.UkloniPolje(new Polje(1, 1));
            Assert.AreEqual(24, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaVraća23PoljaZaMrežu5x5NakonDvaUklonjenaPolja()
        {
            Mreža m = new Mreža(5, 5);
            m.UkloniPolje(1, 1);
            m.UkloniPolje(4, 4);
            Assert.AreEqual(23, m.DajSlobodnaPolja().Count());
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(1, 1)));
            Assert.IsFalse(m.DajSlobodnaPolja().Contains(new Polje(4, 4)));
        }

        [TestMethod]
        public void Mreža_UkloniPoljeBacaIznimkuZaNepostojećiRedak()
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
        public void Mreža_UkloniPoljeBacaIznimkuZaNepostojećiStupac()
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
        public void Mreža_DajNizovePoljaVraća3NizaZaBrodDuljine3UHorizontalnomRetkuDuljine5()
        {
            Mreža m = new Mreža(1, 5);
            IEnumerable<IEnumerable<Polje>> nizoviPolja = m.DajNizoveSlobodnihPolja(3);
            Assert.AreEqual(3, nizoviPolja.Count());

            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(0, 0))).Count());
            Assert.AreEqual(2, nizoviPolja.Where(n => n.Contains(new Polje(0, 1))).Count());
            Assert.AreEqual(3, nizoviPolja.Where(n => n.Contains(new Polje(0, 2))).Count());
            Assert.AreEqual(2, nizoviPolja.Where(n => n.Contains(new Polje(0, 3))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(0, 4))).Count());
        }

        [TestMethod]
        public void Mreža_DajNizovePoljaVraćaPrazanNizZaBrodDuljine5UHorizontalnomRetkuDuljine4()
        {
            Mreža m = new Mreža(1, 4);
            Assert.AreEqual(0, m.DajNizoveSlobodnihPolja(5).Count());
        }

        [TestMethod]
        public void Mreža_DajNizovePoljaVraća3NizaZaBrodDuljine3UHorizontalnomRetkuDuljine8SEliminiranimPoljemUStupcu4()
        {
            Mreža m = new Mreža(1, 8);
            m.UkloniPolje(0, 4);
            IEnumerable<IEnumerable<Polje>> nizoviPolja = m.DajNizoveSlobodnihPolja(3);
            Assert.AreEqual(3, nizoviPolja.Count());

            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(0, 0))).Count());
            Assert.AreEqual(2, nizoviPolja.Where(n => n.Contains(new Polje(0, 1))).Count());
            Assert.AreEqual(2, nizoviPolja.Where(n => n.Contains(new Polje(0, 2))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(0, 3))).Count());

            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(0, 5))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(0, 6))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(0, 7))).Count());
        }

        [TestMethod]
        public void Mreža_DajNizovePoljaVraća3NizaZaBrodDuljine3UVertikalnomStupcuDuljine5()
        {
            Mreža m = new Mreža(5, 1);
            IEnumerable<IEnumerable<Polje>> nizoviPolja = m.DajNizoveSlobodnihPolja(3);
            Assert.AreEqual(3, nizoviPolja.Count());

            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(0, 0))).Count());
            Assert.AreEqual(2, nizoviPolja.Where(n => n.Contains(new Polje(1, 0))).Count());
            Assert.AreEqual(3, nizoviPolja.Where(n => n.Contains(new Polje(2, 0))).Count());
            Assert.AreEqual(2, nizoviPolja.Where(n => n.Contains(new Polje(3, 0))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(4, 0))).Count());
        }

        [TestMethod]
        public void Mreža_DajNizovePoljaVraćaPrazanNizZaBrodDuljine5UVertikalnomStupcuDuljine4()
        {
            Mreža m = new Mreža(4, 1);
            Assert.AreEqual(0, m.DajNizoveSlobodnihPolja(5).Count());
        }

        [TestMethod]
        public void Mreža_DajNizovePoljaVraća2NizaZaBrodDuljine4UVertikalnomStupcuDuljine9SEliminiranimPoljemURetku4()
        {
            Mreža m = new Mreža(9, 1);
            m.UkloniPolje(4, 0);
            IEnumerable<IEnumerable<Polje>> nizoviPolja = m.DajNizoveSlobodnihPolja(4);
            Assert.AreEqual(2, nizoviPolja.Count());

            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(0, 0))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(1, 0))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(2, 0))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(3, 0))).Count());

            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(5, 0))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(6, 0))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(7, 0))).Count());
            Assert.AreEqual(1, nizoviPolja.Where(n => n.Contains(new Polje(8, 0))).Count());
        }

        [TestMethod]
        public void Mreža_DajNizSlobodnihPoljaVraćaDvaPoljaDesno()
        {
            Mreža m = new Mreža(5, 5);
            var polja = m.DajNizSlobodnihPolja(new Polje(2, 2), Smjer.Desno);
            Assert.AreEqual(2, polja.Count());
            Assert.AreEqual(new Polje(2, 3), polja.First());
            Assert.AreEqual(new Polje(2, 4), polja.Last());
        }

        [TestMethod]
        public void Mreža_DajNizSlobodnihPoljaVraćaDvaPoljaDolje()
        {
            Mreža m = new Mreža(5, 5);
            var polja = m.DajNizSlobodnihPolja(new Polje(2, 2), Smjer.Dolje);
            Assert.AreEqual(2, polja.Count());
            Assert.AreEqual(new Polje(3, 2), polja.First());
            Assert.AreEqual(new Polje(4, 2), polja.Last());
        }

        [TestMethod]
        public void Mreža_DajNizSlobodnihPoljaVraćaDvaPoljaLijevo()
        {
            Mreža m = new Mreža(5, 5);
            var polja = m.DajNizSlobodnihPolja(new Polje(2, 2), Smjer.Lijevo);
            Assert.AreEqual(2, polja.Count());
            Assert.AreEqual(new Polje(2, 1), polja.First());
            Assert.AreEqual(new Polje(2, 0), polja.Last());
        }

        [TestMethod]
        public void Mreža_DajNizSlobodnihPoljaVraćaDvaPoljaGore()
        {
            Mreža m = new Mreža(5, 5);
            var polja = m.DajNizSlobodnihPolja(new Polje(2, 2), Smjer.Gore);
            Assert.AreEqual(2, polja.Count());
            Assert.AreEqual(new Polje(1, 2), polja.First());
            Assert.AreEqual(new Polje(0, 2), polja.Last());
        }
    }
}
