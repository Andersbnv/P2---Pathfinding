using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Hungarian
{
    public class Graph
    {
        public List<Vertex> VertexList = new List<Vertex>();
        public List<Edge> EdgeList = new List<Edge>();

        public Graph(string filePath)
        {
            List<string> fileLines = File.ReadAllLines(filePath).ToList(); // Vi læser alle linjer, og indsætter dem i en List med ToList

            foreach (string line in fileLines)
            {
                string[] lineElements = line.Split(' ');
                VertexList.Add(new Vertex((lineElements)[0], double.Parse(lineElements[1]), double.Parse(lineElements[2])));
            }
            foreach (Vertex vertex in VertexList)
            {
                vertex.InitializeConnectionList(VertexList);
                foreach (Edge edge in vertex.ConnectionList)
                {
                    EdgeList.Add(edge);
                }
            }
        }

        public void AddEdge(Vertex newVertex)
        {
            newVertex.InitializeConnectionList(VertexList);
            foreach (Edge edge in newVertex.ConnectionList)
            {
                EdgeList.Add(edge);
            }

        }

        public void AddVertex(Vertex newVertex)
        {
            VertexList.Add(newVertex);
            foreach (var vertex in VertexList)
            {
                vertex.InitializeConnectionList(VertexList);
            }
        }

        public override string ToString()
        {
            string listString = "";
            foreach (Vertex vertex in VertexList)
            {
                listString += "City: " + vertex.Address + " X: " + vertex.XCoordinate + " Y: " + vertex.YCoordinate + "\n";
            }
            return listString;
        }
    }
}
