using Microsoft.EntityFrameworkCore;
using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class CharacterRepository : Repository<Character>, ICharacterRepository
	{
		public CharacterRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Character>> GetAllWithAllData()
		{
			var records = await Entity.AsNoTracking()
				.Include(i => i.HomeWorld).IgnoreAutoIncludes()
				.Include(i => i.Films).ThenInclude(ti => ti.Film).IgnoreAutoIncludes()
				.ToListAsync();
			return records;
		}

		public async Task<Character?> GetByIdWithAllData(int id)
		{
			var record = await Entity.AsNoTracking()
				.Include(i => i.HomeWorld).IgnoreAutoIncludes()
				.Include(i => i.Films).ThenInclude(ti => ti.Film).IgnoreAutoIncludes()
				.Where(i => i.Id == id)	
				.FirstOrDefaultAsync();

			return record;
		}
	}
}
