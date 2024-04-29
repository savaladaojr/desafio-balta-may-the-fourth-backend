using AutoMapper;
using MediatR;
using Staris.Application.Shared.Dtos;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Starships.Queries.GetById;

public class StarshipGetByIdQueryHandler : IRequestHandler<StarshipGetByIdQuery, StarshipDTO?>
{
    private readonly IStarshipRepository _starshipRepository;
    private readonly IMapper _mapper;

    public StarshipGetByIdQueryHandler(IStarshipRepository starshipRepository, IMapper mapper)
    {
        _starshipRepository = starshipRepository;
        _mapper = mapper;
    }

    public async Task<StarshipDTO?> Handle(
        StarshipGetByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var result = await _starshipRepository.GetByIdWithDataAsync(request.Id);
        if (result is null)
            return null;

        var finalResult = _mapper.Map<StarshipDTO>(result);
        return finalResult;
    }
}
