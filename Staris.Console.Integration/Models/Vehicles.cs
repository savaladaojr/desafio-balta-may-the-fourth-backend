namespace Staris.Console.Integration.Models;

public record vehiclesResult(
  int count,
  string? next,
  string? previous,
  IEnumerable<vehicleSTF> results
);

public record vehicleSTF(
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
  string vehicle_class,
  IEnumerable<string> pilots,
  IEnumerable<string> films,
  string url
);
