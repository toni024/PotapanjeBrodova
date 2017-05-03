using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Flota : IGađani
    {
        public void dodajBrod(IEnumerable<Polje> polja)
        {
            brodovi.Add(new PotapanjeBrodova.Brod(polja));
        }

        public RezultatGađanja Gađaj(Polje polje)
        {
            foreach (Brod brod in brodovi)
            {
                var rezultat = brod.Gađaj(polje);

                if (rezultat != RezultatGađanja.Promašaj)
                    return rezultat;
            }
            return RezultatGađanja.Promašaj;
        }

        public int brojBrodova
        {
            get { return brodovi.Count; }
        }

        private List<Brod> brodovi = new List<Brod>();
    }
}