using System.Text.Json;
using Staris.Console.Integration.Helpers;
using Staris.Console.Integration.Models;
using Staris.Domain.Entities;
using Staris.Infra.Data;

namespace Staris.Console.Integration.Services;

public class PlanetsRelationshipsService : IService
{
    private readonly ApplicationDbContext _context;

    private readonly HttpClient _client;

    public PlanetsRelationshipsService(ApplicationDbContext context, HttpClient client)
    {
        _context = context;
        _client = client;
    }

    public async Task PopulateDatabase()
    {
        var planets = _context.Planets.ToList();

        foreach(var planet in planets)
        {
            var url = $"https://swapi.py4e.com/api/planets/{planet.Id}";
            var json = await _client.GetStreamAsync(url);

            var response = await JsonSerializer.DeserializeAsync<planetSTF>(json);

            if (response is not null)
            {
                foreach(string item in response.residents)
                {
                    var planetResident = new PlanetCharacter
                    {
                        PlanetId = planet.Id,
                        CharacterId = Util.ParseId(item)
                    };

                    _context.PlanetCharacters.Add(planetResident);
                }

                foreach(var item in response.films)
                {
                    PlanetFilm? planetFilm = new PlanetFilm { 
                        PlanetId = planet.Id,
                        FilmId = Util.ParseId(item) 
                    };
                    
                    _context.PlanetFilms.Add(planetFilm);
                }
            }
        }
    }
}