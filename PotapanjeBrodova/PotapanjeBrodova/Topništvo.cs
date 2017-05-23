using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public enum TaktikaGađanja
    {
        Nasumično,
        Kružno,
        Linijsko
    }

    public class Topništvo
    {
        public Topništvo(int redaka, int stupaca, IEnumerable<int> duljineBrodova)
        {
            mreža = new Mreža(redaka, stupaca);
            this.duljineBrodova = new List<int>(duljineBrodova);
            TaktikaGađanja = TaktikaGađanja.Nasumično;
            pucač = new SlučajniPucač(mreža, duljineBrodova.First());
        }

        public Polje Gađaj()
        {
            return pucač.Gađaj();
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            pucač.ObradiGađanje(rezultat);
            switch (rezultat)
            {
                case RezultatGađanja.Promašaj:
                    return;
                case RezultatGađanja.Pogodak:
                    PromijeniTaktikuNakonPogotka();
                    return;
                case RezultatGađanja.Potopljen:
                    // potopljeni brod uklanjamo iz liste brodova koje gađamo
                    duljineBrodova.Remove(pucač.PogođenaPolja.Count());
                    PromijeniTaktikuUNasumično();
                    return;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        private void PromijeniTaktikuNakonPogotka()
        {
            switch (TaktikaGađanja)
            {
                case TaktikaGađanja.Nasumično:
                    PromijeniTaktikuUKružno();
                    return;
                case TaktikaGađanja.Kružno:
                    PromijeniTaktikuULinijsko();
                    return;
                case TaktikaGađanja.Linijsko:
                    return;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        private void PromijeniTaktikuUKružno()
        {
            TaktikaGađanja = TaktikaGađanja.Kružno;
            Polje pogođeno = pucač.PogođenaPolja.First();
            pucač = new KružniPucač(mreža, pogođeno, duljineBrodova.First());
        }

        private void PromijeniTaktikuULinijsko()
        {
            TaktikaGađanja = TaktikaGađanja.Linijsko;
            var pogođeno = pucač.PogođenaPolja;
            pucač = new LinijskiPucač(mreža, pogođeno, duljineBrodova.First());
        }

        private void PromijeniTaktikuUNasumično()
        {
            TaktikaGađanja = TaktikaGađanja.Nasumično;
            pucač = new SlučajniPucač(mreža, duljineBrodova.First());
        }

        public TaktikaGađanja TaktikaGađanja { get; private set; }

        private Mreža mreža;
        private List<int> duljineBrodova;
        private IPucač pucač;
    }
}
