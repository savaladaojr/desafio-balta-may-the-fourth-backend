using Application.Shared.Dtos.Film;
using AutoMapper;
using MediatR;
using Staris.Domain.Entities;
using Staris.Application.Data;
using Staris.Domain.Interfaces.Repositories;
using Staris.Application.UseCases.Planets.Commands.CreateResidentLink;
using Application.Shared.Dtos;

namespace Staris.Application.UseCases.Films.Commands.Create;

internal class PlanetCharacterCreateCommandHandler : IRequestHandler<PlanetCharacterCreateCommand, PlanetDTO>
{
    private readonly IMapper _mapper;
	private readonly IPlanetCharacterRepository _planetCharacterRepository;
	private readonly IPlanetRepository _planetRepository;
	private readonly IUnitOfWork _unitOfWork;

    public PlanetCharacterCreateCommandHandler(IMapper mapper,
		IPlanetCharacterRepository planetCharacterRepository,
        IPlanetRepository planetRepository,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
		_planetCharacterRepository = planetCharacterRepository;
		_planetRepository = planetRepository;
		_unitOfWork = unitOfWork;
    }

    public async Task<PlanetDTO> Handle(PlanetCharacterCreateCommand request, CancellationToken cancellationToken)
    {
        var planetCharacter = new PlanetCharacter()
        {
            CharacterId = request.CharacterId,
            PlanetId = request.PlanetId
        };

        var createFilm = _planetCharacterRepository.Create(planetCharacter);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var planet = await _planetRepository.GetByIdWithDataAsync(planetCharacter.PlanetId);
		var planetDTO = _mapper.Map<PlanetDTO>(planet);

        return planetDTO;
    }

}
