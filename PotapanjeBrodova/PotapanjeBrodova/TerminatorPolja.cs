using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotapanjeBrodova
{
    public class TerminatorPolja
    {
        public TerminatorPolja(Mreza mreza)
        {
            this.mreza = mreza;
        }

        public void UkloniPolja(IEnumerable<Polje> polja)
        {
            // ...
            // mreža.UkloniPolje(redak, s);
        }

        private Mreza mreza;
    }
}