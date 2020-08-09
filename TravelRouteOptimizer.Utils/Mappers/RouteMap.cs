using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRouteOptimizer.Models;

namespace TravelRouteOptimizer.Utils.Mappers
{
    public class RouteMap: ClassMap<Route>
    {
        public RouteMap()
        {
            Map(r => r.Source).Name("Source");
            Map(r => r.Destination).Name("Destination");
            Map(r => r.Cost).Name("Cost");
        }
    }
}
