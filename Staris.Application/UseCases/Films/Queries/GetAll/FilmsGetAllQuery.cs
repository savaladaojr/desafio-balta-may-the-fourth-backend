using Application.Shared.Dtos.Film;
using MediatR;

namespace Staris.Application.UseCases.Films.Queries.GetAll;

public class FilmsGetAllQuery : IRequest<IEnumerable<FilmDTO>>
{
    
}
