using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelRouteOptimizer.Utils;
using TravelRouteOptimizer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelRouteOptimizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly CsvUtils<Route> _csvUtils;
        private readonly string csvPath = "routes.csv";
        public RoutesController()
        {
            this._csvUtils = new CsvUtils<Route>();
    }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._csvUtils.ReadCsvFile("routes.csv"));
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<Models.Route> routes)
        {
            this._csvUtils.AppendData(csvPath, routes);
            return Ok(this._csvUtils.ReadCsvFile("routes.csv"));
        }
    }
}
