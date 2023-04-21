using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sylvan.Data.Csv;
using Bikes.Console;


using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(serviceCollection => serviceCollection.AddScoped<BikeSources>())
    .Build();

var data = host.Services.GetRequiredService<BikeSources>();

using var stationCsv = CsvDataReader.Create(data.StationFiles[0]);
var stations = stationCsv.GetStations()
    .ToDictionary(s=>s.Id, s=>s);

using var routeCsv = CsvDataReader.Create(data.TripFiles[0]);
var routes = routeCsv.GetRoutes(stations).ToArray();

return 0;