using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.Route_Sorting_Algorithms.BranchAndBound
{
    abstract public class Node
    {
        public List<LowerNode> childNodes = new List<LowerNode>();
        public double[,] matrix;
        public double lowerBound;
        public Node parentNode;
        public int levelsDeep;
        public bool validMatrix = true;

        public double GetLowerBound()
        {
            double lowerBound = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int numberOfInf = 0;
                double minRowValue = Double.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!Double.IsPositiveInfinity(matrix[i, j]) && minRowValue > matrix[i,j])
                    {
                        minRowValue = matrix[i, j];
                    }
                    else
                    {
                        numberOfInf++;
                    }
                }
                if (numberOfInf == matrix.GetLength(1))
                {
                    minRowValue = 0; 
                }
                lowerBound += minRowValue;
            }
            lowerBound += GetElementsValue();
            return lowerBound;
        }
        public abstract double GetElementsValue();
        public abstract int [,] GetPreviouslyVisitedVertexes(int [,] alreadyKnown);
    }
}
