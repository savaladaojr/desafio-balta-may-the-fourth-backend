using AutoMapper;
using MediatR;
using Staris.Application.Shared.Dtos;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Starships.Queries.GetAll;

public class StarshipsGetAllQueryHandler
    : IRequestHandler<StarshipsGetAllQuery, IEnumerable<StarshipDTO>>
{
    private readonly IStarshipRepository _starshipRepository;
    private readonly IMapper _mapper;

    public StarshipsGetAllQueryHandler(IStarshipRepository starshipRepository, IMapper mapper)
    {
        _starshipRepository = starshipRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StarshipDTO>> Handle(
        StarshipsGetAllQuery request,
        CancellationToken cancellationToken
    )
    {
        var results = await _starshipRepository.GetAllWithDataAsync();
        var finalResults = _mapper.Map<IEnumerable<StarshipDTO>>(results);
        return finalResults;
    }
}
