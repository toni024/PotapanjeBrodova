using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonzolnoPotapanjeBrodova
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] duljineBrodova = { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Igra igra = new Igra(10, 10, duljineBrodova);
            Random r = new Random();
            Igrač početni = (Igrač)r.Next(2);
            switch (početni)
            {
                case Igrač.Osoba:
                    Console.WriteLine("Ti prvi gađaš. Unesi polje u obliku 'H-9', gdje je slovo stupac, a broj redak.");
                    break;
                case Igrač.Računalo:
                    Console.WriteLine("Ja prvi gađam.");
                    break;
            }
            Console.WriteLine();
            igra.Igraj(početni);

            Console.WriteLine("GOTOVO!!!");
            Console.ReadKey();
        }
    }
}
