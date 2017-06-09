using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
	public class SelektivniSlučajniPucač : SlučajniPucač
	{
		public SelektivniSlučajniPucač(Mreža mreža, int duljinaBroda) 
			: base(mreža, duljinaBroda)
		{
		}

		protected override List<Polje> DajKandidate()
		{
			IEnumerable<IEnumerable<Polje>> sviKandidati = mreža.DajNizoveSlobodnihPolja(duljinaBroda);
			return sviKandidati.IzlučiNajčešće().ToList();
		}
	}
}
