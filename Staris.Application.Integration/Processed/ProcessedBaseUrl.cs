using AutoMapper;
using Newtonsoft.Json;
using Staris.Application.Data;
using Staris.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Integration.Processed;
public class ProcessedBaseUrl
{
    private static readonly HttpClient client = new HttpClient();
    private readonly ICharacterRepository _characterRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProcessedBaseUrl(ICharacterRepository characterRepository, IUnitOfWork unitOfWork)
    {
        _characterRepository = characterRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task ProcessedBase(string baseUrl)
    {
        ProcessedUrlFromTypes type = new ProcessedUrlFromTypes(_characterRepository, _unitOfWork);
        while (!string.IsNullOrEmpty(baseUrl))
        {
            var jsonData = await FetchData(baseUrl);
            if (jsonData != null)
            {
                foreach (var url in jsonData)
                {
                    await type.ProcessedUrlFromType(url);
                }
                baseUrl = null;
            }
            else
            {
                Console.WriteLine("Falha ao recuperar dados.");
                break;
            }
        }
    }

    private static async Task<dynamic?> FetchData(string url)
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
}

