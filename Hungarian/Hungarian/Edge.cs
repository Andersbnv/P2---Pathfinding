using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungarian
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
    
    }
}
