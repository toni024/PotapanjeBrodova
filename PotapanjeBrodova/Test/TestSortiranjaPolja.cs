using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System;

namespace Test
{
    [TestClass]
    public class TestSortiranjaPolja
    {
        [TestMethod]
        public void SortirajPolja_SortiraNizHorizontalnihPoljaOdNajlijevijegPremaNajdesnijem()
        {
            Polje[] polja = new Polje[] { new Polje(2, 3), new Polje(2, 4), new Polje(2, 2) };
            IEnumerable<Polje> sortirana = polja.Sortiraj();
            Assert.AreEqual(new Polje(2, 2), sortirana.ElementAt(0));
            Assert.AreEqual(new Polje(2, 3), sortirana.ElementAt(1));
            Assert.AreEqual(new Polje(2, 4), sortirana.ElementAt(2));
        }

        [TestMethod]
        public void SortirajPolja_SortiraNizVertikalnihPoljaOdNajgornjegPremaNajdonjem()
        {
            Polje[] polja = new Polje[] { new Polje(4, 3), new Polje(5, 3), new Polje(3, 3) };
            IEnumerable<Polje> sortirana = polja.Sortiraj();
            Assert.AreEqual(new Polje(3, 3), sortirana.ElementAt(0));
            Assert.AreEqual(new Polje(4, 3), sortirana.ElementAt(1));
            Assert.AreEqual(new Polje(5, 3), sortirana.ElementAt(2));
        }

        [TestMethod]
        public void SortirajPolja_ZaProsljeđenuNulReferencuVraćaNulReferencu()
        {
            Polje[] polja = null;
            Assert.IsNull(polja.Sortiraj());
        }

        [TestMethod]
        public void SortirajPolja_ZaNizKojiSeSastojiOdJednogPoljaVraćaTajNiz()
        {
            Polje[] polja = new Polje[] { new Polje(2, 3) };
            Assert.AreEqual(1, polja.Sortiraj().Count());
            Assert.IsTrue(polja.Sortiraj().Contains(new Polje(2, 3)));
        }

        [TestMethod]
        public void SortirajPolja_BacaIznimkuTipaArgumentExceptionZaNizPoljaKojaNisuPoravnataHorizontalnoIliVertikalno()
        {
            try
            {
                Polje[] polja = new Polje[] { new Polje(4, 3), new Polje(5, 4) };
                polja.Sortiraj();
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
