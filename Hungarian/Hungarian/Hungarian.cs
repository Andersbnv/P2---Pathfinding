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

        public void FindMinAndReduceMatrix(double[,] matix)
        {
            int rowLength = matix.GetLength(0);
            int columnLength = matix.GetLength(1);

            for (int row = 0; row < rowLength; row++)
            {
                double min = double.PositiveInfinity;
                for (int column = 0; column < rowLength; column++)
                {
                    if (matix[column, row] < min && matix[column, row] != inf)
                    {
                        min = matix[column, row];
                    }
                }

                for (int column = 0; column < rowLength; column++)
                {
                    if (matix[column, row] != inf && min != inf)
                    {
                        matix[column, row] -= min;
                    }
                }
            }

            for (int column = 0; column < columnLength; column++)
            {
                double min = double.PositiveInfinity;
                for (int row = 0; row < columnLength; row++)
                {
                    if (matix[column, row] < min && matix[column, row] != inf)
                    {
                        min = matix[column, row];
                    }
                }

                for (int row = 0; row < columnLength; row++)
                {
                    if (matix[column, row] != inf && min != inf)
                    {
                        matix[column, row] -= min;
                    }
                }
            }
        }
        public double[,] AssignCost(double[,] Matrix)
        {
            int NumberOfColumns = Matrix.GetLength(0);
            int NumberOfRows = Matrix.GetLength(1);
            double[,] cost = new double[NumberOfColumns, NumberOfRows];

            for (int column = 0; column < NumberOfColumns; column++)
            {
                for (int row = 0; row < NumberOfRows; row++)
                {
                    cost[column, row] = double.NegativeInfinity;
                }
            }
            
            for (int row = 0; row < NumberOfRows; row++)
            {
                double minRow = double.PositiveInfinity;
                double minColumn = double.PositiveInfinity;
               
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    if (Matrix[column, row] == 0)
                    {
                        int columnIndex = column; // c1
                        int rowIndex = row;       // r0
                        for (int columnCost = 0; columnCost < NumberOfColumns; columnCost++)
                        {
                            if (columnIndex != columnCost && Matrix[columnCost, rowIndex] < minRow && Matrix[columnCost, rowIndex] != double.PositiveInfinity)
                            {
                                minRow = Matrix[columnCost, rowIndex]; // 0
                            }
                        }

                        for (int rowCost = 0; rowCost < NumberOfRows; rowCost++)
                        {
                            if (rowIndex != rowCost && Matrix[columnIndex, rowCost] < minColumn && Matrix[columnIndex, rowCost] != double.PositiveInfinity)
                            {
                                minColumn = Matrix[columnIndex, rowCost]; // 6
                            }
                        }
                        /*
                        if (minRow == Double.PositiveInfinity)
                        {
                            minRow = 0;
                        }

                        if (minColumn == Double.PositiveInfinity)
                        {
                            minColumn = 0;
                        }
                        
                        if (minRow == 0 && minColumn == 0)
                        {
                            cost[columnIndex, rowIndex] = Double.NegativeInfinity;
                        }
                        */
                        cost[columnIndex, rowIndex] = minRow + minColumn; // [c1,r0] = 0 + 6                        
                    }
                }
            }

            
            return cost;
        }

        private void SpecialCase(double[,] cost)
        {
            var zerosList = new List<(int, int)>();
            for (int column = 0; column < cost.GetLength(0); column++)
            {
                for (int row = 0; row < cost.GetLength(1); row++)
                {
                    if (cost[column, row] == 0)
                    {
                        zerosList.Add((column, row));
                    }
                }
            }



        }
        public double[] FindRoute(double[,] Matrix, double[,] cost)
        {
            double[] outputArray = new double[2];
            int NumberOfColumns = Matrix.GetLength(0);
            int NumberOfRows = Matrix.GetLength(1);
            double maxCost = double.NegativeInfinity;
            int maxCostRowIndex = 0;
            int maxCostColumnIndex = 0;

            for (int row = 0; row < NumberOfColumns; row++)
            {
                for (int column = 0; column < NumberOfRows; column++)
                {
                    if (cost[row, column] > maxCost)
                    {
                        maxCostRowIndex = row;
                        maxCostColumnIndex = column;
                        maxCost = cost[maxCostRowIndex, maxCostColumnIndex];
                    }
                }
            }
            for (int column = 0; column < NumberOfRows; column++)
            {
                Matrix[maxCostRowIndex, column] = inf;
            }

            for (int row = 0; row < NumberOfColumns; row++)
            {
                Matrix[row, maxCostColumnIndex] = inf;
            }
            Matrix[maxCostColumnIndex, maxCostRowIndex] = inf;

            outputArray[0] = maxCostRowIndex;
            outputArray[1] = maxCostColumnIndex;

            Console.WriteLine("DISSE HØRER FUCKIGN SAMMEN"+ " " + outputArray[0]+ " " + outputArray[1]);
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
            Console.WriteLine(outputArray[1] = maxIndexRow);
            Console.WriteLine(outputArray[0] = maxIndexColumn);
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

            //var Matrix = ListToMatrix(unsortedRoute);
            
            double inf = double.PositiveInfinity;
            /*var Matrix = new double[9, 9]
            {
                { inf, 52, 44, 17, 81, 22, 3, 74, 21}, 
                { 52, inf, 43, 70, 28, 44, 4, 16,  37}, 
                { 44, 43, inf, 12, 50, 55, 5, 92, 68}, 
                { 17, 70, 12, inf, 69, 66, 6, 50, 36 }, 
                { 81, 28, 50, 69, inf, 77, 7, 43, 63},
                { 22, 44, 55, 66, 77, inf, 8, 2, 30},
                { 3,   4,  5,  6,  7,  8,  inf, 63, 71},
                { 74, 16, 92, 50, 43, 2, 63,   inf, 55},
                { 21, 37, 68, 36, 63, 30, 71,  55, inf }
                

            };
            */
             var Matrix = new double[10, 10]
            {
                { inf, 52, 44, 17, 81, 22, 3, 74, 21, 75}, 
                { 52, inf, 43, 70, 28, 44, 4, 16,  37, 40}, 
                { 44, 43, inf, 12, 50, 55, 5, 92, 68, 27}, 
                { 17, 70, 12, inf, 69, 66, 6, 50, 36, 87 }, 
                { 81, 28, 50, 69, inf, 77, 7, 43, 63, 78 },
                { 22, 44, 55, 66, 77, inf, 8, 2, 30, 95},
                { 3,   4,  5,  6,  7,  8,  inf, 63, 71, 67},
                { 74, 16, 92, 50, 43, 2, 63,   inf, 55, 3 },
                { 21, 37, 68, 36, 63, 30, 71,  55, inf, 23 },
                { 75, 40, 27, 87, 78, 95, 67,  3, 23, inf },
                
            };
             
            /* {
                { inf, 52, 44, 17, 81, 22, 3, 74, 50}, 
                { 52, inf, 43, 70, 28, 44, 4, 16, 60 }, 
                { 44, 43, inf, 12, 50, 55, 5, 92, 70}, 
                { 17, 70, 12, inf, 69, 66, 6, 50, 80 }, 
                { 81, 28, 50, 69, inf, 77, 7, 43, 90 },
                { 22, 44, 55, 66, 77, inf, 8, 2,  33},
                { 2,   4,  5,  6,  7,  8,  inf, 63, 12},
                { 74, 16, 92, 50, 43, 2, 63,   inf, 37 },
                { 50, 60, 70, 80, 90, 33, 12,   37, inf}
                
            };*/
            /*
             * {
                { inf, 52, 44, 17, 81, 22, 3, 74, 50, 5 }, 
                { 52, inf, 43, 70, 28, 44, 4, 16, 60, 10 }, 
                { 44, 43, inf, 12, 50, 55, 5, 92, 70, 13 }, 
                { 17, 70, 12, inf, 69, 66, 6, 50, 80, 47 }, 
                { 81, 28, 50, 69, inf, 77, 7, 43, 90, 85 },
                { 22, 44, 55, 66, 77, inf, 8, 2,  33, 83 },
                { 2,   4,  5,  6,  7,  8,  inf, 63, 12, 38},
                { 74, 16, 92, 50, 43, 2, 63,   inf, 37, 17 },
                { 50, 60, 70, 80, 90, 33, 12,   37, inf, 71 },
                { 5, 10, 13, 47, 85, 83, 38,   17, 71, inf }
            };
             */
            /*double[,] Matrix = new double[12, 12] {
                { inf, 52, 44, 17, 81, 11, 22, 44, 55, 77, 88, 99 },
                { 52, inf, 43, 70, 28, 22, 44, 67, 87, 78, 34, 23 },
                { 44, 43, inf, 12, 50, 33, 34, 32, 76, 34, 70, 50 },
                { 17, 70, 12, inf, 69, 44, 34, 45, 56, 34, 65, 32 },
                { 81, 28, 50, 69, inf, 55, 43, 65, 76, 34, 43, 43 },
                { 11, 22, 33, 44, 55, inf, 43, 43, 43, 56, 43, 89 },
                { 22, 44, 34, 34, 43, 43, inf, 43, 43, 56, 43, 89 },
                { 44, 77, 32, 45, 65, 43, 43, inf, 43, 56, 43, 89 },
                { 55, 87, 75, 56, 76, 43, 43, 43, inf, 56, 43, 89 },
                { 77, 78, 34, 34, 34, 56, 56, 56, 56, inf, 43, 89 },
                { 88, 34, 70, 65, 43, 43, 43, 43, 43, 43, inf, 89 },
                { 99, 23, 50, 32, 43, 89, 89, 89, 89, 89, 89, inf }};*/

            string[] locations = RouteLocations(unsortedRoute);
            int matrixLength = Matrix.GetLength(0);
            int count = 0;
            while (count < matrixLength)
            {
                FindMinAndReduceMatrix(Matrix);
                var cost = AssignCost(Matrix);
                var route = FindRoute(Matrix, cost);
                //FindVertex(route, unsortedRoute, locations);
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
                        outputMatrix[j, i] = Double.PositiveInfinity;
                    }
                    else
                    {
                        outputMatrix[j, i] = inputList[i].ConnectionList[j].Weight;
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