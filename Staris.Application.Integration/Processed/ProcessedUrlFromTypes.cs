using Newtonsoft.Json;
using Staris.Domain.Enumerables;
using Staris.Domain.Entities;
using AutoMapper;
using Staris.Domain.Interfaces.Repositories;
using Staris.Application.Data;
using Staris.Infra.Repositories;

namespace Staris.Integration.Processed;
public class ProcessedUrlFromTypes
{
    private readonly IMapper _mapper;
    private readonly ICharacterRepository _CharacterRepository;
    private readonly IUnitOfWork _unitOfWork;

    private static readonly HttpClient client = new HttpClient();

    public ProcessedUrlFromTypes(ICharacterRepository characterRepository, IUnitOfWork unitOfWork)
    {
        _CharacterRepository = characterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ProcessedUrlFromType(dynamic obj)
    {
        while (obj != null)
        {
            string url = obj.Value;
            if (url != null)
            {
                var results = await Find(url);
                if (results != null)
                {
                    int totalItens = results?.count ?? 0;
                    string name = obj.Name;

                    await Details(url, name, totalItens);
                }
                else
                {
                    Console.WriteLine("Falha ao recuperar dados.");
                    break;
                }
            }
        }
    }

    private static async Task<dynamic?> Find(string url)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<dynamic>(responseBody);
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar {url}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Separa pelo tipo de item que será processado
    /// </summary>
    /// <param name="url"></param>
    /// <param name="name"></param>
    /// <param name="totalItens"></param>
    /// <returns></returns>
    private async Task Details(string url, string name, int totalItens)
    {
        for (int i = 1; i <= totalItens; i++)
        {
            string urlItem = String.Format("{0}{1}/", url, i);
            HttpResponseMessage response = await client.GetAsync(urlItem);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var body = JsonConvert.DeserializeObject<dynamic>(responseBody);
                switch (name)
                {
                    case nameof(enumTypeOfCategories.people):
                        InsertCharacter(body);
                        break;
                    case nameof(enumTypeOfCategories.planets):
                        //Plants(body);
                        break;
                    case nameof(enumTypeOfCategories.species):
                        //Species(body);
                        break;
                    case nameof(enumTypeOfCategories.vehicles):
                        //Vehicle(body);
                        break;
                    case nameof(enumTypeOfCategories.starships):
                        //Starships(body);
                        break;
                    case nameof(enumTypeOfCategories.films):
                        //Films(body);
                        break;
                    default:
                        Console.WriteLine($"Categoria desconhecida: {name}");
                        break;
                }

            }
        }
    }

    private async void InsertCharacter(dynamic character)
    {
        try
        {
            string[] parts = character.homeworld.ToString().Split('/');
            int planetId = Convert.ToInt32(parts[^2]);

            string birth = character.birth_year;
            dynamic birthYearPeriod = new string(birth.Where(char.IsLetter).ToArray());
            dynamic birthYear = Convert.ToDecimal(new string(birth.Where(char.IsDigit).ToArray()));

            Character newCharacter = new Character()
            {
                Name = character.name,
                BirthYear = birthYear,
                BirthYearPeriod = birthYearPeriod,
                Gender = (Domain.Enumerables.TypeOfGender)character.gender,
                Mass = character.mass,
                Height = character.height,
                EyeColor = character.eye_color,
                SkinColor = character.skin_color,
                HairColor = character.hair_color,
                HomeWorldId = planetId
            };

            var createCharacter = _CharacterRepository.Create(newCharacter);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Erro ao tentar personagem: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao tentar salvar personagem: {ex.Message}");
        }
    }
}
