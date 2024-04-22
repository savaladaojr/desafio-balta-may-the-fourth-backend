using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Domain.Entities
{
	public sealed class PlanetFilm
    {
        public int PlanetId { get; set; }
        public int FilmId { get; set; }


		//EF Relation
		public Planet? Planet{ get; init; }
		public Film? Film { get; init; }

	}
}
