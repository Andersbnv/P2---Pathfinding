using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.Route_Sorting_Algorithms.BranchAndBound
{
    public class LowerNode : Node
    {
        public int elementRow;
        public int elementColumn;
        public LowerNode(Node parentNode, int elementRow, int elementColumn)
        {
            this.parentNode = parentNode;
            if (parentNode != null)
            {
                parentNode.childNodes.Add(this);
                matrix = ReduceMatrix(parentNode.matrix, elementRow, elementColumn);
            }
            this.elementRow = elementRow;
            this.elementColumn = elementColumn;
            lowerBound = GetLowerBound();
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
        public override double GetElementsValue()
        {
            return parentNode.matrix[elementRow, elementColumn] + parentNode.GetElementsValue();
        }
    }
}
