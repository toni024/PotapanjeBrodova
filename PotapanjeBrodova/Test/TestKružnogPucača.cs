using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class TestKružnogPucača
    {
        [TestMethod]
        public void KružniPucač_GađajDajeJednoOdOkolnihPolja()
        {
            Mreža mreža = new Mreža(5, 5);
            KružniPucač puc = new KružniPucač(mreža, new Polje(2, 2), 3);
            Polje gađano = puc.Gađaj();
            List<Polje> kandidati = new List<Polje>{ new Polje(1, 2), new Polje(2, 1), new Polje(3, 2), new Polje(2, 3)};
            Assert.IsTrue(kandidati.Contains(gađano));
        }

        [TestMethod]
        public void KružniPucač_GađajDajeJednoOdPoljaDesnoIliLijevo()
        {
            Mreža mreža = new Mreža(1, 5);
            KružniPucač puc = new KružniPucač(mreža, new Polje(0, 2), 3);
            Polje gađano = puc.Gađaj();
            List<Polje> kandidati = new List<Polje> { new Polje(0, 1), new Polje(0, 3) };
            Assert.IsTrue(kandidati.Contains(gađano));
        }

        [TestMethod]
        public void KružniPucač_GađajDajeOkolnaPoljaKojaNisuEliminirana()
        {
            Mreža mreža = new Mreža(5, 5);
            mreža.UkloniPolje(1, 2);
            mreža.UkloniPolje(3, 2);
            KružniPucač puc = new KružniPucač(mreža, new Polje(2, 2), 3);
            Polje gađano = puc.Gađaj();
            List<Polje> kandidati = new List<Polje> { new Polje(2, 1), new Polje(2, 3) };
            Assert.IsTrue(kandidati.Contains(gađano));
        }

        [TestMethod]
        public void KružniPucač_GađajDajeJedinoOkolnoPoljeKojeNijeEliminirano()
        {
            Mreža mreža = new Mreža(5, 5);
            mreža.UkloniPolje(1, 2);
            mreža.UkloniPolje(3, 2);
            mreža.UkloniPolje(2, 1);
            KružniPucač puc = new KružniPucač(mreža, new Polje(2, 2), 3);
            Polje gađano = puc.Gađaj();
            Assert.AreEqual(new Polje(2, 3), gađano);
        }

        [TestMethod]
        public void KružniPucač_GađajDajePoljaDesnoIIspodZaPogođenoPoljeUGornjemLijevomKutu()
        {
            Mreža mreža = new Mreža(5, 5);
            KružniPucač puc = new KružniPucač(mreža, new Polje(0, 0), 3);
            Polje gađano = puc.Gađaj();
            List<Polje> kandidati = new List<Polje> { new Polje(0, 1), new Polje(1, 0) };
            Assert.IsTrue(kandidati.Contains(gađano));
        }

        [TestMethod]
        public void KružniPucač_GađajDajePoljaLijevoIIznadZaPogođenoPoljeUDonjemDesnomKutu()
        {
            Mreža mreža = new Mreža(5, 5);
            KružniPucač puc = new KružniPucač(mreža, new Polje(4, 4), 3);
            Polje gađano = puc.Gađaj();
            List<Polje> kandidati = new List<Polje> { new Polje(3, 4), new Polje(4, 3) };
            Assert.IsTrue(kandidati.Contains(gađano));
        }
    }
}
