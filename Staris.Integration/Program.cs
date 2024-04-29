using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Staris.Application.Configurations;
using Staris.Application.Data;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;
using Staris.Infra.Repositories;
using Staris.Integration.Processed;

public class Program
{
    private static readonly string url = "https://swapi.py4e.com/api/";

    private readonly ICharacterRepository _characterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public Program(ICharacterRepository characterRepository, IUnitOfWork unitOfWork)
    {
        _characterRepository = characterRepository;
        _unitOfWork = unitOfWork;
    }

    private static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var program = serviceProvider.GetRequiredService<Program>();

        await program.RunAsync();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        IConfiguration configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile(@"appsettings.json", optional: false, reloadOnChange: true)
           .Build();

        services.AddScoped<ICharacterRepository, CharacterRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<Program>();
        services.AddSqlite<ApplicationDbContext>(configuration.GetConnectionString("StarisDB"), null, Opt => Opt.UseSqlite(connectionString: "StarisDB"));
        SQLitePCL.Batteries.Init();
    }

    private async Task RunAsync()
    {
        ProcessedBaseUrl processed = new ProcessedBaseUrl(_characterRepository, _unitOfWork);
        await processed.ProcessedBase(url);
    }

}