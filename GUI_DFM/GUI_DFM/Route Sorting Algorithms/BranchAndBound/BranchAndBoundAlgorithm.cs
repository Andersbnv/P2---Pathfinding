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

        public int [,] BranchAndBound(double[,] matrix, Node currentNode, List<Node> nodeList, int [,] matrixIndexes)
        {
            if (matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0)
            {
                bool foundBetterNode = false;
                foreach (var node in nodeList)
                {
                    if (node.childNodes.Count == 0 && currentNode.lowerBound > node.lowerBound)
                    {
                        currentNode = node;
                        foundBetterNode = true;
                    }
                }
                if (!foundBetterNode)
                {
                    return currentNode.GetPreviouslyVisitedVertexes(new int[0,0]);
                }

                matrixIndexes = currentNode.GetPreviouslyVisitedVertexes(new int[0,0]);
                return BranchAndBound(currentNode.matrix, currentNode, nodeList, matrixIndexes);
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (Double.IsPositiveInfinity(matrix[0,i]))
                {
                }
                else
                {
                    nodeList.Add(new LowerNode(currentNode, 0, i));
                }
            }
            double bestLowerBound = double.MaxValue;
            for (int i = 1; i < nodeList.Count; i++)
            {
                if (nodeList[i].childNodes.Count == 0 && nodeList[i].lowerBound < bestLowerBound)
                {
                    currentNode = nodeList[i];
                    bestLowerBound = currentNode.lowerBound;
                }
            }
            matrixIndexes = currentNode.GetPreviouslyVisitedVertexes(new int [0,0]);
            return BranchAndBound(currentNode.matrix, currentNode, nodeList, matrixIndexes);
        }
    }
}
