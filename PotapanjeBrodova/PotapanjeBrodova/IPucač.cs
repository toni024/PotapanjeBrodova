using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public interface IPucač
    {
        Polje Gađaj();
        void ObradiGađanje(RezultatGađanja rezultat);
    }
}
