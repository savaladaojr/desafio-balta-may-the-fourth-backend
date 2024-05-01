using System.Text.Json;
using Staris.Console.Integration.Helpers;
using Staris.Console.Integration.Models;
using Staris.Domain.Entities;
using Staris.Infra.Data;

namespace Staris.Console.Integration.Services;

public class PeopleService : IService
{
    private readonly ApplicationDbContext _context;

    private readonly HttpClient _client;

    public PeopleService(ApplicationDbContext context, HttpClient client)
    {
        _context = context;
        _client = client;
    }

    public async Task PopulateDatabase()
    {
        var people = new List<peopleSTF>();

        string? url = "https://swapi.py4e.com/api/people/?page=1";
        do
        {
            var json = await _client.GetStreamAsync(url);
            var response = await JsonSerializer.DeserializeAsync<peopleResult>(json);

            people.AddRange(response!.results);
            url = response.next;
        } while (url is not null);

        foreach (var item in people)
        {
            var homeWorldId = Util.ParseId(item.homeworld);
            var person = new Character()
            {
                Id = Util.ParseId(item.url),
                Name = item.name,
                Height = item.height,
                Mass = item.mass,
                HairColor = item.hair_color,
                SkinColor = item.skin_color,
                EyeColor = item.eye_color,
                BirthYear = item.birth_year,
                Gender = item.gender,
                HomeWorldId = homeWorldId is 0 ? null : homeWorldId
            };

            _context.Characters.Add(person);
        }
    }
}
