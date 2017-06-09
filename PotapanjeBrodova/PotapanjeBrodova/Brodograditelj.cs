using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Brodograditelj
    {
        private const int brojPokušaja = 5;

        public Flota SložiFlotu(int redaka, int stupaca, IEnumerable<int> duljineBrodova)
        {
            for (int n = 0; n < brojPokušaja; ++n)
            {
                Mreža mreža = new Mreža(redaka, stupaca);
                Flota flota = SložiFlotu(mreža, duljineBrodova);
                if (flota != null)
                    return flota;
            }
            throw new ApplicationException("Ne može složiti flotu");
        }

        private Flota SložiFlotu(Mreža mreža, IEnumerable<int> duljineBrodova)
        {
            Flota flota = new Flota();
            TerminatorPolja terminator = new TerminatorPolja(mreža);
            foreach (int i in duljineBrodova)
            {
                var nizovi = mreža.DajNizoveSlobodnihPolja(i);
                if (nizovi.Count() == 0)
                    return null;
                int indeks = slučajni.Next(nizovi.Count());
                var niz = nizovi.ElementAt(indeks);
                flota.DodajBrod(niz);
                terminator.UkloniPolja(niz);
            }
            return flota;
        }

        private Random slučajni = new Random();
    }
}
