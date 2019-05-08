using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace GUI_DFM
{
    public class Graph
    {
        public List<Vertex> vertexList = new List<Vertex>();
        public List<Edge> edgeList = new List<Edge>();
        public Graph(string filePath)
        {
            List<string> fileLines = File.ReadAllLines(filePath).ToList();
            foreach (string line in fileLines)
            {
                string[] lineElements = line.Split(',');
                vertexList.Add(new Vertex((lineElements)[0], double.Parse(lineElements[1]), double.Parse(lineElements[2])));
            }
            foreach (Vertex vertex in vertexList)
            {
                vertex.InitializeConnectionList(vertexList);
                foreach (Edge edge in vertex.connectionList)
                {
                    edgeList.Add(edge);
                }
            }
        }
    }
}
