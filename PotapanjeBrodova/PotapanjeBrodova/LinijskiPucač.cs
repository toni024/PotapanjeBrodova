using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class LinijskiPucač : IPucač
    {
        public LinijskiPucač(Mreža mreža, IEnumerable<Polje> pogođena, int duljinaBroda)
        {
            this.mreža = mreža;
            this.pogođenaPolja = new List<Polje>(pogođena);
            this.duljinaBroda = duljinaBroda;
        }

        public Polje Gađaj()
        {
            var kandidati = DajKandidate();
            int indeks = izbornik.Next(kandidati.Count);
            gađanoPolje = kandidati[indeks];
            return gađanoPolje;
        }

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
            get
            {
                return pogođenaPolja;
            }
        }

        private List<Polje> DajKandidate()
        {
            if (pogođenaPolja.First().Redak == pogođenaPolja.Last().Redak)
                return DajHorizontalnaPolja();
            return DajVertikalnaPolja();
        }

        List<Polje> DajHorizontalnaPolja()
        {
            List<Polje> polja = new List<Polje>();
            Polje prvo = pogođenaPolja.First();
            Polje zadnje = pogođenaPolja.Last();
            var lijevaPolja = mreža.DajNizSlobodnihPolja(prvo, Smjer.Lijevo);
            if (lijevaPolja.Count() > 0)
                polja.Add(lijevaPolja.First());
            var desnaPolja = mreža.DajNizSlobodnihPolja(zadnje, Smjer.Desno);
            if (desnaPolja.Count() > 0)
                polja.Add(desnaPolja.First());
            return polja;
        }

        List<Polje> DajVertikalnaPolja()
        {
            List<Polje> polja = new List<Polje>();
            return polja;
        }

        private Mreža mreža;
        private List<Polje> pogođenaPolja;
        private Polje gađanoPolje;
        private int duljinaBroda;
        private Random izbornik = new Random();
    }
}
