using Bikes.API;
using UnitsNet;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BikeRouteSource>();

builder.Services.AddSingleton<BikeSources>();

builder.Services.AddGraphQLServer()
    .AddType<UnsignedIntType>()
    .BindRuntimeType<Length, FloatType>()
    .AddTypeConverter<Length, double>(x => x.Meters)
    .AddTypeConverter<double, Length>(x => Length.FromMeters(x))
    .AddQueryType<Query>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();