using Application.Shared.Dtos.Film;
using MediatR;

namespace Staris.Application.UseCases.Films.Commands.Create;

public sealed record FilmCreateCommand(
    string Title,
    int Episode,
    string OpeningCrawl,
    string Director,
    string Producer,
    DateTime ReleaseDate
) : IRequest<FilmDTO>;
