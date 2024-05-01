using System.Text.Json;
using Staris.Console.Integration.Helpers;
using Staris.Console.Integration.Models;
using Staris.Domain.Entities;
using Staris.Infra.Data;

namespace Staris.Console.Integration.Services;

public class FilmsRelationshipsService : IService
{
    private readonly ApplicationDbContext _context;

    private readonly HttpClient _client;

    public FilmsRelationshipsService(ApplicationDbContext context, HttpClient client)
    {
        _context = context;
        _client = client;
    }

    public async Task PopulateDatabase()
    {
        var films = _context.Films.ToList();

        foreach(var film in films)
        {
            var url = $"https://swapi.py4e.com/api/films/{film.Id}";
            var json = await _client.GetStreamAsync(url);

            var response = await JsonSerializer.DeserializeAsync<filmSTF>(json);

            if (response is not null)
            {
                foreach(string item in response.vehicles)
                {
                    var vehileFilm = new VehicleFilm
                    {
                        FilmId = film.Id,
                        VehicleId = Util.ParseId(item)
                    };

                    _context.VehicleFilms.Add(vehileFilm);
                }

                foreach(string item in response.starships)
                {
                    var starshipFilm = new StarshipFilm
                    {
                        FilmId = film.Id,
                        StartshipId = Util.ParseId(item)
                    };

                    _context.StarshipFilms.Add(starshipFilm);
                }
            }
        }
    }
}
