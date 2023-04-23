namespace Bikes.API;

using Bikes.Core;

public class Query
{
    [UsePaging(MaxPageSize = 100)]
    [UseFiltering]
    public Task<IEnumerable<BikeRoute>> GetAllBikeRoutes([Service] BikeRouteSource rs)
        => rs.GetBikeRoutes();

    /*
     * public Connection<User> GetUsers(string? after, int? first, string sortBy)
    {
        // get users using the above arguments
        IEnumerable<User> users = null;

        var edges = users.Select(user => new Edge<User>(user, user.Id))
                            .ToList();
        var pageInfo = new ConnectionPageInfo(false, false, null, null);

        var connection = new Connection<User>(edges, pageInfo,
                            ct => ValueTask.FromResult(0));

        return connection;
     */
}
