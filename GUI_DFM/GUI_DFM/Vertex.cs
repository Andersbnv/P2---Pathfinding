using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public class Vertex
    {
        public string address { get; set; }
        public double xCoordinate { get; set; }
        public double yCoordinate { get; set; }

        public List<Tuple<string, double>> connectionList = new List<Tuple<string, double>>();
        public override string ToString()
        {
            return $"{address}     X:{xCoordinate}     Y:{yCoordinate}";
        }
        public Vertex(string adress, double xCordinate, double yCordinate)
        {
            this.address = adress;
            this.xCoordinate = xCordinate;
            this.yCoordinate = yCordinate;

        }
        public void initializeConnectionList(List<Vertex> knudeList)
        {
            double xDistance = 0;
            double yDistance = 0;
            double distance = 0;
            foreach (Vertex knude in knudeList)
            {
                xDistance = knude.xCoordinate - this.xCoordinate;
                yDistance = knude.yCoordinate - this.yCoordinate;
                distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
                connectionList.Add(new Tuple<string, double>(knude.address, distance));
            }
        }

    }
}