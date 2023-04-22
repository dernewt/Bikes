using Bikes.Core;
using UnitsNet;

namespace Bikes.API
{
    public class RouteSource
    {
        public Task<IEnumerable<BikeRoute>> GetRoutesAsync()
        {
            IEnumerable<BikeRoute> routes = new List<BikeRoute>()
            {
                new BikeRoute(DateTime.Now, DateTime.Now, BikeStation.Unknown, BikeStation.Unknown, Length.FromMeters(10), TimeSpan.FromSeconds(22))
            };

            return Task.FromResult(routes);
        }
    }
}