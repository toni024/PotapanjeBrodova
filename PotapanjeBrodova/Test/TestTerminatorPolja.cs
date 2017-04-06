using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace Test
{
    [TestClass]
    public class TestTerminatoraPolja
    {
        private Mreza mreza;
        private TerminatorPolja terminator;

        [TestInitialize]
        public void PripremiMrežuITerminatora()
        {
            mreza = new Mreza(10, 10);
            terminator = new TerminatorPolja(mreza);
        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUSrediniMreže()
        {
            IEnumerable<Polje> polja = new Polje[] { new Polje(3, 3), new Polje(3, 4) };
            terminator.UkloniPolja(polja);
            Assert.AreEqual(88, mreza.DajSlobodnaPolja().Count());
        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUzGronjiRubMreže()
        {

        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUGornjemLijevomKutuMreže()
        {

        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUGornjemDesnomKutuMreže()
        {

        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUDonjemLijevomKutuMreže()
        {

        }

        [TestMethod]
        public void TerminatorPolja_UklanjaSvaPoljaOkoBrodaUDonjemDesnomKutuMreže()
        {

        }
    }
}