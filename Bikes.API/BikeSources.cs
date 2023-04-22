namespace Bikes.API;

public record BikeSources(
    string[] TripFiles,
    string[] TripUrls,
    string[] StationFiles,
    string[] StationUrls
    )
{
    public BikeSources(IConfiguration config)
        :this(Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>(), Array.Empty<string>())
    {
        var section = config.GetRequiredSection(nameof(BikeSources));
        TripFiles = section.GetRequiredSection(nameof(TripFiles)).Get<string[]>()!;
        TripUrls = section.GetRequiredSection(nameof(TripUrls)).Get<string[]>()!;
        StationFiles = section.GetRequiredSection(nameof(StationFiles)).Get<string[]>()!;
        StationUrls = section.GetRequiredSection(nameof(StationUrls)).Get<string[]>()!;
    }
}