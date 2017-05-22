using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class KružniPucač : Pucač, IPucač
    {
        public KružniPucač(Mreža mreža, Polje pogođeno, int duljinaBroda)
            : base(mreža, pogođeno, duljinaBroda)
        {
            nizoviPoljaUNastavku = DajNizovePoljaUNastavcima();
        }

        public override Polje Gađaj()
        {
            int indeks = izbornik.Next(nizoviPoljaUNastavku.Count);
            gađanoPolje = nizoviPoljaUNastavku[indeks].First();
            // uklanjamo odabrani smjer za eventualno sljedeće gađanje
            nizoviPoljaUNastavku.RemoveAt(indeks);
            return gađanoPolje;
        }

        private List<IEnumerable<Polje>> DajNizovePoljaUNastavcima()
        {
            Debug.Assert(PogođenaPolja.Count() == 1);
            List<IEnumerable<Polje>> kandidati = new List<IEnumerable<Polje>>();
            foreach (Smjer smjer in Enum.GetValues(typeof(Smjer)))
            {
                var niz = mreža.DajNizSlobodnihPolja(PogođenaPolja.ElementAt(0), smjer);
                if (niz.Count() > 0)
                    kandidati.Add(niz);
            }
            Debug.Assert(kandidati.Count() > 0);
            return kandidati;
        }

        private List<IEnumerable<Polje>> nizoviPoljaUNastavku;
    }
}
