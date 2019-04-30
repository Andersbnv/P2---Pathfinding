using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Hungarian
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"\\vmware-host\Shared Folders\Desktop\Test5_436.tsp";
            Graph graph = new Graph(filePath);
            Stopwatch Timer = new Stopwatch();


            Hungarian H = new Hungarian();
            Timer.Start();
            var route = H.Algorithm(graph.VertexList.ElementAt(0), graph.VertexList);
            Timer.Stop();

            Console.WriteLine("Time taken = " + Timer.Elapsed);

            Console.WriteLine(H.DistanceBetweenVertices(route));
            Console.ReadKey();
        }
    }
}