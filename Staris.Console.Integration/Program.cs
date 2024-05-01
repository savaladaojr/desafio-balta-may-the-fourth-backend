// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Staris.Console.Integration.Services;
using Staris.Infra.Data;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    //Application DB Context?
    //Referencia do SQLite
    var path = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
    path = path.Replace("Staris.Console.Integration", "Staris.Web.Api");
    path = path.Substring(0, path.IndexOf("i\\") + 2);

    var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
    dbContextOptionsBuilder.UseSqlite($"DataSource={path}app.db");

    var context = new ApplicationDbContext(dbContextOptionsBuilder.Options);

    context.Database.EnsureDeleted();
    context.Database.Migrate();

    // populando os planetas
    var planetsService = new PlanetsService(context, client);
    await planetsService.PopulateDatabase();

    // populando os personagens
    var peopleService = new PeopleService(context, client);
    await peopleService.PopulateDatabase();

    // populando os filmes
    var filmsService = new FilmsService(context, client);
    await filmsService.PopulateDatabase();

    // populando os veiculos
    var vehiclesService = new VehiclesService(context, client);
    await vehiclesService.PopulateDatabase();

    // populando as naves estelares
    var starshipsService = new StarshipsService(context, client);
    await starshipsService.PopulateDatabase();

    await context.SaveChangesAsync(); 

    // Relacionamentos

    // planetas
    var planetsRelationshipsService = new PlanetsRelationshipsService(context, client);
    await planetsRelationshipsService.PopulateDatabase();

    // personagens
    var peopleRelationshipsService = new PeopleRelationshipsService(context, client);
    await peopleRelationshipsService.PopulateDatabase();

    // films
    var filmsRelationshipsService = new FilmsRelationshipsService(context, client);
    await filmsRelationshipsService.PopulateDatabase();

    await context.SaveChangesAsync(); 
}
