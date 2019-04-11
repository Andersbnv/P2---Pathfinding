using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public class Route
    {
        public List<Vertex> SortedRoute;
        public Vertex StartingPoint;

        public Route(RouteAlgorithm algorithm, Vertex startingPoint, List<Vertex> unsortedRoute)
        {
            StartingPoint = startingPoint;
            SortedRoute = algorithm.Algorithm(startingPoint, unsortedRoute);
        }

        public override string ToString()
        {
            string listString = "";
            string distanceStandardString = "Distance from previous: ";
            for (int i = 1; i < SortedRoute.Count; i++)
            {
                listString += "\nCity: " + SortedRoute[i].Address + "\t";
                listString += distanceStandardString + SortedRoute[i].DistanceToVertex(SortedRoute[i - 1]);
            }
            if (SortedRoute.Count != 0)
            {
                listString += "\nCity: " + SortedRoute[0].Address + "\t";
                listString += distanceStandardString + SortedRoute[0].DistanceToVertex(SortedRoute[SortedRoute.Count - 1]) + "\n";
            }
            return "Starting point: " + StartingPoint.Address + listString + "\nTotal distance: " + RouteDistance();
        }

        public double RouteDistance()
        {
            double totalDistance = 0;
            for (int i = 1; i < SortedRoute.Count; i++)
            {
                totalDistance += SortedRoute[i].DistanceToVertex(SortedRoute[i - 1]);
            }
            if (SortedRoute.Count != 0)
            {
                totalDistance += SortedRoute[SortedRoute.Count - 1].DistanceToVertex(SortedRoute[0]);
            }
            return totalDistance;
        }
    }
}
