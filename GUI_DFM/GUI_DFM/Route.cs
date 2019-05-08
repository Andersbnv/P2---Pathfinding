using System.Collections.Generic;
using System.Linq;
using GUI_DFM.Route_Sorting_Algorithms;

namespace GUI_DFM
{
    public class Route
    {
        public List<Vertex> routeList;
        public Vertex startingPoint;
        public Route(List<Vertex> routeList, Vertex startingPoint)
        {
            this.routeList = routeList;
            this.startingPoint = startingPoint;
        }
        public void CalculateRoute(IRouteAlgorithm algorithm)
        {
            routeList = algorithm.Algorithm(startingPoint, routeList);
        }
        public double RouteDistance()
        {
            double totalDistance = 0;
            for (int i = 1; i < routeList.Count; i++)
            {
                totalDistance += routeList[i].DistanceToVertex(routeList[i - 1]);
            }
            if (routeList.Count != 0)
            {
                totalDistance += routeList[routeList.Count - 1].DistanceToVertex(routeList[0]);
            }
            return totalDistance;
        } 
        public void AddToList(Vertex vertexToBeAdded)
        {
            routeList.Add(vertexToBeAdded);
        }
        public void RemoveFromList(int index)
        {
            if(routeList.Count > 0)
            {
                routeList.RemoveAt(index);
            }  
        }
        public void MoveUpElement(int index)
        {
            if(index == 0)
            {
                Vertex buffer = routeList.ElementAt(index);
                RemoveFromList(index);
                routeList.Add(buffer);
            }
            else
            {
                Vertex buffer = routeList.ElementAt(index);
                RemoveFromList(index);
                routeList.Insert((index-1), buffer);
            }
        }
        public void MoveDownElement(int index, int listCount)
        {
            if(index == listCount-1)
            {
                Vertex buffer = routeList.ElementAt(index);
                RemoveFromList(index);
                routeList.Insert(0, buffer);
            }
            else
            {
                Vertex buffer = routeList.ElementAt(index);
                RemoveFromList(index);
                routeList.Insert(index + 1, buffer);
            }
        }
    }
}
