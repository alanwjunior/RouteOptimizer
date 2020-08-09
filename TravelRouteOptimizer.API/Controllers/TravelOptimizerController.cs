using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelRouteOptimizer.Utils;
using TravelRouteOptimizer.Models;

namespace TravelRouteOptimizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelOptimizerController : ControllerBase
    {
        private readonly CsvUtils<Route> _csvUtils;
        private readonly string csvPath = "routes.csv";

        public TravelOptimizerController()
        {
            this._csvUtils = new CsvUtils<Models.Route>();
        }


        [HttpGet]
        public IActionResult Get()
        {
            var routes = this._csvUtils.ReadCsvFile("routes.csv");
            var optimizer = new TravelOptimizerService();
            var bestRoute = optimizer.GetOptimumTravelPath("GRU", "CDG", routes);
            return Ok(bestRoute);
        }

        [HttpGet]
        [Route("routes")]
        public IActionResult Get(List<Models.Route> routes)
        {
            return Ok(this._csvUtils.ReadCsvFile("routes.csv"));
        }

        [HttpPost]
        [Route("routes")]
        public IActionResult CreateRoutes(List<Models.Route> routes)
        {
            this._csvUtils.AppendData(csvPath, routes);
            return Ok(this._csvUtils.ReadCsvFile("routes.csv"));
        }
    }
}
