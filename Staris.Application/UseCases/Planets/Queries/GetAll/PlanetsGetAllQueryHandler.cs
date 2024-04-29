using Application.Shared.Dtos;
using AutoMapper;
using MediatR;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Planets.Queries.GetAll;

public class PlanetsGetAllQueryHandler : IRequestHandler<PlanetsGetAllQuery, IEnumerable<PlanetDTO>>
{
    private readonly IPlanetRepository _planetRepository;
    private readonly IMapper _mapper;

    public PlanetsGetAllQueryHandler(IPlanetRepository planetRepository, IMapper mapper)
    {
        _planetRepository = planetRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PlanetDTO>> Handle(
        PlanetsGetAllQuery request,
        CancellationToken cancellationToken
    )
    {
        var results = await _planetRepository.GetAllWithDataAsync();
        var finalResults = _mapper.Map<IEnumerable<PlanetDTO>>(results);
        return finalResults;
    }
}
