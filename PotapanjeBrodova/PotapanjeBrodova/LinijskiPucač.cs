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
            nizoviPoljaUNastavku = DajNizovePoljaUNastavku();
        }

        public Polje Gađaj()
        {
            // ako niz postoji samo na jednu stranu, gađamo njegovo prvo (najbliže) polje:
            if (nizoviPoljaUNastavku.Count == 1)
                return nizoviPoljaUNastavku[0].First();
            // inače, slučajnim odabirom:
            int indeks = izbornik.Next(2);
            gađanoPolje = nizoviPoljaUNastavku[indeks].First();
            // budući da tu stranu gađamo, maknut ćemo je iz liste za ubuduće:
            nizoviPoljaUNastavku.RemoveAt(indeks);
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

        private List<IEnumerable<Polje>> DajNizovePoljaUNastavku()
        {
            if (pogođenaPolja.First().Redak == pogođenaPolja.Last().Redak)
                return DajNizovePoljaLijevoDesno();
            return DajNizovePoljaGoreDolje();
        }

        private List<IEnumerable<Polje>> DajNizovePoljaLijevoDesno()
        {
            return DajNizovePoljaUNastavku(Smjer.Lijevo, Smjer.Desno);
        }

        private List<IEnumerable<Polje>> DajNizovePoljaGoreDolje()
        {
            return DajNizovePoljaUNastavku(Smjer.Gore, Smjer.Dolje);
        }

        private List<IEnumerable<Polje>> DajNizovePoljaUNastavku(Smjer odPrvogPolja, Smjer odZadnjegPolja)
        {
            List<IEnumerable<Polje>> nizovi = new List<IEnumerable<Polje>>();
            Polje prvoPolje = pogođenaPolja.First();
            var nizDoPrvogPolja = mreža.DajNizSlobodnihPolja(prvoPolje, odPrvogPolja);
            if (nizDoPrvogPolja.Count() > 0)
                nizovi.Add(nizDoPrvogPolja);
            Polje zadnjePolje = pogođenaPolja.Last();
            var nizDoZadnjegPolja = mreža.DajNizSlobodnihPolja(zadnjePolje, odZadnjegPolja);
            if (nizDoZadnjegPolja.Count() > 0)
                nizovi.Add(nizDoZadnjegPolja);
            return nizovi;
        }

        private Mreža mreža;
        private List<Polje> pogođenaPolja;
        private Polje gađanoPolje;
        private int duljinaBroda;
        List<IEnumerable<Polje>> nizoviPoljaUNastavku;
        private Random izbornik = new Random();
    }
}
