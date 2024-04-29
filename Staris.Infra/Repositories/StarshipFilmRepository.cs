using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class StarshipFilmRepository : Repository<StarshipFilm>, IStarshipFilmRepository
	{
		public StarshipFilmRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
