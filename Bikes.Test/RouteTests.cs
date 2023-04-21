namespace Bikes.Test;

public class RouteTests
{
    public BikeRoute GoodRoute => new BikeRoute(default, default, BikeStation.Unknown, BikeStation.Unknown, Length.FromMeters(99), TimeSpan.FromSeconds(99));

    [Fact]
    public void IsGoodRouteGood() => GoodRoute
        .Should().Match<BikeRoute>(r => !r.IsTooShort());

    [Fact]
    public void Is9MeterTooShort() => (GoodRoute with { Distance = Length.FromMeters(9) })
        .Should().Match<BikeRoute>(r => r.IsTooShort());

    [Fact]
    public void Is10MeterLongEnough() => (GoodRoute with { Distance = Length.FromMeters(10) })
        .Should().Match<BikeRoute>(r => !r.IsTooShort());

    [Fact]
    public void Is9SecondsTooShort() => (GoodRoute with { Duration = TimeSpan.FromSeconds(9) })
        .Should().Match<BikeRoute>(r => r.IsTooShort());

    [Fact]
    public void Is10SecondsLongEnough() => (GoodRoute with { Duration = TimeSpan.FromSeconds(10) })
        .Should().Match<BikeRoute>(r => !r.IsTooShort());

}
