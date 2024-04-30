using System.Text.Json;
using Staris.Console.Integration.Helpers;
using Staris.Console.Integration.Models;
using Staris.Domain.Entities;
using Staris.Infra.Data;

namespace Staris.Console.Integration.Services;

public class FilmsService : IService
{
    private readonly ApplicationDbContext _context;

    private readonly HttpClient _client;

    public FilmsService(ApplicationDbContext context, HttpClient client)
    {
        _context = context;
        _client = client;
    }

    public async Task PopulateDatabase()
    {
        var films = new List<filmSTF>();

        string? url = "https://swapi.py4e.com/api/films/?page=1";
        do
        {
            var json = await _client.GetStreamAsync(url);
            filmsResult? response = await JsonSerializer.DeserializeAsync<filmsResult>(json);

            films.AddRange(response!.results);
            url = response.next;
        } while (url is not null);

        foreach (var item in films)
        {
            var film = new Film()
            {
                Id = Util.ParseId(item.url),
                Title = item.title,
                Episode = item.episode_id,
                OpeningCrawl = item.opening_crawl,
                Director = item.director,
                Producer = item.producer,
                ReleaseDate = Util.TryParseDateTime(item.release_date),
            };

            _context.Films.Add(film);
        }
    }
}
