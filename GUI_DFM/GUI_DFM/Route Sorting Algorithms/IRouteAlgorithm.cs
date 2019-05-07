using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.Route_Sorting_Algorithms
{
    public interface IRouteAlgorithm
    {
        List<Vertex> Algorithm(Vertex startingPoint, List<Vertex> unsortedList);
    }
}
