using Application.Shared.Dtos;
using AutoMapper;
using MediatR;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Planets.Queries.GetById;

public class PlanetGetAllQueryHandler : IRequestHandler<PlanetGetByIdQuery, PlanetDTO?>
{
    private readonly IPlanetRepository _planetRepository;
    private readonly IMapper _mapper;

    public PlanetGetAllQueryHandler(IPlanetRepository planetRepository, IMapper mapper)
    {
        _planetRepository = planetRepository;
        _mapper = mapper;
    }

    public async Task<PlanetDTO?> Handle(
        PlanetGetByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var result = await _planetRepository.GetByIdWithDataAsync(request.Id);

        if (result is null)
            return null;

        var finalResult = _mapper.Map<PlanetDTO>(result);
        return finalResult;
    }
}
