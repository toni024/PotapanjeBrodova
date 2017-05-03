using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

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
            mreža = new PotapanjeBrodova.Mreža(redaka, stupaca);
            this.duljineBrodova = new List<int>(duljineBrodova);
            TaktikaGađanja = TaktikaGađanja.Nasumično;
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            if (rezultat == RezultatGađanja.Promašaj)
                return;

            if (rezultat == RezultatGađanja.Pogodak)
            {
                switch (TaktikaGađanja)
                {
                    case TaktikaGađanja.Nasumično:
                        PromjeniTaktikuUKružno();
                        return;
                    case TaktikaGađanja.Kružno:
                        PromjeniTaktikuULinijsko();
                        return;
                    case TaktikaGađanja.Linijsko:
                        return;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
            Debug.Assert(rezultat == RezultatGađanja.Potopljen);
            PromjeniTaktikuUNasumično();
        }

        private void PromjeniTaktikuUKružno()
        {
            TaktikaGađanja = TaktikaGađanja.Kružno;
        }

        private void PromjeniTaktikuULinijsko()
        {
            TaktikaGađanja = TaktikaGađanja.Linijsko;
        }

        private void PromjeniTaktikuUNasumično()
        {
            TaktikaGađanja = TaktikaGađanja.Nasumično;
        }

        public TaktikaGađanja TaktikaGađanja { get; private set; }

        private Mreža mreža;
        private List<int> duljineBrodova;

    }
}