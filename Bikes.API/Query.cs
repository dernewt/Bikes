namespace Bikes.API;

using Bikes.Core;

public class Query
{
    //[UsePaging]
    public Task<IEnumerable<BikeRoute>> GetRoutes([Service] RouteSource rs)
        => rs.GetRoutesAsync();
}
