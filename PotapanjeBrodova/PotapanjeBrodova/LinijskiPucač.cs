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
            Debug.Assert(pogođena.Count() == 2);
        }

        public override Polje Gađaj()
        {
            List<IEnumerable<Polje>> nizoviPolja = DajNizovePoljaUNastavku();
            // ako niz postoji samo na jednu stranu, gađamo njegovo prvo (najbliže) polje:
            if (nizoviPolja.Count == 1)
                gađanoPolje = nizoviPolja[0].First();
            // inače, slučajnim odabirom:
            else
            {
                int indeks = izbornik.Next(2);
                gađanoPolje = nizoviPolja[indeks].First();
            }
            return gađanoPolje;
        }

        private List<IEnumerable<Polje>> DajNizovePoljaUNastavku()
        {
            if (PogođenaPolja.First().Redak == PogođenaPolja.Last().Redak)
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
    }
}
