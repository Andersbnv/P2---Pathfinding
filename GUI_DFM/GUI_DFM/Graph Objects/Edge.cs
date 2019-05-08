namespace GUI_DFM
{
    public class Edge
    {
        public string firstLocation;
        public double weight;
        public string secondLocation;
        public Edge(string firstLocation, double weight, string secondLocation)
        {
            this.firstLocation = firstLocation;
            this.weight = weight;
            this.secondLocation = secondLocation;
        }
    }
}