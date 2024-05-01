using Microsoft.EntityFrameworkCore;
using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class FilmRepository : Repository<Film>, IFilmRepository
	{
		public FilmRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Film>> GetAllWithDataAsync()
		{
			var records = await Entity.AsNoTracking()
				.Include(i => i.Characters).ThenInclude(ti => ti.Character).IgnoreAutoIncludes()
				.Include(i => i.Planets).ThenInclude(ti => ti.Planet).IgnoreAutoIncludes()
				.Include(i => i.Starships).ThenInclude(ti => ti.Startship).ThenInclude(ti => ti.Vehicle).IgnoreAutoIncludes()
				.Include(i => i.Vehicles).ThenInclude(ti => ti.Vehicle).IgnoreAutoIncludes()

				.ToListAsync();

			return records;
		}

		public async Task<Film?> GetByIdWithDataAsync(int Id)
		{
			var record = await Entity.AsNoTracking()
				.Include(i => i.Characters).ThenInclude(ti => ti.Character).IgnoreAutoIncludes()
				.Include(i => i.Planets).ThenInclude(ti => ti.Planet).IgnoreAutoIncludes()
				.Include(i => i.Starships).ThenInclude(ti => ti.Startship).ThenInclude(ti => ti.Vehicle).IgnoreAutoIncludes()
				.Include(i => i.Vehicles).ThenInclude(ti => ti.Vehicle).IgnoreAutoIncludes()
				.Where(w => w.Id == Id)
				.FirstOrDefaultAsync();

			return record;
		}
	}
}
