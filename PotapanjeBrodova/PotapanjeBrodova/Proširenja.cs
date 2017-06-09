using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public static class Proširenja
    {
        public static IEnumerable<Polje> Sortiraj(this IEnumerable<Polje> polja)
        {
            if (polja == null || polja.Count() <= 1)
                return polja;
            Polje prvo = polja.First();
            bool uspravnoPoravnata = polja.Skip(1).All(p => p.Stupac == prvo.Stupac);
            bool vodoravnoPoravnata = polja.Skip(1).All(p => p.Redak == prvo.Redak);
            if (vodoravnoPoravnata == uspravnoPoravnata)
                throw new ArgumentException();
            return polja.OrderBy(p => p.Redak + p.Stupac);
        }

		public static IEnumerable<T> IzlučiNajčešće<T>(this IEnumerable<IEnumerable<T>> nizovi)
		{
			var jedinstveniNiz = nizovi.SelectMany(niz => niz);
			var grupiraniElementi = jedinstveniNiz.GroupBy(element => element);
			var grupeSKljučem = grupiraniElementi.Select(grupa => new { grupa.Key, Count = grupa.Count() });
			var sortiraneGrupe = grupeSKljučem.OrderByDescending(element => element.Count);
			int najčešće = sortiraneGrupe.First().Count;
			var najčešćiParovi = sortiraneGrupe.TakeWhile(elementi => elementi.Count == najčešće);
			return najčešćiParovi.Select(par => par.Key);
		}
	}
}
