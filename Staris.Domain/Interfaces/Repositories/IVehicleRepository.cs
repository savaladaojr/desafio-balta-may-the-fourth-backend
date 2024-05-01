using Staris.Domain.Common;
using Staris.Domain.Entities;

namespace Staris.Domain.Interfaces.Repositories
{
	public interface IVehicleRepository : IRepository<Vehicle>
	{
		Task<Vehicle?> GetByIdAsync(int id);
	}
	

}
