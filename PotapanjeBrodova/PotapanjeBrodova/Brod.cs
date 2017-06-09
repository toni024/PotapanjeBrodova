using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Brod : IGađani
    {
        public Brod(IEnumerable<Polje> polja)
        {
            Polja = polja;
        }

        public RezultatGađanja Gađaj(Polje polje)
        {
            if (!Polja.Contains(polje))
                return RezultatGađanja.Promašaj;
            pogođenaPolja.Add(polje);
            if (pogođenaPolja.Count == Polja.Count())
                return RezultatGađanja.Potopljen;
            return RezultatGađanja.Pogodak;
        }

        private HashSet<Polje> pogođenaPolja = new HashSet<Polje>();

        public readonly IEnumerable<Polje> Polja;
    }
}
