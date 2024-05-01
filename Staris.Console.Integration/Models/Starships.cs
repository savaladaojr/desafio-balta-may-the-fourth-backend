namespace Staris.Console.Integration.Models;

public record starshipsResult(
  int count,
  string? next,
  string? previous,
  IEnumerable<starshipSTF> results
);

public record starshipSTF (
  string name,
  string model,
  string manufacturer,
  string cost_in_credits,
  string length,
  string max_atmosphering_speed,
  string crew,
  string passengers,
  string cargo_capacity,
  string consumables,
  string starship_class,
  string hyperdrive_rating,
  string MGLT,
  IEnumerable<string> pilots,
  IEnumerable<string> films,
  string url
);