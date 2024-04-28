﻿using Newtonsoft.Json;
using Staris.Domain.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Integration.Processed;
public class ProcessedUrlFromTypes
{
    private static readonly HttpClient client = new HttpClient();
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
    private static async Task Details(string url, string name, int totalItens)
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
                    case nameof(EnumUrlCategories.people):
                        InsertCharacter(body);
                        break;
                    case nameof(EnumUrlCategories.planets):
                        //Plants(body);
                        break;
                    case nameof(EnumUrlCategories.species):
                        //Species(body);
                        break;
                    case nameof(EnumUrlCategories.vehicles):
                        //Vehicle(body);
                        break;
                    case nameof(EnumUrlCategories.starships):
                        //Starships(body);
                        break;
                    case nameof(EnumUrlCategories.films):
                        //Films(body);
                        break;
                    default:
                        Console.WriteLine($"Categoria desconhecida: {name}");
                        break;
                }

            }
        }


    }

    private static void InsertCharacter(dynamic character)
    {
        var charas = character;
        string name = character.name;
        string height = character.height;
        string mass = character.mass;
        string hairColor = character.hair_color;
        string skinColor = character.skin_color;
        string gender = character.gender;
        string[] parts = character.homeworld.ToString().Split('/');
        int planetId = Convert.ToInt32(parts[^2]);
        int homeworld = planetId;
        var teste = "";

    }
}