﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GUI_DFM
{
    public class GreedyTwoOpt : IRouteAlgorithm
    {
        private AlgorithmTour Tour { get; set; }
        private AlgorithmTour _currentImproveTour;
        private readonly Stopwatch _runtime = new Stopwatch();
        private List<Vertex> _vertices;
        public List<Vertex> Algorithm(Vertex startingPoint, List<Vertex> vertices)
        {
            _runtime.Restart();
            _vertices = vertices;

            NearestNeighbor(vertices.IndexOf(startingPoint));
            Tour.TwoOpt();
            Improve();
            _runtime.Stop();

            return ReturnMethod(_vertices, Array.IndexOf(Tour.indexRoute, _vertices.IndexOf(startingPoint)));
        }
        private List<Vertex> ReturnMethod(List<Vertex> inputList, int startingpoint)
        {
            var returnList = new List<Vertex>();
            for (int i = startingpoint; i < inputList.Count; i++)
            {
                returnList.Add(inputList[Tour.indexRoute[i]]);
            }
            for (int i = 0; i < startingpoint; i++)
            {
                returnList.Add(inputList[Tour.indexRoute[i]]);
            }
            return returnList;
        }
        private void NearestNeighbor(int startingPointIndex)
        {
            var outputList = new List<Vertex> { _vertices[startingPointIndex] };
            var tempList = new List<Vertex>(_vertices);
            tempList.Remove(outputList.First());

            var count = tempList.Count;
            for (int i = 0; i < count; i++)
            {
                tempList.Sort
                (
                    (x, y) => x.DistanceToVertex(outputList[i]).CompareTo(y.DistanceToVertex(outputList[i]))
                );
                outputList.Add(tempList.First());
                tempList.RemoveAt(0);
            }
            _vertices = outputList;
            Tour = new AlgorithmTour(outputList);
        }
        private void Improve()
        {
            Random number = new Random();
            _currentImproveTour = new AlgorithmTour(Tour);

            while (_runtime.ElapsedMilliseconds < 11500)
            {
                if (number.Next(99) >= 60)
                {
                    RandomStrat();
                }
                else
                {
                    GreedyStrat();
                }
            }
        }
        private void GreedyStrat()
        {
            var oldPath = Tour.Weight;
            _currentImproveTour.TwoOpt();
            _currentImproveTour.WeightUpdate();

            if (_currentImproveTour.Weight < oldPath)
            {
                Replace();
            }
        }
        private void RandomStrat()
        {
            Random number = new Random();
            _currentImproveTour.indexRoute = _currentImproveTour.indexRoute.OrderBy(x => number.Next()).ToArray();
        }
        private void Replace()
        {
            if (_currentImproveTour.TotalWeight < Tour.TotalWeight)
            {
                Tour.indexRoute = _currentImproveTour.indexRoute.Select(v => v).ToArray();
                Tour.WeightUpdate();
            }
        }
    }
}
