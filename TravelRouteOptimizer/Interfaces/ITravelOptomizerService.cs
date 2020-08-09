using System;
using System.Collections.Generic;
using System.Text;
using TravelRouteOptimizer.Models;

namespace TravelRouteOptimizer.Interfaces
{
    public interface ITravelOptomizerService
    {
        BestRoutePath GetOptimumTravelPath(string travelOrigin, string travelDestination, List<Route> routes);
    }
}
