using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.Route_Sorting_Algorithms.BranchAndBound
{
    public class LowerNode : Node
    {
        public int elementRowRemoved;
        public int elementColumnRemoved;

        public LowerNode(Node parentNode, int elementRowToBeRemoved, int elementColumnToBeRemoved)
        {
            this.parentNode = parentNode;
            levelsDeep = parentNode.levelsDeep + 1;
            if (parentNode != null)
            {
                parentNode.childNodes.Add(this);
                matrix = ReduceMatrix(parentNode.matrix, elementRowToBeRemoved, elementColumnToBeRemoved);
            }
            elementRowRemoved = elementRowToBeRemoved;
            elementColumnRemoved = elementColumnToBeRemoved;
            lowerBound = GetLowerBound();

        }

        public double [,] ReduceMatrix(double [,] matrix, int rowToBeRemoved, int columnToBeRemoved)
        {
            int numberOfInf = 0;
            double[,] newMatrix = (double[,])matrix.Clone();
            for (int i=0; i < newMatrix.GetLength(0); i++)
            {
                for (int j=0; j < newMatrix.GetLength(0); j++)
                {
                    if (i == rowToBeRemoved || j == columnToBeRemoved ||
                        j == rowToBeRemoved && i == columnToBeRemoved)
                    {
                        newMatrix[i, j] = Double.PositiveInfinity;
                    }
                    if (Double.IsPositiveInfinity(newMatrix[i, j]))
                    {
                        numberOfInf++;
                    }
                }
            }
            if(numberOfInf == matrix.Length && levelsDeep != matrix.GetLength(0))
            {
                validMatrix = false;
            }
            return newMatrix;
        }

        /*public double [,] ReduceMatrix(double[,] originalMatrix, int rowToBeRemoved, int columnToBeRemoved)
        {
            if ((originalMatrix.GetLength(0) == 0 && originalMatrix.GetLength(1) == 0) ||
                (originalMatrix.GetLength(0) == 1 && originalMatrix.GetLength(1) == 1))
            {
                return new double[0, 0];
            }
            var reducedMatrix = new double[originalMatrix.GetLength(0)-1, originalMatrix.GetLength(1)-1];
            var rowRemoved = false;
            int[,] previouslyVisited = GetPreviouslyVisitedVertexes(new int[0, 0]);
            for (int i = 0; i < originalMatrix.GetLength(0); i++)
            {
                var columnRemoved = false;
                if (i == rowToBeRemoved)
                {
                    rowRemoved = true;
                }
                else
                {
                    for (int j = 0; j < originalMatrix.GetLength(1); j++)
                    {

                        if (j == columnToBeRemoved)
                        {
                            columnRemoved = true;
                        }
                        else
                        {
                            for (int k = 0; k < previouslyVisited.GetLength(0); k++)
                            {
                                if (GetOriginalMatrixElementColumnIndex(j) == previouslyVisited[k, 0] &&
                                    GetOriginalMatrixElementRowIndex(i) == previouslyVisited[k, 1])
                                {
                                    reducedMatrix[rowRemoved ? i - 1 : i, columnRemoved ? j - 1 : j] = Double.PositiveInfinity;
                                }
                            }

                            if (i == columnToBeRemoved && j == rowToBeRemoved)
                            {
                                reducedMatrix[rowRemoved ? i - 1 : i, columnRemoved ? j - 1 : j] = Double.PositiveInfinity;
                            }
                            else
                            { 
                                reducedMatrix[rowRemoved ? i - 1 : i, columnRemoved ? j - 1 : j] = originalMatrix[i, j];
                            }
                        }
                    }
                }
            }
            return reducedMatrix;
        }
        */
        public override double GetElementsValue()
        {
            return parentNode.matrix[elementRowRemoved, elementColumnRemoved] + parentNode.GetElementsValue();
        }
        public override int[,] GetPreviouslyVisitedVertexes(int[,] alreadyKnown)
        {
            var updatedVisited = new int[alreadyKnown.GetLength(0)+1, 2];
            updatedVisited[0, 0] = elementRowRemoved;
            updatedVisited[0, 1] = elementColumnRemoved;
            for (int i = 1; i < updatedVisited.GetLength(0); i++)
            {
                updatedVisited[i, 0] = alreadyKnown[i-1, 0];
                updatedVisited[i, 1] = alreadyKnown[i-1, 1];
            }
            return parentNode.GetPreviouslyVisitedVertexes(updatedVisited);
        }
    }
}
