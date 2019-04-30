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
            var listInt = new List<int>() { 1,2,3,4,5};
            var list = new List<Vertex>();
            var tal = Enumerable.Range(1, 100).ToArray();
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Vertex($"{tal[i]}", random.Next(150), random.Next(150)));
            }
            Console.WriteLine("Done");

            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            var route = BruteForce.Algorithm(listInt, listInt[0]);
            Timer.Stop();

            Console.WriteLine("Time taken = " + Timer.Elapsed);

            Console.WriteLine(route.TotalWeight());
            Console.ReadKey();
        }
    }
}