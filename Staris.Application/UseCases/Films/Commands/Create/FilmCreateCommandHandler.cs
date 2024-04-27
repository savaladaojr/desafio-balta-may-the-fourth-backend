using Application.Shared.Dtos.Film;
using AutoMapper;
using MediatR;
using Staris.Domain.Entities;
using Staris.Application.Data;
using Staris.Domain.Interfaces.Repositories;

namespace Staris.Application.UseCases.Films.Commands.Create;

internal class FilmCreateCommandHandler : IRequestHandler<FilmCreateCommand, FilmDTO>
{
    private readonly IMapper _mapper;
    private readonly IFilmRepository _FilmRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FilmCreateCommandHandler(IMapper mapper, IFilmRepository FilmRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _FilmRepository = FilmRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FilmDTO> Handle(FilmCreateCommand request, CancellationToken cancellationToken)
    {
        var Film = new Film()
        {
            Title = request.Title,
            Episode = request.Episode,
            OpeningCrawl = request.OpeningCrawl,
            Director = request.Director,
            Producer = request.Producer,
            ReleaseDate = request.ReleaseDate
        };

        var createFilm = _FilmRepository.Create(Film);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var FilmDTO = _mapper.Map<FilmDTO>(createFilm);

        return FilmDTO;
    }
}
