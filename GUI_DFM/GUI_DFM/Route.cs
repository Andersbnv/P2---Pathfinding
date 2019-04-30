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

        public override string ToString()
        {
            string listString = "";
            string distanceStandardString = "Distance from previous: ";
            for (int i = 1; i < RouteList.Count; i++)
            {
                listString += "\nCity: " + RouteList[i].Address + "\t";
                listString += distanceStandardString + RouteList[i].DistanceToVertex(RouteList[i - 1]);
            }
            if (RouteList.Count != 0)
            {
                listString += "\nCity: " + RouteList[0].Address + "\t";
                listString += distanceStandardString + RouteList[0].DistanceToVertex(RouteList[RouteList.Count - 1]) + "\n";
            }
            return "Starting point: " + StartingPoint.Address + listString + "\nTotal distance: " + RouteDistance();
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
            RouteList.Insert(2,vertexToBeAdded);
        }
        public void RemoveFromList(int index)
        {
            RouteList.RemoveAt(index);
        }
        public void ChangeOrderOfList(int index, int destinationIndex)
        {
            Vertex buffer = this.RouteList.ElementAt(index);
            if (index < destinationIndex)
            {
                this.RouteList.Insert(destinationIndex, buffer);
                this.RouteList.Remove(this.RouteList.ElementAt(index));
            }
            else
            {
                this.RouteList.Remove(this.RouteList.ElementAt(index));
                this.RouteList.Insert(destinationIndex, buffer);
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
                
                
                // RouteList.ElementAt(index - 1) = RouteList.ElementAt(index);
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
