using Staris.Domain.Common;
using Staris.Domain.Entities;

namespace Staris.Domain.Interfaces.Repositories
{
	public interface IPlanetRepository : IRepository<Planet>
	{

		Task<IEnumerable<Planet>> GetAllWithDataAsync();

		Task<Planet?> GetByIdWithDataAsync(int Id);
	}	

}
