﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM.Route_Sorting_Algorithms.BranchAndBound
{
    public class TopNode : Node
    {
        public TopNode(double[,] matrix)
        {
            this.matrix = matrix;
            parentNode = null;
            lowerBound = GetLowerBound();
        }
        public override double GetElementsValue()
        {
            return 0;
        }
    }
}
