using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Linq;


namespace Test
{
    [TestClass]
    public class TestBroda
    {
        [TestMethod]
        public void Brod_SadržiPoljaZadanaKonstruktorom()
        {
            Brod brod = new Brod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            Assert.AreEqual(2, brod.Polja.Count());
            Assert.IsTrue(brod.Polja.Contains(new Polje(1, 1)));
            Assert.IsTrue(brod.Polja.Contains(new Polje(1, 2)));
        }

        [TestMethod]
        public void Brod_GađajVračaPromašajZaPoljeKojeNePripadaBrodu()
        {
            Brod brod = new Brod(new Polje[] { new Polje(1, 1), new Polje(1, 2) });
            RezultatGađanja rez = brod.Gađaj(new Polje(0, 0));
            Assert.AreEqual(RezultatGađanja.Promašaj, rez);

        }

        [TestMethod]
        public void Brod_GađajVračaPogodakZaPrvoPogođenoPolje()
        {
            Brod brod = new Brod(new Polje[] { new Polje(1, 1), new Polje(1, 2), new Polje(1, 3) });
            RezultatGađanja rez = brod.Gađaj(new Polje(1, 2));
            Assert.AreEqual(RezultatGađanja.Pogodak, rez);

        }

        [TestMethod]
        public void Brod_GađajVračaPogodakZaDrugoPogođenoPoljeBrodaOdTriPolja()
        {
            Brod brod = new Brod(new Polje[] { new Polje(1, 1), new Polje(1, 2), new Polje(1, 3) });
            brod.Gađaj(new Polje(1, 2));
            RezultatGađanja rez = brod.Gađaj(new Polje(1, 1));
            Assert.AreEqual(RezultatGađanja.Pogodak, rez);

        }

        [TestMethod]
        public void Brod_GađajVračaPogodakZaTrečePogođenoPoljeBrodaOdTriPolja()
        {
            Brod brod = new Brod(new Polje[] { new Polje(1, 1), new Polje(1, 2), new Polje(1, 3) });
            brod.Gađaj(new Polje(1, 2));
            brod.Gađaj(new Polje(1, 3));
            RezultatGađanja rez = brod.Gađaj(new Polje(1, 1));
            Assert.AreEqual(RezultatGađanja.Potopljen, rez);

        }

        [TestMethod]
        public void Brod_GađajVračaPogodakZaDrugoGađanjeIstogPolja()
        {
            Brod brod = new Brod(new Polje[] { new Polje(1, 1), new Polje(1, 2), new Polje(1, 3) });
            brod.Gađaj(new Polje(1, 2));
            RezultatGađanja rez = brod.Gađaj(new Polje(1, 2));
            Assert.AreEqual(RezultatGađanja.Pogodak, rez);

        }

        [TestMethod]
        public void Brod_GađajVračaPotopljenZaDrugoGađanjePotopljenogBroda()
        {
            Brod brod = new Brod(new Polje[] { new Polje(1, 1), new Polje(1, 2), new Polje(1, 3) });
            brod.Gađaj(new Polje(1, 2));
            brod.Gađaj(new Polje(1, 3));
            brod.Gađaj(new Polje(1, 1));
            RezultatGađanja rez = brod.Gađaj(new Polje(1, 1));
            Assert.AreEqual(RezultatGađanja.Potopljen, rez);

        }
    }
}