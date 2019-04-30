using System;
using System.Collections.Generic;

namespace Hungarian
{
    public class Hungarian
    {
        static readonly double inf = double.PositiveInfinity;
        List<Vertex> sortedRoute = new List<Vertex>();

        public string[] RouteLocations(List<Vertex> input)
        {
            string[] locations = new string[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                locations[i] = input[i].Address;
            }
            return locations;
        }

        public void ReduceMatrix(double[,] Matrix)
        {
            int rowLength = Matrix.GetLength(0);
            int columnLength = Matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                double min = double.PositiveInfinity;
                for (int j = 0; j < rowLength; j++)
                {
                    if (Matrix[j, i] < min && Matrix[j, i] != inf)
                    {
                        min = Matrix[j, i];
                    }
                }

                for (int k = 0; k < rowLength; k++)
                {
                    if (Matrix[k, i] != inf)
                    {
                        Matrix[k, i] -= min;
                    }
                }
            }

            for (int i = 0; i < columnLength; i++)
            {
                double min = double.PositiveInfinity;
                for (int j = 0; j < columnLength; j++)
                {
                    if (Matrix[i, j] < min && Matrix[i, j] != inf)
                    {
                        min = Matrix[i, j];
                    }
                }

                for (int k = 0; k < columnLength; k++)
                {
                    if (Matrix[i, k] != inf)
                    {
                        Matrix[i, k] -= min;
                    }
                }
            }
        }
        public double[,] AssignCost(double[,] Matrix)
        {
            int rowLength = Matrix.GetLength(0);
            int columnLength = Matrix.GetLength(1);
            double[,] cost = new double[rowLength, columnLength];

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    double minRow = double.PositiveInfinity;
                    double minColumn = double.PositiveInfinity;

                    if (Matrix[j, i] == 0)
                    {
                        int rowIndex = j;
                        int columnIndex = i;
                        for (int k = 0; k < rowLength; k++)
                        {

                            if (rowIndex != k && Matrix[k, columnIndex] < minRow)
                            {
                                minRow = Matrix[k, columnIndex];
                            }
                        }
                        for (int k = 0; k < columnLength; k++)
                        {
                            if (columnIndex != k && Matrix[rowIndex, k] < minColumn)
                            {
                                minColumn = Matrix[rowIndex, k];
                            }
                        }
                        cost[rowIndex, columnIndex] = minRow + minColumn;
                    }
                }
            }
            return cost;
        }
        public double[] FindRoute(double[,] Matrix, double[,] cost)
        {
            double[] outputArray = new double[2];
            int rowLength = Matrix.GetLength(0);
            int columnLength = Matrix.GetLength(1);
            double maxCost = double.NegativeInfinity;
            int maxIndexRow = 0;
            int maxIndexColumn = 0;

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (cost[i, j] > maxCost)
                    {
                        maxIndexRow = i;
                        maxIndexColumn = j;
                        maxCost = cost[i, j];
                    }
                }
            }
            for (int i = 0; i < columnLength; i++)
            {
                Matrix[i, maxIndexColumn] = inf;
            }

            for (int j = 0; j < rowLength; j++)
            {
                Matrix[maxIndexRow, j] = inf;
            }
            Matrix[maxIndexColumn, maxIndexRow] = inf;
            outputArray[0] = maxIndexRow;
            outputArray[1] = maxIndexColumn;
            return outputArray;
        }
        public double[] FindRoute2(double[,] Matrix, double[,] cost)
        {
            double[] outputArray = new double[2];
            int rowLength = Matrix.GetLength(0);
            int columnLength = Matrix.GetLength(1);
            double maxCost = double.NegativeInfinity;
            double inf = double.PositiveInfinity;
            int maxIndexRow = 0;
            int maxIndexColumn = 0;
            bool zeroInColumn = false;
            bool zeroInRow = false;

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (Matrix[i, j] != inf)
                    {
                        for (int k = 0; k < columnLength; k++)
                        {
                            if (Matrix[k, j] == 0 && k != i)
                            {
                                zeroInRow = true;
                            }
                        }
                        for (int k = 0; k < rowLength; k++)
                        {
                            if (Matrix[i, k] == 0 && k != j)
                            {
                                zeroInColumn = true;
                            }
                        }
                        if (true)
                        {

                        }
                    }
                }
            }
            for (int i = 0; i < columnLength; i++)
            {
                Matrix[i, maxIndexColumn] = inf;
            }

            for (int j = 0; j < rowLength; j++)
            {
                Matrix[maxIndexRow, j] = inf;
            }
            Matrix[maxIndexColumn, maxIndexRow] = inf;
            outputArray[1] = maxIndexRow;
            outputArray[0] = maxIndexColumn;
            return outputArray;
        }

        public void FindVertex(double[] inputArray, List<Vertex> unsortedRoute, string[] locations)
        {
            double val = inputArray[1];
            double val2 = inputArray[0];

            foreach (var Vertex in unsortedRoute)
            {
                if (locations[(int)val2] == Vertex.Address)
                {
                    sortedRoute.Add(Vertex);
                    Console.WriteLine(locations[(int)val2]);
                }
                if (locations[(int)val] == Vertex.Address)
                {
                    sortedRoute.Add(Vertex);
                    Console.WriteLine(locations[(int)val]);
                }
            }

        }

        public List<Vertex> Algorithm(Vertex startingPoint, List<Vertex> unsortedRoute)
        {
            var Matrix = ListToMatrix(unsortedRoute);
            string[] locations = RouteLocations(unsortedRoute);
            int matrixLength = Matrix.GetLength(0);
            int count = 0;
            while (count < matrixLength)
            {
                ReduceMatrix(Matrix);
                var cost = AssignCost(Matrix);
                var route = FindRoute(Matrix, cost);
                FindVertex(route, unsortedRoute, locations);
                count++;
            }
            return sortedRoute;
        }

        public double[,] ListToMatrix(List<Vertex> inputList)
        {
            double[,] outputMatrix = new double[inputList.Count, inputList.Count];
            for (int i = 0; i < inputList.Count; i++)
            {
                for (int j = 0; j < inputList.Count; j++)
                {
                    if (j == i)
                    {
                        outputMatrix[i, j] = Double.PositiveInfinity;
                    }
                    else
                    {
                        outputMatrix[i, j] = inputList[i].ConnectionList[j].Weight;
                    }
                }
            }

            return outputMatrix;
        }
        public double DistanceBetweenVertices(List<Vertex> route)
        {
            int listSize = route.Count;
            double distance = 0;
            int count = 0;

            for (int i = 0; i < listSize; i++)
            {
                count++;
                if (count % 2 == 0)
                {
                    double xDistance = route[i].XCoordinate - route[i - 1].XCoordinate;
                    double yDistance = route[i].YCoordinate - route[i - 1].YCoordinate;
                    distance += Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
                    Console.WriteLine(distance);
                }
            }


            return distance;
        }
        /*static readonly double inf = double.PositiveInfinity;
        public double[] minArray = new double[5];
        public double[,] array2D = new double[5, 5] { { inf, 52, 44, 17, 81 }, { 52, inf, 43, 70, 28 }, { 44, 43, inf, 12, 50 }, { 17, 70, 12, inf, 69 }, { 81, 28, 50, 69, inf } };
        public double[,] cost = new double[5, 5];

        public void ReduceMatrix()
        {
            int rowLength = array2D.GetLength(0);
            int columnLength = array2D.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                double min = double.PositiveInfinity;
                for (int j = 0; j < rowLength; j++)
                {
                    if (array2D[j,i] < min && array2D[j, i] != inf)
                    {
                        min = array2D[j, i];
                    }
                }

                for (int k = 0; k <= 4; k++)
                {
                    if (array2D[k, i] != inf)
                    {
                        array2D[k, i] -= min;
                    }
                }
            }

            for (int i = 0; i < columnLength; i++)
            {
                double min = double.PositiveInfinity;
                for (int j = 0; j < columnLength; j++)
                {
                    if (array2D[i, j] < min && array2D[i, j] != inf)
                    {
                        min = array2D[i, j];
                    }
                }

                for (int k = 0; k <= 4; k++)
                {
                    if (array2D[i, k] != inf)
                    {
                        array2D[i, k] -= min;
                    }
                }
            }
        }
        public void AssignCost()
        {
            int rowLength = array2D.GetLength(0);
            int columnLength = array2D.GetLength(1);

            for (int i = 0; i < columnLength; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    double minRow = double.PositiveInfinity;
                    double minColumn = double.PositiveInfinity;

                    if (array2D[j,i] == 0)
                    {
                        int rowIndex = j;
                        int columnIndex = i;
                        for (int k = 0; k < rowLength; k++)
                        {
                            
                            if (rowIndex != k && array2D[k, columnIndex] < minRow)
                            {
                                   minRow = array2D[k, columnIndex];
                            }
                        }
                        for (int k = 0; k < columnLength; k++)
                        {
                            if (columnIndex != k && array2D[rowIndex, k] < minColumn)
                            {
                                   minColumn = array2D[rowIndex, k];
                            }
                        }
                        cost[rowIndex, columnIndex] = minRow + minColumn;
                    }
                }
            }
        }
        public string FindRoute()
        {
            int [] outputArray = new int[2];
            int rowLength = array2D.GetLength(0);
            int columnLength = array2D.GetLength(1);
            double maxCost = double.NegativeInfinity;
            int maxIndexRow = 0;
            int maxIndexColumn = 0;

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    if (cost[i,j] > maxCost)
                    {
                        maxIndexRow = i;
                        maxIndexColumn = j;
                        maxCost = cost[i, j];
                    }
                }
            }
            for (int i = 0; i < columnLength; i++)
            {
                array2D[i, maxIndexColumn] = inf;
            }

            for (int j = 0; j < rowLength; j++)
            {
                array2D[maxIndexRow, j] = inf;
            }
            array2D[maxIndexColumn, maxIndexRow] = inf;
            Array.Clear(cost, 0, cost.Length);
            string output = maxIndexRow + " " + maxIndexColumn;
            return output;
        }

        public void HungarianAlgorithm(int count)
        {
            int matrixLength = array2D.GetLength(0);
            if (count != matrixLength)
            {
                ReduceMatrix();
                AssignCost();
                Console.WriteLine(FindRoute());

                count += 1;
                HungarianAlgorithm(count);
            }
        }*/
    }
}