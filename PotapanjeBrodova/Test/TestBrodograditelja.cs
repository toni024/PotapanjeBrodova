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
            Brodograditelj b = new Brodograditelj();
            Mreza mreza = new Mreza(10, 10);
            IEnumerable<int> duljineBrodova = new int[] { 5, 4, 4, 3, 3, 2, 2, 2, 2 };
            Flota f = b.SložiFlotu(mreza, duljineBrodova);
            Assert.AreEqual(duljineBrodova.Count(), f.BrojBrodova);

        }
    }
}