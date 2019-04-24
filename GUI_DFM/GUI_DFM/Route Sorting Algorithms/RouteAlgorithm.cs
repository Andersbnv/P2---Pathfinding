using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public abstract class RouteAlgorithm
    {
        public List<Vertex> RemoveDuplicates(List<Vertex> inputList)
        {
            return inputList.GroupBy(c => c.Address).Select(c => c.First()).ToList();
        }
        public abstract List<Vertex> Algorithm(Vertex startingPoint, List<Vertex> unsortedList);

        public double[,] ListToMatrix(List<Vertex> inputList)
        {
            double[,] outputMatrix = new double[inputList.Count, inputList.Count];
            for (int i = 0; i < inputList.Count; i++)
            {
                for (int j = 0; j < inputList.Count; j++)
                {
                    if (j == i)
                    {
                        outputMatrix[i, j] = Double.PositiveInfinity;
                    }
                    else
                    {
                        outputMatrix[i, j] = inputList[i].ConnectionList[j].Weight;
                    }
                }
            }
            return outputMatrix;
        }
    }
}
