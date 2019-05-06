using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.GreedyTwoOpt
{
    class Tour
    {
        public double[,] WeightMatrix;
        public int[] IndexRoute;

        public delegate void weightUpdate();
        public weightUpdate WeightDelegate;

        public double Weight { get; private set; }
        public double TotalWeight
        {
            get => Weight + WeightMatrix[IndexRoute[IndexRoute.Last()], IndexRoute[IndexRoute.First()]];
        }
        #region Constructor and initializers
        public Tour(List<Vertex> inputList)
        {
            var count = inputList.Count;

            IndexRoute = new int[count];
            IndexRoute = Enumerable.Range(0, count).ToArray();

            WeightMatrix = new double[count, count];
            InitializeWeightMatrix(inputList);

            WeightDelegate += IndexRouteWeight;
            WeightDelegate();
        }

        public Tour(Tour input)
        {
            IndexRoute = input.IndexRoute.Select(x => x).ToArray();
            WeightMatrix = input.WeightMatrix;

            WeightDelegate += IndexRouteWeight;
            WeightDelegate();
        }

        private void InitializeWeightMatrix(List<Vertex> Vertices)
        {
            int rowLenth = WeightMatrix.GetLength(0);
            int columnLenth = WeightMatrix.GetLength(1);
            for (int row = 0; row < rowLenth; row++)
            {
                for (int column = 0; column < columnLenth; column++)
                {
                    WeightMatrix[row, column] = row != column ?
                        Vertices[row].DistanceToVertex(Vertices[column]) : Double.PositiveInfinity;
                }
            }
        }

        private void IndexRouteWeight()
        {
            double weight = 0;
            for (int i = 0; i < IndexRoute.Length - 1; i++)
            {
                weight += WeightMatrix[IndexRoute[i], IndexRoute[i + 1]];
            }
            Weight = weight;
        }
        #endregion
        #region Modifiers
        public void CloneIndexRoute(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                IndexRoute[i] = input[i];
            }
            WeightDelegate();
        }

        //public override string ToString()
        //{
        //    string result = "";
        //    foreach (var item in IndexRoute)
        //    {
        //        result += Vertices[item] + "\n";
        //    };
        //    return result;
        //}

        public void Swap(int i, int j)
        {
            int temp = IndexRoute[i];
            IndexRoute[i] = IndexRoute[j];
            IndexRoute[j] = temp;
            WeightDelegate();
        }

        //public void Add(Vertex i)
        //{
        //    Vertices.Add(i);
        //    WeightDelegate();
        //}

        //public void RemoveAt(int index)
        //{
        //    Vertices.RemoveAt(index);
        //    WeightDelegate();
        //}

        #endregion

        // lav om til at passe ind i TOur. Find på hvad subpaths skal være (tour, vertex, egen classe)
        public List<Tour> DivideIntoSubpaths(int chunckSize) // skal lave sådan index ikke kommer outOfbounds
        {
            List<int[]> initialzer =
                IndexRoute
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunckSize)
                .Select(x => x.Select(v => v.Value)
                .ToArray()).ToList();

            List<Tour> result = new List<Tour>();
            foreach (var item in initialzer) //Kan optimeres
            {
                result.Add(new Tour(this) { IndexRoute = item });
            }
            return result;
        }

        public void TwoOpt()
        {
            double change;
            do
            {
                change = 0;
                int iSwap = 0, jSwap = 0;
                var indexLength = IndexRoute.Length;
                for (int i = 0; i < indexLength - 3; i++)
                {
                    for (int j = i + 2; j < indexLength - 1; j++)
                    {
                        double twoOptResult =
                            WeightMatrix[IndexRoute[i], IndexRoute[j]] +
                            WeightMatrix[IndexRoute[i + 1], IndexRoute[j + 1]] -
                            WeightMatrix[IndexRoute[i], IndexRoute[i + 1]] -
                            WeightMatrix[IndexRoute[j], IndexRoute[j + 1]];
                        if (twoOptResult < change)
                        {
                            change = twoOptResult;
                            iSwap = i;
                            jSwap = j;
                        }
                    }
                }
                TwoOptSwap(iSwap, jSwap);
            } while (change < 0);
            WeightDelegate();
        }

        private void TwoOptSwap(int i, int j)
        {
            var temp = IndexRoute[i + 1];
            IndexRoute[i + 1] = IndexRoute[j];
            IndexRoute[j] = temp;
        }
    }
}
