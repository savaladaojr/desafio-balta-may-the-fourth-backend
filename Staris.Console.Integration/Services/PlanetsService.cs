using System.Text.Json;
using Staris.Console.Integration.Helpers;
using Staris.Console.Integration.Models;
using Staris.Domain.Entities;
using Staris.Infra.Data;

namespace Staris.Console.Integration.Services;

public class PlanetsService : IService
{
    private readonly ApplicationDbContext _context;

    private readonly HttpClient _client;

    public PlanetsService(ApplicationDbContext context, HttpClient client)
    {
        _context = context;
        _client = client;
    }

    public async Task PopulateDatabase()
    {
        var planets = new List<planetSTF>();

        string? url = "https://swapi.py4e.com/api/planets/?page=1";
        do
        {
            var json = await _client.GetStreamAsync(url);
            var response = await JsonSerializer.DeserializeAsync<planetResult>(json);

            planets.AddRange(response!.results);
            url = response.next;
        } while (url is not null);

        foreach (var item in planets)
        {
            var planet = new Planet()
            {
                Id = Util.ParseId(item.url),
                Name = item.name,
                Climate = item.climate,
                Diameter = Util.TryParseInt(item.diameter),
                Gravity = item.gravity,
                OrbitalPeriod = Util.TryParseInt(item.orbital_period),
                RotationPeriod = Util.TryParseInt(item.rotation_period),
                SurfaceWater = Util.TryParseDecimal(item.rotation_period),
                Terrain = item.terrain,
                Population = Util.TryParseLong(item.population)
            };

            _context.Planets.Add(planet);
        }
    }
}
