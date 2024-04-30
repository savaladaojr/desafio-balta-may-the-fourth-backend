
using System.Text.Json;
using Staris.Console.Integration.Helpers;
using Staris.Console.Integration.Models;
using Staris.Domain.Entities;
using Staris.Infra.Data;

namespace Staris.Console.Integration.Services;

public class PeopleRelationshipsService : IService
{
    private readonly ApplicationDbContext _context;

    private readonly HttpClient _client;

    public PeopleRelationshipsService(ApplicationDbContext context, HttpClient client)
    {
        _context = context;
        _client = client;
    }

    public async Task PopulateDatabase()
    {
        var characters = _context.Characters.ToList();

        foreach(var character in characters)
        {
            var url = $"https://swapi.py4e.com/api/people/{character.Id}";
            var json = await _client.GetStreamAsync(url);

            var response = await JsonSerializer.DeserializeAsync<peopleSTF>(json);

            if (response is not null)
            {
                foreach(string item in response.films)
                {
                    var characterFilm = new CharacterFilm
                    {
                        CharacterId = character.Id,
                        FilmId = Util.ParseId(item)
                    };

                    _context.CharacterFilms.Add(characterFilm);
                }
            }
        }
    }
}
