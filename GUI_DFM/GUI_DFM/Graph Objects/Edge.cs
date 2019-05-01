using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public class Edge
    {
        public string FirstLocation;
        public double Weight;
        public string SecondLocation;

        public Edge(string firstLocation, double weight, string secondLocation)
        {
            FirstLocation = firstLocation;
            Weight = weight;
            SecondLocation = secondLocation;
        }
        public override string ToString()
        {
            return $"from: {FirstLocation} weight: {Weight} to: {SecondLocation}";
        }
    }
}
