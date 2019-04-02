using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Graph
    {
        public List<Vertex> knudeListe = new List<Vertex>();
        public List<Tuple<string, double>> kantListe = new List<Tuple<string, double>>();

        public Graph(string filePath)
        {
            List<string> fileLines = File.ReadAllLines(filePath).ToList(); // Vi læser alle linjer, og indsætte rdem i en List med ToList

            foreach (string line in fileLines)
            {
                string[] lineElements = line.Split(',');
                knudeListe.Add(new Vertex((lineElements)[0], double.Parse(lineElements[1]), double.Parse(lineElements[2])));
            }
            foreach (Vertex item in knudeListe)
            {
                item.initializeConnectionList(knudeListe);
            }
        }


        public void printVertex()
        {
            foreach (Vertex knude in knudeListe)
            {
                Console.WriteLine("City: " + knude.adress + " X: " + knude.xCordinate + " Y: " + knude.yCordinate);

            }
        }
    }
}
