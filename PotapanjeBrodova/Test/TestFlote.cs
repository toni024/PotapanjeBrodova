using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace Test
{
    [TestClass]
    public class TestFlote
    {
        [TestMethod]
        public void Flota_DodajBrodPovećavaFlotuZaJedanBrod()
        {
            Flota flota = new Flota();
            Assert.AreEqual(0, flota.BrojBrodova);
            flota.DodajBrod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            Assert.AreEqual(1, flota.BrojBrodova);
        }

        [TestMethod]
        public void Flota_GađajVraćaPromašajZaPoljeKojeNePripadaNitiJednomBrodu()
        {
            Flota flota = new Flota();
            flota.DodajBrod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            flota.DodajBrod(new Polje[] { new Polje(5, 6), new Polje(6, 6) });
            Assert.AreEqual(RezultatGađanja.Promašaj, flota.Gađaj(new Polje(1, 6)));
        }

        [TestMethod]
        public void Flota_GađajVraćaPogodakZaPrvoPogođenoPoljeBroda()
        {
            Flota flota = new Flota();
            flota.DodajBrod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            flota.DodajBrod(new Polje[] { new Polje(5, 6), new Polje(6, 6) });
            Assert.AreEqual(RezultatGađanja.Pogodak, flota.Gađaj(new Polje(5, 6)));
        }

        [TestMethod]
        public void Flota_GađajVraćaPotopljenZaPrviPotopljeniBrod()
        {
            Flota flota = new Flota();
            flota.DodajBrod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            flota.DodajBrod(new Polje[] { new Polje(5, 6), new Polje(6, 6) });
            Assert.AreEqual(RezultatGađanja.Pogodak, flota.Gađaj(new Polje(5, 6)));
            Assert.AreEqual(RezultatGađanja.Potopljen, flota.Gađaj(new Polje(6, 6)));
        }
    }
}
