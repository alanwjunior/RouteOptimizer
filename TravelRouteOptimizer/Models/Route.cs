using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRouteOptimizer.Models
{
    public class Route
    {
        [CsvHelper.Configuration.Attributes.Name("Source")]
        public string Source { get; set; }
        
        [CsvHelper.Configuration.Attributes.Name("Destination")]
        public string Destination { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Cost")]
        public int Cost { get; set; }
    }
}
