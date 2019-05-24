using System.Collections.Generic;
using System;
using System.Linq;
using System.IO;

namespace GUI_DFM
{
    public class Graph
    {
        public double[,] weightMatrix;
        public double Weight { get; protected set; }  // Weight from start to finish.
        protected void InitializeWeightMatrix(List<Vertex> Vertices)
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
    }
}
