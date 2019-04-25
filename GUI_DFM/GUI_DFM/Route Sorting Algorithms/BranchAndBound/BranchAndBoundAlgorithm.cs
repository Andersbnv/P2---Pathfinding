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
                throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }
    }
}
