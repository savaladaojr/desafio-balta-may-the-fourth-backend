namespace Staris.Console.Integration.Models;

public record filmsResult (
  int count,
  string? next,
  string? previus,
  IEnumerable<filmSTF> results
);

public record filmSTF(
  string title,
  int episode_id,
  string opening_crawl,
  string director,
  string producer,
  string release_date,
  IEnumerable<string> characters,
  IEnumerable<string> planets,
  IEnumerable<string> starships,
  IEnumerable<string> vehicles,
  string url
);
