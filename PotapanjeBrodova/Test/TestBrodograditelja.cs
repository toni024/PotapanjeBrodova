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
        public void Brodograditelj_SložiFlotuVračaFlotuSBrodovimaZadaneDuljine()
        {
            Brodograditelj b = new Brodograditelj();
            Mreža m = new Mreža(10, 10);
            IEnumerable<int> duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2 };
            Flota f = b.SložiFlotu(m, duljineBrodova);
            Assert.AreEqual(duljineBrodova.Count(), f.brojBrodova);

        }
    }
}