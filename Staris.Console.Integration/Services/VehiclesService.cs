using System.Text.Json;
using Staris.Console.Integration.Helpers;
using Staris.Console.Integration.Models;
using Staris.Domain.Entities;
using Staris.Infra.Data;

namespace Staris.Console.Integration.Services;

public class VehiclesService : IService
{
    private readonly ApplicationDbContext _context;

    private readonly HttpClient _client;

    public VehiclesService(ApplicationDbContext context, HttpClient client)
    {
        _context = context;
        _client = client;
    }

    public async Task PopulateDatabase()
    {
        var vehicles = new List<vehicleSTF>();

        string? url = "https://swapi.py4e.com/api/vehicles/?page=1";
        do
        {
            var json = await _client.GetStreamAsync(url);
            var response = await JsonSerializer.DeserializeAsync<vehiclesResult>(json);

            vehicles.AddRange(response!.results);
            url = response.next;
        } while (url is not null);

        foreach (var item in vehicles)
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
                Class = item.vehicle_class,
                Type = Domain.Enumerables.TypeOfVehicle.Vehicle
            };

            _context.Vehicles.Add(vehicle);
        }
    }
}
