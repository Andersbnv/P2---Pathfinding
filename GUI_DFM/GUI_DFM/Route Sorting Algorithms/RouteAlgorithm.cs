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
    }
}
