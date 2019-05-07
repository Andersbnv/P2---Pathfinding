using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public class NearestNeighbour : RouteAlgorithm
    {
        public override List<Vertex> Algorithm(Vertex startingPoint, List<Vertex> unsortedRoute)
        {
            List<Vertex> sortedRoute = new List<Vertex>();
            unsortedRoute.Insert(0, startingPoint);
            unsortedRoute = RemoveDuplicates(unsortedRoute);
            int numberOfILoops = unsortedRoute.Count;

            for (int i = 0; i < numberOfILoops; i++)
            {
                if (i == 0)
                {
                    sortedRoute.Add(startingPoint);
                    unsortedRoute.Remove(unsortedRoute[0]);
                } 
                else
                {
                    double currentMinDistance = 0;
                    int indexMinDistance = 0;
                    for (int j = 0; j < unsortedRoute.Count; j++)
                    {
                        if (sortedRoute[i - 1].DistanceToVertex(unsortedRoute[j]) < currentMinDistance || currentMinDistance == 0)
                        {
                            currentMinDistance = unsortedRoute[j].DistanceToVertex(sortedRoute[i - 1]);
                            indexMinDistance = j;
                        }
                    }
                    sortedRoute.Add(unsortedRoute[indexMinDistance]);
                    unsortedRoute.Remove(unsortedRoute[indexMinDistance]);
                }

            }
            return sortedRoute;
        }

    }
}
