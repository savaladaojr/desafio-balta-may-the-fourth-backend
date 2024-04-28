using Application.Shared.Dtos.Film;
using MediatR;

namespace Staris.Application.UseCases.Films.Commands.Create;

public sealed record CharacterFilmCreateCommand(
    int CharacterId,
    int FilmId
) : IRequest<FilmDTO>;
