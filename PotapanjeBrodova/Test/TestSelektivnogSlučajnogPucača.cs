using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	[TestClass]
	public class TestSelektivnogSlučajnogPucača
	{
		[TestMethod]
		public void SelektivniSlučajniPucač_GađajVraćaJedinoPoljeKojeSePojavljujeNajvišePuta()
		{
			Mreža m = new Mreža(1, 5);
			SelektivniSlučajniPucač puc = new SelektivniSlučajniPucač(m, 3);
			Polje p = puc.Gađaj();
			Assert.AreEqual(new Polje(0, 2), p);
		}

		[TestMethod]
		public void SelektivniSlučajniPucač_GađajVraćaJednoOdPoljaKojaSePojavljujeNajvišePuta()
		{
			Mreža m = new Mreža(1, 6);
			SelektivniSlučajniPucač puc = new SelektivniSlučajniPucač(m, 3);
			HashSet<Polje> pogođenaPolja = new HashSet<Polje>();
			for (int i = 0; i < 10; ++i)
				pogođenaPolja.Add(puc.Gađaj());
			CollectionAssert.AreEquivalent(new Polje[] { new Polje(0, 2), new Polje(0, 3) }, pogođenaPolja.ToList());
		}
	}
}
