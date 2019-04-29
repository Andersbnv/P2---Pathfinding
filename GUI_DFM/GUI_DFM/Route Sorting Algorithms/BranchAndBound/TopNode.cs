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
            levelsDeep = 0;
        }
        public override double GetElementsValue()
        {
            return 0;
        }

        public override int [,] GetPreviouslyVisitedVertexes(int [,] alreadyKnown)
        {
            return alreadyKnown;
        }
        public override int GetOriginalMatrixElementColumnIndex(int columnRemoved)
        {
            return columnRemoved;
        }
    }
}