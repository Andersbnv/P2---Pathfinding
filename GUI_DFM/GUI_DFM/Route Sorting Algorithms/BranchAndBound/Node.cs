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
        public double lowerBound;
        public Node parentNode;
        public int levelsDeep;
        public TopNode upperNode;

        public double GetLowerBound()
        {
            double[,] matrix;
            if (this is LowerNode)
            {
                matrix = ((LowerNode)this).GetMatrix(upperNode.matrix);
            }
            else
            {
                matrix = ((TopNode)this).matrix;
            }
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
        public bool ValidateMatrix()
        {
            bool matrixValid = true;
            double[,] matrix;
            int numberOfInf = 0;

            if (this is LowerNode)
            {
                matrix = ((LowerNode)this).GetMatrix(upperNode.matrix);
            }
            else
            {
                matrix = ((TopNode)this).matrix;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Double.IsPositiveInfinity(matrix[i, j]))
                    {
                        numberOfInf++;
                    }
                }
            }

            if (numberOfInf == matrix.Length && levelsDeep != matrix.GetLength(0))
            {
                matrixValid = false;
            }
            return matrixValid;

        }
        public abstract double GetElementsValue();
        public abstract int [,] GetPreviouslyVisitedVertexes(int [,] alreadyKnown);
    }
}
