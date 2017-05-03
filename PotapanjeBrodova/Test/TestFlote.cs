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
            Assert.AreEqual(0, flota.brojBrodova);
            flota.dodajBrod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            Assert.AreEqual(1, flota.brojBrodova);
        }

        [TestMethod]
        public void Flota_GađajVračaPromašajZaPoljeKojeNePripadaNitiJednomBrodu()
        {
            Flota flota = new Flota();
            flota.dodajBrod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            flota.dodajBrod(new Polje[] { new Polje(5, 6), new Polje(6, 6) });
            Assert.AreEqual(RezultatGađanja.Promašaj, flota.Gađaj(new Polje(1, 6)));

        }

        [TestMethod]
        public void Flota_GađajVračaPogodakZaPrvoPogođenoPoljeBroda()
        {
            Flota flota = new Flota();
            flota.dodajBrod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            flota.dodajBrod(new Polje[] { new Polje(5, 6), new Polje(6, 6) });
            Assert.AreEqual(RezultatGađanja.Pogodak, flota.Gađaj(new Polje(5, 6)));
        }

        [TestMethod]
        public void Flota_GađajVračaPotopljenZaPrviPotopljeniBrod()
        {
            Flota flota = new Flota();
            flota.dodajBrod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            flota.dodajBrod(new Polje[] { new Polje(5, 6), new Polje(6, 6) });
            Assert.AreEqual(RezultatGađanja.Pogodak, flota.Gađaj(new Polje(5, 6)));
            Assert.AreEqual(RezultatGađanja.Potopljen, flota.Gađaj(new Polje(6, 6)));
        }

    }
}