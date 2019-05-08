using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.GreedyTwoOpt
{
    public class Tour
    {
        public double[,] WeightMatrix;
        public int[] IndexRoute;

        public delegate void weightDelegate();
        public weightDelegate WeightUpdate;
        public double Weight { get; private set; }  // Weight from start to finish.
        public double TotalWeight                   // Weight from start and back to start.
        {
            get => Weight + WeightMatrix[IndexRoute[IndexRoute.Length - 1], IndexRoute[0]];
        }

        public Tour(List<Vertex> inputList)
        {
            var count = inputList.Count;
            WeightMatrix = new double[count, count];
            InitializeWeightMatrix(inputList);
            IndexRoute = new int[count];
            IndexRoute = Enumerable.Range(0, count).ToArray();
            WeightUpdate += IndexRouteWeight;
            WeightUpdate();
        }

        public Tour(Tour input)
        {

            IndexRoute = input.IndexRoute.Select(x => x).ToArray();
            WeightMatrix = input.WeightMatrix;

            WeightUpdate += IndexRouteWeight;
            WeightUpdate();
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
                var temp = WeightMatrix[IndexRoute[i], IndexRoute[i + 1]];
                weight += temp;
            }
            Weight = weight;
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
            WeightUpdate();
        }

        private void TwoOptSwap(int i, int j)
        {
            var temp = IndexRoute[i + 1];
            IndexRoute[i + 1] = IndexRoute[j];
            IndexRoute[j] = temp;
        }
    }
}
