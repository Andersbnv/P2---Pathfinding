using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUI_DFM;
using System.Collections.Generic;
using GUI_DFM.Route_Sorting_Algorithms.BranchAndBound;

namespace UnitTest
{
    [TestClass]
    public class RouteAlgorithmTest
    {
        [TestMethod]
        public void ListToMatrixTest()
        {
            List<Vertex> testList = new List<Vertex>
            {
                new Vertex("Address1", 3, 4),
                new Vertex("Address2", 6, 8),
                new Vertex("Address3", 9, 12)
            };
            for (int i = 0; i < testList.Count; i++)
            {
                testList[i].ConnectionList = new List<Edge>
                {
                    new Edge(testList[i].Address, i*5, "Adress1"),
                    new Edge(testList[i].Address, i==1 ? 0 : 5, "Adress2"),
                    new Edge(testList[i].Address, 10-5*i, "Adress3")
                };
            }
            RouteAlgorithm testAlgorithm = new NearestNeighbour();
            double[,] actual = testAlgorithm.ListToMatrix(testList);

            double[,] expected = new double[3, 3] 
            { 
                { Double.PositiveInfinity, 5, 10 }, 
                { 5, Double.PositiveInfinity, 5 }, 
                { 10, 5, Double.PositiveInfinity }
            };

            CollectionAssert.AreEqual(expected, actual);
            
        }
    }

    [TestClass]
    public class BranchAndBoundAlgorithmTest
    {

    }
    
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void ReduceMatrixTest()
        {
            var testMatrix = new double[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            int rowToBeRemoved = 2;
            int columnToBeRemoved = 2;
            var expected = new double[,] { { 1, 3 },{ 1, 3 } };
            var testNode = new Node(null, null, null, 0, 0) ;

            var actual = testNode.ReduceMatrix(testMatrix, rowToBeRemoved, columnToBeRemoved);

            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
