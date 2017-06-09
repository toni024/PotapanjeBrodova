using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PotapanjeBrodova;

namespace KonzolnoPotapanjeBrodova
{
    enum Igrač
    {
        Računalo,
        Osoba
    }

    class Igra
    {
        public Igra(int redaka, int stupaca, int[] duljineBrodova)
        {
            Brodograditelj brodograditelj = new Brodograditelj();
            flota = brodograditelj.SložiFlotu(redaka, stupaca, duljineBrodova);
            topništvo = new Topništvo(redaka, stupaca, duljineBrodova);
            brojRedaka = redaka;
            brojStupaca = stupaca;
            ukupanBrojBrodova = duljineBrodova.Length;
        }

        public void Igraj(Igrač početni)
        {
            Igrač trenutni = početni;
            int preostaloBrodovaRačunalu = ukupanBrojBrodova;
            int preostaloBrodovaOsobi = ukupanBrojBrodova;
            while (preostaloBrodovaRačunalu > 0 && preostaloBrodovaOsobi > 0)
            {
                if (trenutni == Igrač.Osoba)
                {
                    if (OsobaGađa() == RezultatGađanja.Potopljen)
                        --preostaloBrodovaOsobi;
                    trenutni = Igrač.Računalo;
                }
                else
                {
                    if (RačunaloGađa() == RezultatGađanja.Potopljen)
                        --preostaloBrodovaRačunalu;
                    trenutni = Igrač.Osoba;
                }
                Console.WriteLine();
            }
            if (preostaloBrodovaOsobi == 0)
                Console.WriteLine("Bravo majstore!");
            else
                Console.WriteLine("Žao mi je, bit ćeš bolji drugi puta!");
        }

        private RezultatGađanja OsobaGađa()
        {
            Polje polje = UčitajPoljeZaGađanje();
            RezultatGađanja rezultat = flota.Gađaj(polje);
            switch (rezultat)
            {
                case RezultatGađanja.Promašaj:
                    Console.WriteLine("Promašaj!");
                    break;
                case RezultatGađanja.Pogodak:
                    Console.WriteLine("Pogodak!");
                    break;
                case RezultatGađanja.Potopljen:
                    Console.WriteLine("Brod potopljen!");
                    break;
            }
            return rezultat;
        }

        private Polje UčitajPoljeZaGađanje()
        {
            while (true)
            {
                Console.Write("Ti gađaš polje: ");
                string unos = Console.ReadLine();
                string[] komponente = unos.Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (komponente.Length != 2)
                {
                    Console.WriteLine("Unesi polje u obliku 'H-9', gdje je slovo stupac, a broj redak.");
                    continue;
                }
                if (komponente[0].Length != 1)
                {
                    Console.WriteLine("Stupac je samo jedno slovo.");
                    continue;
                }
                int stupac = komponente[0].ToUpper()[0] - 'A';
                if (stupac < 0 || stupac >= brojStupaca)
                {
                    Console.WriteLine("Stupac može biti slovo samo između A i {0}.", (char)('A' + brojStupaca - 1));
                    continue;
                }
                int redak;
                if (!int.TryParse(komponente[1], out redak) || redak < 1 || redak > brojRedaka)
                {
                    Console.WriteLine("Redak može biti samo broj između 1 i {0}.", brojRedaka);
                    continue;
                }
                return new Polje(--redak, stupac);
            }
        }

        private RezultatGađanja RačunaloGađa()
        {
            Polje polje = topništvo.Gađaj();
            string stupac = ((char)('A' + polje.Stupac)).ToString();
            string redak = (polje.Redak + 1).ToString();
            Console.WriteLine("Ja gađam polje: {0}-{1}", stupac, redak);
            RezultatGađanja rezultat = UčitajRezultatGađanja();
            topništvo.ObradiGađanje(rezultat);
            return rezultat;
        }

        private RezultatGađanja UčitajRezultatGađanja()
        {
            Console.Write("(F)ulao, (P)ogodio ili (T)one?");
            while (true)
            {
                ConsoleKeyInfo unos = Console.ReadKey();
                Console.WriteLine();
                switch (unos.KeyChar)
                {
                    case 'f':
                    case 'F':
                        return RezultatGađanja.Promašaj;
                    case 'p':
                    case 'P':
                        return RezultatGađanja.Pogodak;
                    case 't':
                    case 'T':
                        return RezultatGađanja.Potopljen;
                    default:
                        Console.WriteLine("Krivi unos. Treba biti (F)ulao, (P)ogodio ili (T)one.");
                        break;
                }
            }
        }

        private Flota flota;
        private Topništvo topništvo;
        private readonly int ukupanBrojBrodova;
        private readonly int brojRedaka;
        private readonly int brojStupaca;
    }
}
