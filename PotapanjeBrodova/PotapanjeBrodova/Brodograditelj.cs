using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Brodograditelj
    {
        public Flota SložiFlotu(Mreža mreža, IEnumerable<int> duljineBrodova)
        {
            Flota flota = new Flota();
            TerminatorPolja terminator = new TerminatorPolja(mreža);
            foreach (int i in duljineBrodova)
            {
                var nizovi = mreža.DajNizoveSlobodnihPolja(i);
                int indeks = slučajni.Next(nizovi.Count());
                var niz = nizovi.ElementAt(indeks);
                flota.DodajBrod(niz);
                terminator.UkloniPolja(niz);
            }
            return flota;
        }

        // TODO: obratiti pažnju na slučaj da se ne mogu svi brodovi složiti

        private Random slučajni = new Random();
    }
}
