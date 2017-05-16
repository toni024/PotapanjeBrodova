using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class SlučajniPucač : IPucač
    {
        public SlučajniPucač(Mreža mreža, int duljinaBroda)
        {
            this.mreža = mreža;
            this.duljinaBroda = duljinaBroda;
        }

        public Polje Gađaj()
        {
            var kandidati = DajKandidate();
            Debug.Assert(kandidati.Count > 0);
            gađanoPolje = kandidati[izbornik.Next(kandidati.Count)];
            return gađanoPolje;
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            switch (rezultat)
            {
                case RezultatGađanja.Promašaj:
                    return;
                case RezultatGađanja.Pogodak:
                    mreža.UkloniPolje(gađanoPolje);
                    return;
                case RezultatGađanja.Potopljen:
                    Debug.Assert(false, "Za sada nisu predviđeni brodovi duljine 1 pa SlučajniPucač ne bi smio potopiti brod.");
                    break;
                default:
                    Debug.Assert(false, $"Neočekivana vrijednost: {rezultat}.");
                    break;
            }
        }

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                return new Polje[] { gađanoPolje };
            }
        }

        private List<Polje> DajKandidate()
        {
            return mreža.DajNizoveSlobodnihPolja(duljinaBroda).SelectMany(niz => niz).ToList();
        }

        private Mreža mreža;
        private int duljinaBroda;
        private Polje gađanoPolje;
        private Random izbornik = new Random();
    }
}
