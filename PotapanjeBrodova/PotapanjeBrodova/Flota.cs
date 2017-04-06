using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotapanjeBrodova
{
    public class Flota
    {
        public void DodajBrod(IEnumerable<Polje> polja)
        {
            brodovi.Add(new Brod(polja));
        }

        public int BrojBrodova
        {
            get
            {
                return brodovi.Count;
            }
        }

        private List<Brod> brodovi = new List<Brod>();
    }
}
