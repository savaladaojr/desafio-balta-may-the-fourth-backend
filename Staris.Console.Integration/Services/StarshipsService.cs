using System.Text.Json;
using Staris.Console.Integration.Helpers;
using Staris.Console.Integration.Models;
using Staris.Domain.Entities;
using Staris.Infra.Data;

namespace Staris.Console.Integration.Services;

public class StarshipsService : IService
{
    private readonly ApplicationDbContext _context;

    private readonly HttpClient _client;

    public StarshipsService(ApplicationDbContext context, HttpClient client)
    {
        _context = context;
        _client = client;
    }

    public async Task PopulateDatabase()
    {
        var starships = new List<starshipSTF>();

        string? url = "https://swapi.py4e.com/api/starships/?page=1";
        do
        {
            var json = await _client.GetStreamAsync(url);
            var response = await JsonSerializer.DeserializeAsync<starshipsResult>(json);

            starships.AddRange(response!.results);
            url = response.next;
        } while (url is not null);

        foreach (var item in starships)
        {
            var splitedConsumables = item.consumables.Split(' ');
            var consumables = splitedConsumables.Length > 0 ? Util.TryParseInt(splitedConsumables[0]) : 0;
            var consumablePeriod = splitedConsumables.Length > 1 ? splitedConsumables[1] : null;

            var vehicle = new Vehicle()
            {
                Id = Util.ParseId(item.url),
                Name = item.name,
                Model = item.model,
                Manufacturer = item.manufacturer,
                Cost = Util.TryParseDecimal(item.cost_in_credits),
                Lenght = Util.TryParseDecimal(item.length),
                MaxSpeed = Util.TryParseDecimal(item.max_atmosphering_speed),
                Crew = item.crew,
                Passengers = Util.TryParseInt(item.passengers),
                CargoCapacity = Util.TryParseDecimal(item.cargo_capacity),
                Consumables = consumables,
                ConsumablesPeriod = consumablePeriod,
                Class = item.starship_class,
                Type = Domain.Enumerables.TypeOfVehicle.Starship
            };

            var starship = new Starship
            {
                HyperdriveRating = Util.TryParseDecimal(item.hyperdrive_rating),
                MaximumMegalights = Util.TryParseInt(item.MGLT),
                Vehicle = vehicle
            };

            _context.Starships.Add(starship);
        }
    }
}
