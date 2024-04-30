namespace Staris.Console.Integration.Models;

public record planetResult(
    int count,
    string? next,
    string? previous,
    IEnumerable<planetSTF> results
);

public record planetSTF(string name,
    string rotation_period,
    string orbital_period,
    string diameter,
    string climate,
    string gravity,
    string terrain,
    string surface_water,
    string population,
    string url,
    IEnumerable<string> residents,
    IEnumerable<string> films
);