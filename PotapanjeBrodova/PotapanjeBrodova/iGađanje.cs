using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public enum RezultatGađanja
    {
        Promašaj,
        Pogodak,
        Potopljen
    }

    public interface IGađani
    {
        RezultatGađanja Gađaj(Polje polje);
    }
}