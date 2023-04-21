using UnitsNet;

namespace Bikes.Core;

public record BikeRoute(
    DateTime Departure,
    DateTime Return,
    BikeStation From,
    BikeStation To,
    Length Distance,
    TimeSpan Duration
    )
{
    public bool IsTooShort() =>
        Distance.Meters < 10
        || Duration.TotalSeconds < 10;
}