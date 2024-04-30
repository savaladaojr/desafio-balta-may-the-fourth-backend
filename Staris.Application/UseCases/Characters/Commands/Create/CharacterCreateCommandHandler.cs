using AutoMapper;
using MediatR;
using Staris.Application.Data;
using Staris.Application.Shared.Dtos;
using Staris.Domain.Entities;
using Staris.Domain.Enumerables;
using Staris.Domain.Interfaces.Repositories;
using System.Reflection;

namespace Staris.Application.UseCases.Characters.Commands.Create;

internal class CharacterCreateCommandHandler : IRequestHandler<CharacterCreateCommand, CharacterDTO>
{
    private readonly IMapper _mapper;
    private readonly ICharacterRepository _CharacterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CharacterCreateCommandHandler(IMapper mapper, ICharacterRepository CharacterRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _CharacterRepository = CharacterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CharacterDTO> Handle(CharacterCreateCommand request, CancellationToken cancellationToken)
    {
        var Character = new Character()
        {
            Name = request.Name,
            BirthYear = request.BirthYear,
            BirthYearPeriod = request.BirthYearPeriod,
            Gender = request.Gender, //todo: validar
            Mass = request.Mass,
            Height = request.Height,
            EyeColor = request.EyeColor,
            SkinColor = request.SkinColor,
            HairColor = request.HairColor,
            HomeWorldId =request.HomeWorldId
        };

        var createCharacter = _CharacterRepository.Create(Character);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        //Reconsulta para retornar o planeta natal.
		createCharacter = await _CharacterRepository.GetByIdWithAllData(createCharacter.Id);

		var CharacterDTO = _mapper.Map<CharacterDTO>(createCharacter);

        return CharacterDTO;
    }
}
