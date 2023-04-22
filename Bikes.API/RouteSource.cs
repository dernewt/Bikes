using Bikes.Core;
using Sylvan.Data.Csv;

namespace Bikes.API;

public class RouteSource
{
    public RouteSource(BikeSources source)
    {
        Source = source;
    }

    public BikeSources Source { get; }

    public Task<IEnumerable<BikeRoute>> GetRoutesAsync()
    {
        using var stationCsv = CsvDataReader.Create(Source.StationFiles[0]);
        var stations = stationCsv.GetStations()
            .ToDictionary(s => s.Id, s => s);

        using var routeCsv = CsvDataReader.Create(Source.TripFiles[0]);
        IEnumerable<BikeRoute> routes = routeCsv.GetRoutes(stations).Take(20).ToArray();

        return Task.FromResult(routes);
    }
}