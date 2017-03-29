using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotapanjeBrodova
{
    public class Mreza
    {
        private Polje[,] polje;
        private int redaka, stupaca;

        public Mreza(int redaka, int stupaca)
        {
            this.redaka = redaka;
            this.stupaca = stupaca;
            polje = new Polje[redaka, stupaca];
            for (int i = 0; i < redaka; ++i)
                for (int j = 0; j < stupaca; ++j)
                    polje[i, j] = new Polje(i, j);
        }
        public IEnumerable<Polje> DajSlobodnaPolja()
        {
            List<Polje> p = new List<Polje>();
            for (int i = 0; i < redaka; ++i)
            {
                for (int j = 0; j < stupaca; ++j)
                {
                    if (polje[i, j] != null)
                        p.Add(polje[i, j]);
                }
            }
            return p;
        }
        public void UkloniPolje(int redak, int stupac)
        {
            polje[redak, stupac] = null;
        }
        public void UkloniPolje(Polje p)
        {
            polje[p.Redak, p.Stupac] = null;
        }
        public IEnumerable<IEnumerable<Polje>> DajNizoveSlobodnihPolja(int duljina)
        {
            List<IEnumerable<Polje>> nizovi = new List<IEnumerable<Polje>>();
            foreach (IEnumerable<Polje> niz in DajSlobodnaPolja())
            {
                if (niz.Count() == duljina)
                    nizovi.Add(niz);
            }
            return nizovi;
        }

    }
}