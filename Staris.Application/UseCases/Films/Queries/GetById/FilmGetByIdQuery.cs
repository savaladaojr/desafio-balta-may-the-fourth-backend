using Application.Shared.Dtos.Film;
using MediatR;

namespace Staris.Application.UseCases.Films.Queries.GetById;

public class FilmGetByIdQuery : BaseGetByIdQuery, IRequest<FilmDTO>
{
}
