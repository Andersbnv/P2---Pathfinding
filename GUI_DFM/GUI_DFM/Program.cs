using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public class Program
    {
        //bhb
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Chris\source\repos\Andersbnv\P2---Pathfinding\Daniel\TSP CA\Kanter.txt";

            Graph testGraph = new Graph(filePath);
            testGraph.PrintKantListe();

            Console.ReadKey();
        }
    }
}