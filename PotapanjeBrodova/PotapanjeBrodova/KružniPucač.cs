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
        }

        public override Polje Gađaj()
        {
            List<Polje> kandidati = DajKandidate();
            gađanoPolje = kandidati[izbornik.Next(kandidati.Count)];
            return gađanoPolje;
        }

        private List<Polje> DajKandidate()
        {
            Debug.Assert(PogođenaPolja.Count() == 1);
            List<Polje> kandidati = new List<Polje>();
            foreach (Smjer smjer in Enum.GetValues(typeof(Smjer)))
            {
                var niz = mreža.DajNizSlobodnihPolja(PogođenaPolja.ElementAt(0), smjer);
                if (niz.Count() > 0)
                    kandidati.Add(niz.ElementAt(0));
            }
            Debug.Assert(kandidati.Count() > 0);
            return kandidati;
        }
    }
}
