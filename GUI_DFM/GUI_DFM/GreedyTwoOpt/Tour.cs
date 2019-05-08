using System;
using System.Collections.Generic;
using System.Linq;

namespace GUI_DFM.GreedyTwoOpt
{
    public class Tour
    {
        public double[,] weightMatrix;
        public int[] indexRoute;
        public delegate void weightDelegate();
        public weightDelegate WeightUpdate;
        public double Weight { get; private set; }  // Weight from start to finish.
        public double TotalWeight                   // Weight from start and back to start.
        {
            get => Weight + weightMatrix[indexRoute[indexRoute.Length - 1], indexRoute[0]];
        }
        public Tour(List<Vertex> inputList)
        {
            var count = inputList.Count;
            weightMatrix = new double[count, count];
            InitializeWeightMatrix(inputList);
            indexRoute = new int[count];
            indexRoute = Enumerable.Range(0, count).ToArray();
            WeightUpdate += IndexRouteWeight;
            WeightUpdate();
        }
        public Tour(Tour input)
        {

            indexRoute = input.indexRoute.Select(x => x).ToArray();
            weightMatrix = input.weightMatrix;

            WeightUpdate += IndexRouteWeight;
            WeightUpdate();
        }
        private void InitializeWeightMatrix(List<Vertex> Vertices)
        {
            int rowLength = weightMatrix.GetLength(0);
            int columnLength = weightMatrix.GetLength(1);
            for (int row = 0; row < rowLength; row++)
            {
                for (int column = 0; column < columnLength; column++)
                {
                    weightMatrix[row, column] = row != column ?
                        Vertices[row].DistanceToVertex(Vertices[column]) : Double.PositiveInfinity;
                }
            }
        }
        private void IndexRouteWeight()
        {
            double weight = 0;
            for (int i = 0; i < indexRoute.Length - 1; i++)
            {
                var temp = weightMatrix[indexRoute[i], indexRoute[i + 1]];
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
                var indexLength = indexRoute.Length;
                for (int i = 0; i < indexLength - 3; i++)
                {
                    for (int j = i + 2; j < indexLength - 1; j++)
                    {
                        double twoOptResult =
                            weightMatrix[indexRoute[i], indexRoute[j]] +
                            weightMatrix[indexRoute[i + 1], indexRoute[j + 1]] -
                            weightMatrix[indexRoute[i], indexRoute[i + 1]] -
                            weightMatrix[indexRoute[j], indexRoute[j + 1]];
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
            var temp = indexRoute[i + 1];
            indexRoute[i + 1] = indexRoute[j];
            indexRoute[j] = temp;
        }
    }
}
