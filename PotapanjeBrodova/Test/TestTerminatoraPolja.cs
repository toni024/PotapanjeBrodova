using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class TestTerminatoraPolja
    {
        private Mreža mreža;
        private TerminatorPolja terminator;

        [TestInitialize()]
        public void PripremiMrežuITerminatora()
        {
            mreža = new Mreža(10, 10);
            terminator = new TerminatorPolja(mreža);
        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUSrediniMreže()
        {
            IEnumerable<Polje> polja = new Polje[] { new Polje(3, 3), new Polje(3, 4) };
            terminator.UkloniPolja(polja);
            IEnumerable<Polje> slobodnaPolja = mreža.DajSlobodnaPolja();
            Assert.AreEqual(88, slobodnaPolja.Count());
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(3, 3)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(3, 4)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(2, 2)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(2, 5)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(4, 2)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(4, 5)));
        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUzGornjiRubMreže()
        {
            IEnumerable<Polje> polja = new Polje[] { new Polje(0, 3), new Polje(0, 4) };
            terminator.UkloniPolja(polja);
            IEnumerable<Polje> slobodnaPolja = mreža.DajSlobodnaPolja();
            Assert.AreEqual(92, slobodnaPolja.Count());
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(0, 3)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(0, 4)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(0, 2)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(0, 5)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(1, 2)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(1, 5)));
        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUGornjemLijevomKutuMreže()
        {
            IEnumerable<Polje> polja = new Polje[] { new Polje(0, 0), new Polje(0, 1) };
            terminator.UkloniPolja(polja);
            IEnumerable<Polje> slobodnaPolja = mreža.DajSlobodnaPolja();
            Assert.AreEqual(94, slobodnaPolja.Count());
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(0, 0)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(0, 1)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(0, 2)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(1, 0)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(1, 1)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(1, 2)));
        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUGornjemDesnomKutuMreže()
        {
            IEnumerable<Polje> polja = new Polje[] { new Polje(0, 9), new Polje(1, 9) };
            terminator.UkloniPolja(polja);
            IEnumerable<Polje> slobodnaPolja = mreža.DajSlobodnaPolja();
            Assert.AreEqual(94, slobodnaPolja.Count());
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(0, 9)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(1, 9)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(0, 8)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(1, 8)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(2, 8)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(2, 9)));
        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUDonjemDesnomKutuMreže()
        {
            IEnumerable<Polje> polja = new Polje[] { new Polje(9, 8), new Polje(9, 9) };
            terminator.UkloniPolja(polja);
            IEnumerable<Polje> slobodnaPolja = mreža.DajSlobodnaPolja();
            Assert.AreEqual(94, slobodnaPolja.Count());
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(9, 8)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(9, 9)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(9, 7)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(8, 7)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(8, 8)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(8, 9)));
        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUDonjemLijevomKutuMreže()
        {
            IEnumerable<Polje> polja = new Polje[] { new Polje(8, 0), new Polje(9, 0) };
            terminator.UkloniPolja(polja);
            IEnumerable<Polje> slobodnaPolja = mreža.DajSlobodnaPolja();
            Assert.AreEqual(94, slobodnaPolja.Count());
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(8, 0)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(9, 0)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(7, 0)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(7, 1)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(8, 1)));
            Assert.IsFalse(slobodnaPolja.Contains(new Polje(9, 1)));
        }
    }
}
