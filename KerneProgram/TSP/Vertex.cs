using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Vertex
    {
        public string adress { get; set; }
        public double xCordinate { get; set; }
        public double yCordinate { get; set; }

        public List<Tuple<string, double>> connectionList = new List<Tuple<string, double>>();
        public override string ToString()
        {
            string liststring = "";
            foreach (var item in connectionList)
            {
                liststring += $"\t{item.Item1} Weight:{item.Item2}\n";
            }

            return $"{adress} X:{xCordinate} Y:{yCordinate}\n{liststring}";
        }
        public Vertex(string adress, double xCordinate, double yCordinate)
        {
            this.adress = adress;
            this.xCordinate = xCordinate;
            this.yCordinate = yCordinate;

        }
        public void initializeConnectionList(List<Vertex> knudeList)
        {
            double xDistance = 0;
            double yDistance = 0;
            double distance = 0;
            foreach (Vertex knude in knudeList)
            {
                xDistance = knude.xCordinate - this.xCordinate;
                yDistance = knude.yCordinate - this.yCordinate;
                distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
                connectionList.Add(new Tuple<string, double>(knude.adress, distance));
            }
        }

    }
}
