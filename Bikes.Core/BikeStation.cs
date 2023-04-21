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
    );