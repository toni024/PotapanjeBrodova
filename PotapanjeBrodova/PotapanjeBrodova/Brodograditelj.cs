using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Brodograditelj
    {
        public Flota SložiFlotu(Mreza mreza, IEnumerable<int> duljinebrodova)
        {
            Flota flota = new Flota();
            TerminatorPolja terminator = new TerminatorPolja(mreza);

            foreach (int i in duljinebrodova)
            {
                var nizovi = mreza.DajNizoveSlobodnihPolja(i);
                int indeks = slučajni.Next(nizovi.Count());
                nizovi.ElementAt(indeks);
                var niz = nizovi.ElementAt(indeks);
                flota.DodajBrod(niz);
                terminator.UkloniPolja(niz);
            }
            return flota;
        }
        //TODO obratiti pažnju na slučaj da se ne mogu svi brodovi složiti

        private Random slučajni = new Random();
    }
}