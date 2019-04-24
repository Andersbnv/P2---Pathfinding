using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.Route_Sorting_Algorithms.BranchAndBound
{
    public class Node
    {
        public Node parentNode; 
        public List<Node> childNotes;
        public double[,] matrix;
        public int elementRow;
        public int elementColumn;
        public Node(Node parentNode, int elementRow, int elementColumn)
        {
            this.parentNode = parentNode;
            if (parentNode != null)
            {
                parentNode.childNotes.Add(this);
                matrix = ReduceMatrix(parentNode.matrix, elementRow, elementColumn);
            }
            this.elementRow = elementRow;
            this.elementColumn = elementColumn;
        }

        public double [,] ReduceMatrix(double[,] originalMatrix, int rowToBeRemoved, int columnToBeRemoved)
        {
            var reducedMatrix = new double[originalMatrix.GetLength(0)-1, originalMatrix.GetLength(1)-1];
            var rowRemoved = false;

            for (int i = 0; i < originalMatrix.GetLength(0); i++)
            {
                var columnRemoved = false;
                if (i == rowToBeRemoved)
                {
                    i++;
                    rowRemoved = true;
                }
                for (int j = 0; j < originalMatrix.GetLongLength(1); j++)
                {
                    
                    if (j == columnToBeRemoved)
                    {
                        j++;
                        columnRemoved = true;
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
            return reducedMatrix;
        }
    }
}
