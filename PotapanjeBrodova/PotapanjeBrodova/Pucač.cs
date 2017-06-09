using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public abstract class Pucač : IPucač
    {
        protected Pucač(Mreža mreža, int duljinaBroda)
        {
            this.mreža = mreža;
            this.duljinaBroda = duljinaBroda;
        }

        protected Pucač(Mreža mreža, IEnumerable<Polje> pogođena, int duljinaBroda)
            : this(mreža, duljinaBroda)
        {
            pogođenaPolja.AddRange(pogođena);
        }

        protected Pucač(Mreža mreža, Polje pogođeno, int duljinaBroda)
            : this(mreža, duljinaBroda)
        {
            pogođenaPolja.Add(pogođeno);
        }

        public abstract Polje Gađaj();

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            mreža.UkloniPolje(gađanoPolje);
            switch (rezultat)
            {
                case RezultatGađanja.Promašaj:
                    return;
                case RezultatGađanja.Pogodak:
                    pogođenaPolja.Add(gađanoPolje);
                    return;
                case RezultatGađanja.Potopljen:
                    pogođenaPolja.Add(gađanoPolje);
                    TerminatorPolja terminator = new TerminatorPolja(mreža);
                    terminator.UkloniPolja(pogođenaPolja);
                    return;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        public IEnumerable<Polje> PogođenaPolja
        {
            get { return pogođenaPolja.Sortiraj(); }
        }

        protected readonly Mreža mreža;
        protected readonly int duljinaBroda;
        private readonly List<Polje> pogođenaPolja = new List<Polje>();
        protected readonly Random izbornik = new Random();
        protected Polje gađanoPolje;
    }
}
