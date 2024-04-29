using Staris.Domain.Common;
using Staris.Domain.Entities;

namespace Staris.Domain.Interfaces.Repositories
{
	public interface IStarshipRepository : IRepository<Starship>
	{

		Task<IEnumerable<Starship>> GetAllWithDataAsync();

		Task<Starship?> GetByIdWithDataAsync(int id);

	}
	

}
