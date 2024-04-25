using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class VehicleFilmRepository : Repository<VehicleFilm>, IVehicleFilmRepository
	{
		public VehicleFilmRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
