using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using TravelRouteOptimizer;
using NUnit.Framework;
using TravelRouteOptimizer.Models;

namespace TravelRouteOptimizerTests
{
    [TestFixture]
    public class TravelOptimizerServiceTests
    {

        private TravelOptimizerService _travelOptimizerService;
        private List<Route> _routes;

        [SetUp]
        public void SetUp()
        {
            _travelOptimizerService = new TravelOptimizerService();
            this.mockRoutes();
        }

        private void mockRoutes()
        {
            var routes = new List<Route>();
            routes.Add(new Route { Source = "GRU", Destination = "BRC", Cost = 10 });
            routes.Add(new Route { Source = "BRC", Destination = "SCL", Cost = 5 });
            routes.Add(new Route { Source = "GRU", Destination = "CDG", Cost = 75 });
            routes.Add(new Route { Source = "GRU", Destination = "SCL", Cost = 20 });
            routes.Add(new Route { Source = "GRU", Destination = "ORL", Cost = 56 });
            routes.Add(new Route { Source = "ORL", Destination = "CDG", Cost = 5 });
            routes.Add(new Route { Source = "SCL", Destination = "ORL", Cost = 20 });
            this._routes = routes;
        }

        [Test]
        public void MinCostShouldBe40()
        {
            var result = _travelOptimizerService.GetOptimumTravelPath("GRU", "CDG", this._routes);
            Assert.IsTrue(result.Cost == 40, "Route Cost should be 40");
        }

        [Test]
        public void MinCostShouldBeInfinite()
        {
            var result = _travelOptimizerService.GetOptimumTravelPath("CDG", "SCL", this._routes);
            Assert.IsTrue(result.Cost == Int32.MaxValue, "Route Cost should be Infinite");
        }
    }
}
