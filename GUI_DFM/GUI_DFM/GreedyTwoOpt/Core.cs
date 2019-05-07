using GUI_DFM.Route_Sorting_Algorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.GreedyTwoOpt
{
    public class Core : IRouteAlgorithm
    {
        private Tour Cycle { get; set; }
        private Tour compareCycle;
        private List<Tour> _currentSubPaths;
        private Stopwatch _runtime = new Stopwatch();
        // arv fra IRouteAlgorithm
        public Core()
        {
            _runtime.Start();
        }

        public List<Vertex> Algorithm(Vertex startingPoint, List<Vertex> unsortedList)
        {
            NearestNeighbor(unsortedList, unsortedList.IndexOf(startingPoint));
            //Console.WriteLine("NN: -> " + Cycle.TotalWeight +" Time: " + _runtime.Elapsed); // Kald kun TwoOpt, hvis der minimum 4 punkter
            Cycle.TwoOpt();
            //Console.WriteLine("2Opt: -> " + Cycle.TotalWeight + " Time: " + _runtime.Elapsed);
            compareCycle = new Tour(Cycle);
            Improve();
            _runtime.Stop();
            //Console.WriteLine("Improve: -> " + Cycle.TotalWeight + " Time: " + _runtime.Elapsed);

            return ReturnMethod(unsortedList); // fix
        }

        private List<Vertex> ReturnMethod(List<Vertex> inputList)
        {
            var returnList = new List<Vertex>();
            foreach (var item in Cycle.IndexRoute)
            {
                returnList.Add(inputList[item]);
            }
            return returnList;
        }

        private void NearestNeighbor(List<Vertex> inputList, int startingPointIndex)
        {

            var outputList = new List<Vertex> { inputList[startingPointIndex] };
            var tempList = new List<Vertex>();
            tempList.AddRange(inputList);
            tempList.Remove(outputList.First());
            var count = tempList.Count;

            for (var i = 0; i < count; i++)
            {
                tempList.Sort
                (
                    (x, y) => x.DistanceToVertex(outputList[i]).CompareTo(y.DistanceToVertex(outputList[i]))
                );
                outputList.Add(tempList.First());
                tempList.RemoveAt(0);
            }
            Cycle = new Tour(outputList);
        }


        private void Improve()
        {
            Random number = new Random();
            _currentSubPaths = Cycle.DivideIntoSubpaths(10);

            while (_runtime.ElapsedMilliseconds < 1000)
            {
                if (number.Next(99) < 10)
                {
                    RandomStrat();
                }
                else
                {
                    GreedyStrat();
                }
            }
        }

        private void GreedyStrat()
        {
            var m = _currentSubPaths.Max(x => x.Weight);
            int worstSubPathIndex = _currentSubPaths.FindIndex(x => x.Weight == m);
            var worstSubPath = _currentSubPaths[worstSubPathIndex];

            var oldPath = worstSubPath.Weight; //skal have lavet så det ikker det samme hvergang
            worstSubPath.TwoOpt();
            worstSubPath.WeightDelegate();
            if (worstSubPath.Weight < oldPath)
            {
                Replace();
            }

        }

        public void RandomStrat()
        {
            Random number = new Random();


            var randomTour = _currentSubPaths[number.Next(_currentSubPaths.Count - 1)];
            randomTour.WeightDelegate();
            var oldPath = randomTour.Weight;

            randomTour.IndexRoute = randomTour.IndexRoute.OrderBy(x => number.Next()).ToArray();
            randomTour.WeightDelegate();
        }

        public void Replace()
        {
            for (int tour = 0; tour < _currentSubPaths.Count; tour++)
            {
                for (int index = 0; index < _currentSubPaths[tour].IndexRoute.Length; index++)
                {
                    compareCycle.IndexRoute[tour * _currentSubPaths[tour].IndexRoute.Length + index] = _currentSubPaths[tour].IndexRoute[index];
                }
            }
            compareCycle.WeightDelegate();

            if (compareCycle.TotalWeight < Cycle.TotalWeight)
            {
                Cycle.IndexRoute = compareCycle.IndexRoute.Select(v => v).ToArray();
                Cycle.WeightDelegate();
            }
        }
    }
}
