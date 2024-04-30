namespace Staris.Console.Integration.Models;

public record specieResult(
	int count,
	string? next,
	string? previous,
	IEnumerable<planetSTF> results
);

public record specieSTF(string average_height,
	string average_lifespan,
	string classification,
	string designation,
	string eye_colors,
	string hair_colors,
  string skin_colors,
	string homeworld,
	string language,
	string name,
	string url
);