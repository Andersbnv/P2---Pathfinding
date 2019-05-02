using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public class Route
    {
        public List<Vertex> RouteList;
        public Vertex StartingPoint;
        public Route(List<Vertex> RouteList, Vertex StartingPoint)
        {
            this.RouteList = RouteList;
            this.StartingPoint = StartingPoint;
        }
        public void CalculateRoute(RouteAlgorithm algorithm)
        {
            RouteList = algorithm.Algorithm(StartingPoint, RouteList);
        }
        public double RouteDistance()
        {
            double totalDistance = 0;
            for (int i = 1; i < RouteList.Count; i++)
            {
                totalDistance += RouteList[i].DistanceToVertex(RouteList[i - 1]);
            }
            if (RouteList.Count != 0)
            {
                totalDistance += RouteList[RouteList.Count - 1].DistanceToVertex(RouteList[0]);
            }
            return totalDistance;
        } 
        public void AddToList(Vertex vertexToBeAdded)
        {
            RouteList.Add(vertexToBeAdded);
        }
        public void RemoveFromList(int index)
        {
            if(RouteList.Count > 0)
            {
                RouteList.RemoveAt(index);
            }  
        }
        public void MoveUpElement(int index)
        {
            if(index == 0)
            {
                Vertex buffer = RouteList.ElementAt(index);
                RemoveFromList(index);
                RouteList.Add(buffer);
            }
            else
            {
                Vertex buffer = RouteList.ElementAt(index);
                RemoveFromList(index);
                RouteList.Insert((index-1), buffer);
            }
        }
        public void MoveDownElement(int index, int listCount)
        {
            if(index == listCount-1)
            {
                Vertex buffer = RouteList.ElementAt(index);
                RemoveFromList(index);
                RouteList.Insert(0, buffer);
            }
            else
            {
                Vertex buffer = RouteList.ElementAt(index);
                RemoveFromList(index);
                RouteList.Insert(index + 1, buffer);
            }
        }
    }
}
