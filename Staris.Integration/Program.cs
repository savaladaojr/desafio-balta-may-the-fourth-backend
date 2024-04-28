using Staris.Integration.Processed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Program
{
    private static readonly string url = "https://swapi.py4e.com/api/";
    private static async Task Main(string[] args)
    {
        ProcessedBaseUrl processed = new();
        await processed.ProcessedBase(url);
    }
}