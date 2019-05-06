using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public class Vertex
    {
        public string Address { get; set; }
        public double XCoordinate { get; set; }
        // Make proper setter.
        public double YCoordinate { get; set; }
        // Make proper setter.
        public List<Edge> ConnectionList = new List<Edge>();

        public Vertex(string address, double xCordinate, double yCordinate)
        {
            Address = address;
            XCoordinate = xCordinate;
            YCoordinate = yCordinate;
        }

        public override string ToString()
        {
            return $"{Address} X:{XCoordinate} Y:{YCoordinate}";
        }

        public void InitializeConnectionList(List<Vertex> vertexList)
        {
            foreach (var vertex in vertexList)
            {
                ConnectionList.Add(new Edge(Address, DistanceToVertex(vertex), vertex.Address));
            }
        }

        public double DistanceToVertex(Vertex vertex)
        {
            double xDistance = vertex.XCoordinate - XCoordinate;
            double yDistance = vertex.YCoordinate - YCoordinate;
            return Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
        }
    }
}
