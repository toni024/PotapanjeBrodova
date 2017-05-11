using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class LinijskiPucač : IPucač
    {
        Mreža mreža;
        IEnumerable<Polje> pogođenaPolja;
        int duljinaBroda;

        public LinijskiPucač(Mreža mreža, IEnumerable<Polje> pogođeno, int duljinaBroda)
        {
            this.mreža = mreža;
            this.pogođenaPolja = pogođeno;
            this.duljinaBroda = duljinaBroda; ;
        }

        public IEnumerable<Polje> PogođenaPolja
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Polje Gađaj()
        {
            throw new NotImplementedException();
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            throw new NotImplementedException();
        }
    }
}