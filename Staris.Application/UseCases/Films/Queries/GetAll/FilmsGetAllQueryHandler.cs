using Application.Shared.Dtos.Film;
using AutoMapper;
using MediatR;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Films.Queries.GetAll;

public class FilmsGetAllQueryHandler : IRequestHandler<FilmsGetAllQuery, IEnumerable<FilmDTO>>
{
    private readonly IFilmRepository _filmRepository;
    private readonly IMapper _mapper;

    public FilmsGetAllQueryHandler(IFilmRepository filmRepository, IMapper mapper)
    {
        _filmRepository = filmRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FilmDTO>> Handle(
        FilmsGetAllQuery request,
        CancellationToken cancellationToken
    )
    {
        var results = await _filmRepository.GetAllWithDataAsync();
        var finalResults = _mapper.Map<IEnumerable<FilmDTO>>(results);
        return finalResults;
    }
}
