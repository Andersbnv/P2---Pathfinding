using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hungarian
{
    public static class BruteForce
    {

        public static Vertex[] Algorithm(List<Vertex> inputList, Vertex startpoint)
        {
            Vertex[] array = inputList.ToArray();

            var permutation = array.GetPermutations();

            var minValue = Double.PositiveInfinity;
            Vertex[] bestList = null;
            int i = 0;
            foreach (var item1 in permutation)
            {
                var item = item1.ToArray();
                Console.WriteLine($"{item[0]} {item[1]} {item[2]} {item[3]} {item[4]} ");
                //var temp = item.ToArray();
                //if (minValue > temp.TotalWeight())
                //    bestList = temp;
            }
            return bestList;
        }
        public static double TotalWeight(this Vertex[] vertices)
        {
            if (vertices == null)
                return Double.PositiveInfinity;
            double distance = 0;
            int i;
            for (i = 0; i < vertices.Length-1; i++)
            {
                distance += vertices[i].DistanceToVertex(vertices[i + 1]);
            }
            return distance += vertices[i].DistanceToVertex(vertices[0]);
        }



        public static int[] Algorithm(List<int> inputList, int startpoint)
        {
            int[] array = inputList.ToArray();

            var permutation = array.GetPermutations();

            var minValue = Double.PositiveInfinity;
            int[] bestList = null;
            int i = 0;
            foreach (var item1 in permutation)
            {
                var item = item1.ToArray();
                Console.WriteLine($"{item[0]} {item[1]} {item[2]} {item[3]} {item[4]} ");
                //var temp = item.ToArray();
                //if (minValue > temp.TotalWeight())
                //    bestList = temp;
            }
            return bestList;
        }
        public static double TotalWeight(this int[] vertices)
        {
            if (vertices == null)
                return Double.PositiveInfinity;
            double distance = 0;
            foreach (var item in vertices)
            {
                distance += (double)item;
            }
            return distance;
        }
    }
}