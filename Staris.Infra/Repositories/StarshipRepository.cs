using Microsoft.EntityFrameworkCore;
using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class StarshipRepository : Repository<Starship>, IStarshipRepository
	{
		public StarshipRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Starship>> GetAllWithDataAsync()
		{
			var starships = await Entity.Include(i => i.Vehicle).IgnoreAutoIncludes()
				.Include(i => i.Films).ThenInclude(ti => ti.Film).IgnoreAutoIncludes()
				.ToListAsync();

			return starships;
		}

		public async  Task<Starship?> GetByIdWithDataAsync(int id)
		{
			var starship = await Entity.Include(i => i.Vehicle).IgnoreAutoIncludes()
				.Include(i => i.Films).ThenInclude(ti => ti.Film) .IgnoreAutoIncludes()
				.Where(w => w.VehicleId == id)
				.FirstOrDefaultAsync();

			return starship;
		}
	}

}
