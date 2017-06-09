using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
	[TestClass]
	public class TestIzlučivanjaNajčešćih
	{
		[TestMethod]
		public void IzlučiNajčešćeVraćaSamoJedanNajčešćiInteger()
		{
			IEnumerable<int> a = new int[] { 1, 2, 3 };
			IEnumerable<int> b = new int[] {    2, 3, 4 };
			IEnumerable<int> c = new int[] {       3, 4, 5 };
			List<IEnumerable<int>> nizovi = new List<IEnumerable<int>>() { a, b, c };
			IEnumerable<int> najčešći = nizovi.IzlučiNajčešće();
			Assert.AreEqual(1, najčešći.Count());
			Assert.AreEqual(3, najčešći.First());
		}

		[TestMethod]
		public void IzlučiNajčešćeVraćaObaNajčešćaIntegera()
		{
			IEnumerable<int> a = new int[] { 1, 2, 3, 4 };
			IEnumerable<int> b = new int[] {    2, 3, 4, 5 };
			IEnumerable<int> c = new int[] {       3, 4, 5 };
			List<IEnumerable<int>> nizovi = new List<IEnumerable<int>>() { a, b, c };
			IEnumerable<int> najčešći = nizovi.IzlučiNajčešće();
			Assert.AreEqual(2, najčešći.Count());
			CollectionAssert.AreEquivalent(new int[] { 3, 4 }, najčešći.ToList());
		}
	}
}
