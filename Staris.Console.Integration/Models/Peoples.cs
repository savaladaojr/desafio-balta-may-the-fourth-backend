namespace Staris.Console.Integration.Models;

public record peopleResult(
	int count,
	string? next,
	string? previous,
	IEnumerable<peopleSTF> results
);

public record peopleSTF(string name,
	string height,
	string mass,
	string hair_color,
	string skin_color,
	string eye_color,
	string birth_year,
	string gender,
	string homeworld,
    //string species,
	string url,
	IEnumerable<string> films,
	IEnumerable<string> vehicles,
	IEnumerable<string> starships
);