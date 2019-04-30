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
            var listInt = new List<int>() {
                0,1,2,3,4,5,6,7,8,9,
                10,11,12,13,14,15,16,17,18,19,
                30,21,22,23,24,25,26,27,28,29
                //20,31,32,33,34,35,36,37,38,39
            };
            var list = new List<Vertex>();
            var tal = Enumerable.Range(1, 50).ToArray();
            var random = new Random();
            for (int i = 0; i < tal.Length; i++)
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