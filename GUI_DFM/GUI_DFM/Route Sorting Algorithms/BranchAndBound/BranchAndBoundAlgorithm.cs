using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.Route_Sorting_Algorithms.BranchAndBound
{
    public class BranchAndBoundAlgorithm : RouteAlgorithm
    {
        public override List<Vertex> Algorithm(Vertex startingPoint, List<Vertex> unsortedList)
        {
            throw new NotImplementedException();
        }

        public int [,] BranchAndBound(double[,] matrix, LowerNode currentNode, List<LowerNode> nodeList, int [,] matrixIndexes)
        {
            if (matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0)
            {
                foreach (var node in nodeList)
                {
                    if (node.childNodes.Count == 0 && currentNode.lowerBound > node.lowerBound)
                    {
                        currentNode = node;
                    }
                    else return matrixIndexes;
                }
                matrixIndexes = UpdateMatrixIndexes(new int[0, 0], currentNode);
                BranchAndBound(currentNode.matrix, currentNode, nodeList, matrixIndexes);
            }
            throw new NotImplementedException();
        }

        public int [,] UpdateMatrixIndexes(int [,] indexesToBeUpdated, Node currentNode)
        {
            if (currentNode.parentNode == null)
            {
                return indexesToBeUpdated;
            }

            int[,] newIndexes = new int[indexesToBeUpdated.GetLength(0)+1, 2];

            return UpdateMatrixIndexes(newIndexes, currentNode.parentNode);
        }
    }
}
