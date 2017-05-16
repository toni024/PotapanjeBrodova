using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class TestBrodograditelja
    {
        [TestMethod]
        public void Brodograditelj_SložiFlotuVraćaFlotuSBrodovimaZadaneDuljine()
        {
            Brodograditelj brodograditelj = new Brodograditelj();
            int brojRedaka = 10;
            int brojStupaca = 10;
            IEnumerable<int> duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Flota f = brodograditelj.SložiFlotu(brojRedaka, brojStupaca, duljineBrodova);
            Assert.AreEqual(duljineBrodova.Count(), f.BrojBrodova);
            Assert.AreEqual(1, f.Brodovi.Count(brod => brod.Polja.Count() == 5));
            Assert.AreEqual(2, f.Brodovi.Count(brod => brod.Polja.Count() == 4));
            Assert.AreEqual(3, f.Brodovi.Count(brod => brod.Polja.Count() == 3));
            Assert.AreEqual(4, f.Brodovi.Count(brod => brod.Polja.Count() == 2));
        }
    }
}
