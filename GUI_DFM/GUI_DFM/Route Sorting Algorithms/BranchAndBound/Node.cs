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

        public double GetLowerBound()
        {
            double lowerBound = 0;
            if (matrix != null)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    double minRowValue = matrix[i, 0];
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < minRowValue)
                        {
                            minRowValue = matrix[i, j];
                        }
                    }
                    lowerBound += minRowValue;
                }
            }
            lowerBound += GetElementsValue();
            return lowerBound;
        }
        public abstract double GetElementsValue();
    }
}
