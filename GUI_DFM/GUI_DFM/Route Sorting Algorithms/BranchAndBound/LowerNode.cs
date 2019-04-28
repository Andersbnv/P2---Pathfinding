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
            if (parentNode != null)
            {
                parentNode.childNodes.Add(this);
                matrix = ReduceMatrix(parentNode.matrix, elementRowToBeRemoved, elementColumnToBeRemoved);
            }
            elementRowRemoved = elementRowToBeRemoved;
            elementColumnRemoved = elementColumnToBeRemoved;
            lowerBound = GetLowerBound();
            levelsDeep = parentNode.levelsDeep+1;
        }

        public double [,] ReduceMatrix(double[,] originalMatrix, int rowToBeRemoved, int columnToBeRemoved)
        {
            if ((originalMatrix.GetLength(0) == 0 && originalMatrix.GetLength(1) == 0) ||
                (originalMatrix.GetLength(0) == 1 && originalMatrix.GetLength(1) == 1))
            {
                return new double[0, 0];
            }
            var reducedMatrix = new double[originalMatrix.GetLength(0)-1, originalMatrix.GetLength(1)-1];
            var rowRemoved = false;

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
        public override double GetElementsValue()
        {
            return parentNode.matrix[elementRowRemoved, elementColumnRemoved] + parentNode.GetElementsValue();
        }
        public override int[,] GetPreviouslyVisitedVertexes(int[,] alreadyKnown)
        {
            var updatedVisited = new int[alreadyKnown.GetLength(0)+1, 2];
            for (int i = 0; i < updatedVisited.GetLength(0); i++)
            {
                updatedVisited[i, 0] = i;
                if (i == (updatedVisited.GetLength(0) - 1))
                {
                    updatedVisited[i, 1] = GetOriginalMatrixElementColumnIndex(elementColumnRemoved);
                }
                else
                {
                    updatedVisited[i, 1] = alreadyKnown[i, 1];
                }
            }

            return parentNode.GetPreviouslyVisitedVertexes(updatedVisited);
        }

        public override int GetOriginalMatrixElementColumnIndex(int columnRemoved)
        {
            if (parentNode is TopNode )
            {
                return columnRemoved;
            }
            else
            {
                return ((LowerNode)parentNode).elementColumnRemoved < elementColumnRemoved ?
                        parentNode.GetOriginalMatrixElementColumnIndex(elementColumnRemoved) : 
                        parentNode.GetOriginalMatrixElementColumnIndex(elementColumnRemoved + 1);
            }

        }
    }
}
