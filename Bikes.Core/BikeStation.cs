namespace Bikes.Core;

public record BikeStation(
    uint Id,
    string Name,
    string Address,
    string City,
    string Operator,
    uint Capacity,
    string X, //ETRS-GK25
    string Y //ETRS-GK25
    )
{
    public static BikeStation Unknown {get;} = new BikeStation(0, "UNKNOWN", "UNKNOWN", "UNKNOWN", "UNKNOWN", 0, "", "");
}