using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace Test
{
    [TestClass]
    public class TestTopništva
    {
        [TestMethod]
        public void Topništvo_NaPočetkuJeTaktikaNasumična()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_NasumičnaTaktikaNakonPromašajaOstajeNasumična()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Promašaj);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_NasumičnaTaktikaNakonPotapanjaOstajeNasumična()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Potopljen);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_NakonPrvogPogotkaTaktikaPrelaziUKružnu()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            Assert.AreEqual(TaktikaGađanja.Kružno, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_KružnoGađanjeNakonPromašajaOstajeKružno()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Promašaj);
            Assert.AreEqual(TaktikaGađanja.Kružno, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_KružnoGađanjeNakonPogotkaPrelaziULinijsko()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            Assert.AreEqual(TaktikaGađanja.Linijsko, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_KružnoGađanjeNakonPotonućaPrelaziUNasumično()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Potopljen);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_LinijskoGađanjeNakonPromašajaOstajeLinijsko()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Promašaj);
            Assert.AreEqual(TaktikaGađanja.Linijsko, t.TaktikaGađanja);
        }

        [TestMethod]
        public void Topništvo_LinijskoGađanjeNakonPotapanjaPostajeNasumično()
        {
            int redaka = 5;
            int stupaca = 5;
            int[] duljineBrodova = new int[] { 3, 2, 1 };
            Topništvo t = new Topništvo(redaka, stupaca, duljineBrodova);
            Polje prvo = t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            Polje drugo = t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            Polje treće = t.Gađaj();
            t.ObradiGađanje(RezultatGađanja.Potopljen);
            Assert.AreEqual(TaktikaGađanja.Nasumično, t.TaktikaGađanja);
        }
    }
}
