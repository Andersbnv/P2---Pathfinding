using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    public interface IRouteAlgorithm
    {
        List<Vertex> Algorithm(Vertex startingPoint, List<Vertex> unsortedList);
    }
}
