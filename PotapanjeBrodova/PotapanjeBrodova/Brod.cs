using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotapanjeBrodova
{
    public class Brod
    {
        public Brod(IEnumerable<Polje> polja)
        {
            Polja = polja;
        }

        public readonly IEnumerable<Polje> Polja;
    }
}