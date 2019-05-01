using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.Route_Sorting_Algorithms.BranchAndBound
{
    public class BranchAndBoundAlgorithm : RouteAlgorithm
    {
        /*public double distance()
        {

            return distance
        }
        */
        public override List<Vertex> Algorithm(Vertex startingPoint, List<Vertex> unsortedList)
        {
            unsortedList.Insert(0, startingPoint);
            unsortedList = RemoveDuplicates(unsortedList);
            double[,] matrix = ListToMatrix(unsortedList);

            int [,] matrixIndexes = BranchAndBound(new TopNode(matrix), new List<Node>());
            List<Vertex> sortedRoute = MatrixIndexToList( matrixIndexes, unsortedList);

            return sortedRoute;
        }

        public List<Vertex> MatrixIndexToList(int [,] indexes, List<Vertex> unsortedList)
        {
            int i = 0;
            var sortedList = new List<Vertex>();
            for (int itteration = 0; itteration < indexes.GetLength(0); itteration++)
            {
                sortedList.Add(unsortedList[i]);
                i = indexes[i, 1];
            }

            return sortedList;
        }

        public int [,] BranchAndBound(Node currentNode, List<Node> nodeList)
        {
            if (currentNode.levelsDeep == currentNode.upperNode.matrix.GetLength(0))
            {
                bool foundBetterNode = false;
                foreach (var node in nodeList)
                {
                    if (node.childNodes.Count == 0 && currentNode.lowerBound > node.lowerBound && node.ValidateMatrix())
                    {
                        currentNode = node;
                        foundBetterNode = true;
                    }
                }
                if (!foundBetterNode)
                {
                    return currentNode.GetPreviouslyVisitedVertexes(new int[0, 0]);
                }
                else
                {
                    return BranchAndBound(currentNode, nodeList);
                }
            }

            double[,] nodeMatrix;
            int rowIndexToBranchFrom = 0;
            if (currentNode is LowerNode)
            {
                rowIndexToBranchFrom = ((LowerNode)currentNode).elementRowRemoved + 1;
                nodeMatrix = ((LowerNode)currentNode).GetMatrix(currentNode.upperNode.matrix);
            }
            else
            {
                nodeMatrix = ((TopNode)currentNode).matrix;
            }

            for (int i = 0; i < currentNode.upperNode.matrix.GetLength(0); i++)
            {
                if (!Double.IsPositiveInfinity(nodeMatrix[rowIndexToBranchFrom, i]))
                {
                    nodeList.Add(new LowerNode(currentNode, rowIndexToBranchFrom, i));
                }
            }

            double bestLowerBound = double.MaxValue;
            for (int i = 1; i < nodeList.Count; i++)
            {
                if (nodeList[i].childNodes.Count == 0 && nodeList[i].lowerBound < bestLowerBound &&
                    nodeList[i].ValidateMatrix())
                {
                    currentNode = nodeList[i];
                    bestLowerBound = currentNode.lowerBound;
                }
            }

            return BranchAndBound(currentNode, nodeList);
        }
    }
}
