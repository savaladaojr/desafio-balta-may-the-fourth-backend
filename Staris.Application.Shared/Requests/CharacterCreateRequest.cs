using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staris.Application.Shared.Requests;

public sealed record CharacterCreateRequest(
    string Name,
    decimal BirthYear,
    string BirthYearPeriod,
    short Gender,
    string Mass,
    string Height,
    string EyeColor,
    string SkinColor,
    string HairColor,
    int HomeWorldId
);
