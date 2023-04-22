using Bikes.Core;
using Sylvan.Data.Csv;

namespace Bikes.API;

public class BikeRouteSource : IDisposable
{
    private bool disposedValue;

    protected BikeSources Source { get; }
    protected Dictionary<uint, BikeStation> BikeStations { get; }
    protected CsvDataReader BikeRouteCsv { get; }
    public BikeRouteSource(BikeSources source)
    {
        Source = source;
        using var stationsCsv = CsvDataReader.Create(Source.StationFiles[0]);
        BikeStations = stationsCsv.GetStations().ToDictionary(s => s.Id, s => s);

        BikeRouteCsv = CsvDataReader.Create(Source.TripFiles[0]);
    }


    public IEnumerable<BikeStation> GetBikeStations()
    {
        return BikeStations.Values;
    }

    public Task<IEnumerable<BikeRoute>> GetBikeRoutes()
    {
        IEnumerable<BikeRoute> routes = BikeRouteCsv.GetRoutes(BikeStations);

        return Task.FromResult(routes);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                BikeRouteCsv.DisposeAsync();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}