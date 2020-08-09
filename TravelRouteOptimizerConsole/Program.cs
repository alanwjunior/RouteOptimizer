using System;
using TravelRouteOptimizer.Utils;
using TravelRouteOptimizer.Models;
using TravelRouteOptimizer;

namespace TravelRouteOptimizerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                Console.Write("please enter the route (Ex.: GRU-CGD) or quit to exit:");
                var userInput = Console.ReadLine();
                if (userInput == "quit") quit = true;
                var route = userInput.Split("-");
                var csvUtils = new CsvUtils<Route>();
                var routes = csvUtils.ReadCsvFile("routes.csv");
                var optimizer = new TravelOptimizerService();
                var bestRoute = optimizer.GetOptimumTravelPath("GRU", "CDG", routes);
                var cost = bestRoute.Cost == Int32.MaxValue ? "Infinite" : bestRoute.Cost.ToString();
                Console.WriteLine("best route: " + bestRoute.RoutePath + " > $" + cost);
                Console.WriteLine();
            }

        }
    }
}
