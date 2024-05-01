using Application.Shared.Dtos.Film;
using AutoMapper;
using MediatR;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Films.Queries.GetById;

public class FilmGetByIdQueryHandler : IRequestHandler<FilmGetByIdQuery, FilmDTO?>
{
    private readonly IFilmRepository _filmRepository;

    private IMapper _mapper;

    public FilmGetByIdQueryHandler(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }

    public async Task<FilmDTO?> Handle(
        FilmGetByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var result = await _filmRepository.GetByIdWithDataAsync(request.Id);

        if (result is null)
            return null;

        var finalResult = _mapper.Map<FilmDTO>(result);
        return finalResult;
    }
}
