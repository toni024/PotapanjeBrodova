using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class KružniPucač : IPucač
    {
        public KružniPucač(Mreža mreža, Polje pogođeno, int duljinaBroda)
        {
            this.mreža = mreža;
            this.prvoPogođenoPolje = pogođeno;
            this.duljinaBroda = duljinaBroda;
        }

        public Polje Gađaj()
        {
            List<Polje> kandidati = DajKandidate();
            return kandidati[izbornik.Next(kandidati.Count)];
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private List<Polje> DajKandidate()
        {
            List<Polje> kandidati = new List<Polje>();
            foreach (Smjer smjer in Enum.GetValues(typeof(Smjer)))
            {
                var niz = mreža.DajNizSlobodnihPolja(prvoPogođenoPolje, smjer);
                if (niz.Count() > 0)
                    kandidati.Add(niz.ElementAt(0));
            }
            Debug.Assert(kandidati.Count() > 0);
            return kandidati;
        }

        private Mreža mreža;
        private Polje prvoPogođenoPolje;
        private int duljinaBroda;
        private Random izbornik = new Random();
    }
}
