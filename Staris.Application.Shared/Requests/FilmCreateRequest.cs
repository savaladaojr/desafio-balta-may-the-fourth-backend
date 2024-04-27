using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Application.Shared.Requests;

public sealed record FilmCreateRequest(
    string Title,
    int Episode,
    string OpeningCrawl,
    string Director,
    string Producer,
    DateTime ReleaseDate
);
