using MediatR;
using Staris.Application.Shared.Dtos;

namespace Staris.Application.UseCases.Starships.Queries.GetAll;

public class StarshipsGetAllQuery : IRequest<IEnumerable<StarshipDTO>>
{   
}
