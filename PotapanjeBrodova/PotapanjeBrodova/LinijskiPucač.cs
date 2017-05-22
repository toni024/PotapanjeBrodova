using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class LinijskiPucač : Pucač, IPucač
    {
        public LinijskiPucač(Mreža mreža, IEnumerable<Polje> pogođena, int duljinaBroda)
            : base(mreža, pogođena, duljinaBroda)
        {
            if (pogođena.First().Redak == pogođena.Last().Redak)
                nizoviPoljaUNastavku = DajNizovePoljaLijevoDesno();
            else
                nizoviPoljaUNastavku = DajNizovePoljaGoreDolje();
        }

        public override Polje Gađaj()
        {
            // ako niz postoji samo na jednu stranu, gađamo njegovo prvo (najbliže) polje:
            if (nizoviPoljaUNastavku.Count == 1)
                gađanoPolje = nizoviPoljaUNastavku[0].First();
            // inače, slučajnim odabirom:
            else
            {
                int indeks = izbornik.Next(2);
                gađanoPolje = nizoviPoljaUNastavku[indeks].First();
                // budući da tu stranu gađamo, maknut ćemo je iz liste za ubuduće:
                nizoviPoljaUNastavku.RemoveAt(indeks);
            }
            return gađanoPolje;
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
            Polje prvoPolje = PogođenaPolja.First();
            var nizDoPrvogPolja = mreža.DajNizSlobodnihPolja(prvoPolje, odPrvogPolja);
            if (nizDoPrvogPolja.Count() > 0)
                nizovi.Add(nizDoPrvogPolja);
            Polje zadnjePolje = PogođenaPolja.Last();
            var nizDoZadnjegPolja = mreža.DajNizSlobodnihPolja(zadnjePolje, odZadnjegPolja);
            if (nizDoZadnjegPolja.Count() > 0)
                nizovi.Add(nizDoZadnjegPolja);
            return nizovi;
        }

        private List<IEnumerable<Polje>> nizoviPoljaUNastavku;
    }
}
