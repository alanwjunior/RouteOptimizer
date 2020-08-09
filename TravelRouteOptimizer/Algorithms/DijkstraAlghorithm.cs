using System;
using System.Collections.Generic;
using System.Text;
using TravelRouteOptimizer.Models;
using System.Linq;

namespace TravelRouteOptimizer.Algorithms
{
    public class DijkstraAlghorithm
    {
        public Dictionary<string, Dictionary<string, int>> EdgesAdjacents { get; set; }
        public Dictionary<string, bool> EdgeVisitStatus { get; set; }
        public Dictionary<string, int> EdgeMinDistance { get; set; }
        public Dictionary<string, string> EdgeMinDistanceOrigin { get; set; }

        public DijkstraAlghorithm(List<Route> routes)
        {
            var places = routes.Select(r => r.Source);
            places = places.Concat(routes.Select(r => r.Destination));
            places = places.Distinct();
            this.SetEdgesAdjacents(places.ToList(), routes);
            this.InitializeEdgeMinDistance(places.ToList());
            this.InitializeNodesVisitStatus(places.ToList());
        }

        private void SetEdgesAdjacents(List<string> edges, List<Route> routes)
        {

            this.EdgesAdjacents = new Dictionary<string, Dictionary<string, int>>();
            foreach (var edge in edges)
            {
                var adjacents = new Dictionary<string, int>();
                var edgeAdjacents = routes.Where(r => r.Source == edge);
                foreach (var adjacentEdge in edgeAdjacents)
                {
                    adjacents.Add(adjacentEdge.Destination, adjacentEdge.Cost);
                }
                this.EdgesAdjacents.Add(edge, adjacents);
            }
        }

        private void InitializeEdgeMinDistance(List<string> edges)
        {
            this.EdgeMinDistance = new Dictionary<string, int>();
            this.EdgeMinDistanceOrigin = new Dictionary<string, string>();
            foreach (var edge in edges)
            {
                this.EdgeMinDistance.Add(edge, Int32.MaxValue);
                this.EdgeMinDistanceOrigin.Add(edge, null);
            }
        }

        private void InitializeNodesVisitStatus(List<string> nodes)
        {
            this.EdgeVisitStatus = new Dictionary<string, Boolean>();
            foreach (var node in nodes)
            {
                this.EdgeVisitStatus.Add(node, false);
            }
        }

        private bool HasEdgeToVisit()
        {
            return this.EdgeVisitStatus.ContainsValue(false);
        }

        private string GetNextEdge()
        {
            var notVisitEdges = this.EdgeMinDistance.Where(c => !this.EdgeVisitStatus[c.Key]);
            return notVisitEdges.Any() ? notVisitEdges.OrderBy(e => e.Value).First().Key : null;
        }

        private void UpdateEdgeMinDistance(string edge)
        {
            var adjacentEdges = this.EdgesAdjacents[edge];
            foreach (var adjacentEdge in adjacentEdges)
            {
                if (adjacentEdges[adjacentEdge.Key] + this.EdgeMinDistance[edge] < this.EdgeMinDistance[adjacentEdge.Key])
                {
                    this.EdgeMinDistance[adjacentEdge.Key] = adjacentEdges[adjacentEdge.Key] + this.EdgeMinDistance[edge];
                    this.EdgeMinDistanceOrigin[adjacentEdge.Key] = edge;
                }
            }
        }

        private BestRoutePath ReturnBestRoutePath(string origin, string destination)
        {
            if (this.EdgeMinDistanceOrigin[destination] == null || this.EdgeMinDistance[destination] == Int32.MaxValue) return this.ReturnInvalidRoute();
            var path = new BestRoutePath();
            var edges = new List<string>();
            var edge = destination;
            do
            {
                if (edge == null) return this.ReturnInvalidRoute();
                edges.Insert(0, edge);
                edge = this.EdgeMinDistanceOrigin[edge];
            } while (edge != origin);
            edges.Insert(0, origin);
            path.RoutePath = string.Join(" - ", edges);
            path.Cost = this.EdgeMinDistance[destination];
            return path;
        }

        private BestRoutePath ReturnInvalidRoute()
        {
            var path = new BestRoutePath();
            path.RoutePath = "There is not an available route to this travel";
            path.Cost = Int32.MaxValue;
            return path;
        }

        public BestRoutePath CalcBestRoutePath(string origin, string destination)
        {
            var currentEdge = origin;
            this.EdgeMinDistance[origin] = 0;
            do
            {
                this.UpdateEdgeMinDistance(currentEdge);
                this.EdgeVisitStatus[currentEdge] = true;
                currentEdge = this.GetNextEdge();
            } while (this.HasEdgeToVisit() && currentEdge != null);
            return this.ReturnBestRoutePath(origin, destination);
        }
    }
}
