using Staris.Domain.Entities;

namespace Staris.Domain.Interfaces.Repositories
{
	public interface ICharacterRepository : IRepository<Character>
	{

		Task<IEnumerable<Character>> GetAllWithAllData();
		Task<Character?> GetByIdWithAllData(int id);
	}

}
