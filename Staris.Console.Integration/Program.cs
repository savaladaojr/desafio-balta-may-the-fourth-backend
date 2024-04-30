// See https://aka.ms/new-console-template for more information
using Staris.Domain.Entities;
using Staris.Infra.Data;
using Staris.Infra.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text.Json;
using static System.Net.WebRequestMethods;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
	//Application DB Context?
	//Referencia do SQLite 

	List<planetSTF> planets = new List<planetSTF>();

	string? url = "https://swapi.py4e.com/api/planets/?page=1";
	while (url != null)
	{
		var json = await client.GetStreamAsync(url);
		var WSAPIplanets = await JsonSerializer.DeserializeAsync<planetResult>(json);

		planets.AddRange(WSAPIplanets.results);
		url = WSAPIplanets.next;
	}

	foreach (var item in planets)
	{
		Planet planet = new Planet()
		{
			Id = int.Parse(item.url.Split('/')[item.url.Split('/').Length - 2].ToString()),
			Name = item.name,
			Climate = item.climate,
			Diameter = int.Parse(item.diameter),
			Gravity = decimal.Parse(item.gravity),
			OrbitalPeriod = int.Parse(item.orbital_period),
			RotationPeriod = int.Parse(item.rotation_period),
			SurfaceWater  = decimal.Parse(item.rotation_period),
			Terrain = item.terrain,
			Population = long.Parse(item.population)			
		};

		//Repositório para salvar?

	}



}