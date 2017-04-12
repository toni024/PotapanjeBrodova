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
            Mreža mreža = new Mreža(10, 10);
            IEnumerable<int> duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Flota f = b.SložiFlotu(mreža, duljineBrodova);
            Assert.AreEqual(duljineBrodova.Count(), f.BrojBrodova);
            // TODO: provjera ima li samo jedan brod duljine 5
            // TODO: provjera ima li dva broda duljine 4...
        }
    }
}
