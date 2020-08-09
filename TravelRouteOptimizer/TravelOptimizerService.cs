using System;
using System.Collections.Generic;
using System.Text;
using TravelRouteOptimizer.Algorithms;
using TravelRouteOptimizer.Models;
using TravelRouteOptimizer.Interfaces;

namespace TravelRouteOptimizer
{
    public class TravelOptimizerService: ITravelOptomizerService
    {
        public BestRoutePath GetOptimumTravelPath(string travelOrigin, string travelDestination, List<Route> routes)
        {
            var djikstraAlgorithm = new DijkstraAlghorithm(routes);
            var result = djikstraAlgorithm.CalcBestRoutePath(travelOrigin, travelDestination);
            return result;
        }
    }
}
