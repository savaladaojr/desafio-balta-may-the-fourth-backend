using Microsoft.EntityFrameworkCore;
using Staris.Domain.Common;
using Staris.Domain.Entities;
using Staris.Domain.Enumerables;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;
using System.Linq;

namespace Staris.Infra.Repositories
{
	public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
	{
		public VehicleRepository(ApplicationDbContext context) : base(context)
		{

		}

		public override async Task<IEnumerable<Vehicle>> GetAllAsync()
		{
			var records = await Entity.AsNoTracking()
				.Include(i => i.Films).ThenInclude(ti => ti.Film).IgnoreAutoIncludes()
				.Where(w => w.Type == TypeOfVehicle.Vehicle).ToListAsync();
			return records;
		}

		public async Task<Vehicle?> GetByIdAsync(int id)
		{
			var record = await Entity.AsNoTracking()
				.Include(i => i.Films).ThenInclude(ti => ti.Film).IgnoreAutoIncludes()
				.Where(w => w.Type == TypeOfVehicle.Vehicle && w.Id == id).FirstOrDefaultAsync();

			return record;
		}

	}

}
