using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class PlanetRepository : Repository<Planet>, IPlanetRepository
	{
		public PlanetRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Planet>> GetAllWithDataAsync()
		{
			var records = await Entity.AsNoTracking()
							.Include(i => i.Residents).ThenInclude(ti => ti.Character).IgnoreAutoIncludes()
							.Include(i => i.Films).ThenInclude(ti => ti.Film).IgnoreAutoIncludes()
							.ToListAsync();
			return records;
		}

		public async Task<Planet?> GetByIdWithDataAsync(int Id)
		{
			var record = await Entity.AsNoTracking()
							.Include(i => i.Residents).ThenInclude(ti => ti.Character).IgnoreAutoIncludes()
							.Include(i => i.Films).ThenInclude(ti => ti.Film).IgnoreAutoIncludes()
							.Where(w => w.Id == Id)
							.FirstOrDefaultAsync();
			return record;
		}
	}

}
