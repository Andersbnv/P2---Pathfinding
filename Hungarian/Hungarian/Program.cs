using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungarian
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"\\vmware-host\Shared Folders\Desktop\5.tsp";
            Graph graph = new Graph(filePath);

            Hungarian H = new Hungarian();
            var route = H.Algorithm(graph.VertexList.ElementAt(0), graph.VertexList);

            /* int i = 0;
             foreach (var item in route)
             {
                 i++;
                 Console.WriteLine(item);
                 if(i % 2 == 0)
                 {
                     Console.WriteLine("\n");
                 }                             
             }*/



            Console.WriteLine(H.DistanceBetweenVertices(route));
            Console.ReadKey();
        }
    }
}