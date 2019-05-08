using System;
using System.Collections.Generic;

namespace GUI_DFM
{
    public class Vertex
    {
        public string address;
        public double xCoordinate;
        public double yCoordinate;
        public List<Edge> connectionList = new List<Edge>();
        public Vertex(string address, double xCordinate, double yCordinate)
        {
            this.address = address;
            xCoordinate = xCordinate;
            yCoordinate = yCordinate;
        }
        public override string ToString()
        {
            return $"{address} X:{xCoordinate} Y:{yCoordinate}";
        }
        public void InitializeConnectionList(List<Vertex> vertexList)
        {
            foreach (var vertex in vertexList)
            {
                connectionList.Add(new Edge(address, DistanceToVertex(vertex), vertex.address));
            }
        }
        public double DistanceToVertex(Vertex vertex)
        {
            double xDistance = vertex.xCoordinate - xCoordinate;
            double yDistance = vertex.yCoordinate - yCoordinate;
            return Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
        }
    }
}
