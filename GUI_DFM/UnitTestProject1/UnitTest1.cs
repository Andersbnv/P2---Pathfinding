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
        [TestMethod]
        public void BranchAndBoundTest()
        {
            var testMatrix = new double[,]
            {
                { Double.PositiveInfinity, 52, 44, 17, 81 },
                { 52, Double.PositiveInfinity, 43, 70, 28 },
                { 44, 43, Double.PositiveInfinity, 12, 50 },
                { 17, 70, 12, Double.PositiveInfinity, 69 },
                { 81, 28, 50, 69, Double.PositiveInfinity }
            };
            var testAlgorithm = new BranchAndBoundAlgorithm();
            var expected = new int[,]
            {
                { 0, 1 },
                { 1, 4 },
                { 2, 3 },
                { 3, 0 },
                { 4, 2 }
            };

            var actual = testAlgorithm.BranchAndBound(testMatrix, new TopNode(testMatrix), new List<Node>(), new int[0,0]);
            double distance = 0;

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                distance += testMatrix[i, actual[i,1]];
            }

            CollectionAssert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void ReduceMatrixTest()
        {
            var testMatrix = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int rowToBeRemoved = 0;
            int columnToBeRemoved = 1;
            var expected = new double[,] { { Double.PositiveInfinity, 6 }, { 7, 9 } };
            var testParent = new TopNode(testMatrix);
            var testNode = new LowerNode(testParent, rowToBeRemoved, columnToBeRemoved);

            var actual = testNode.matrix;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReduceOneByOneMatrixTest()
        {
            var testMatrix = new double[,] { { 1 } };
            int rowToBeRemoved = 0;
            int columnToBeRemoved = 0;
            var expected = new double[,] { };
            var testParent = new TopNode(testMatrix);
            var testNode = new LowerNode(testParent, rowToBeRemoved, columnToBeRemoved);

            var actual = testNode.ReduceMatrix(testMatrix, rowToBeRemoved, columnToBeRemoved);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOriginalColumnIndexTest()
        {
            var testMatrix = new double[,]
            {
                { Double.PositiveInfinity, 52, 44, 17, 81 },
                { 52, Double.PositiveInfinity, 43, 70, 28 },
                { 44, 43, Double.PositiveInfinity, 12, 50 },
                { 17, 70, 12, Double.PositiveInfinity, 69 },
                { 81, 28, 50, 69, Double.PositiveInfinity }
            };
            var nodeList = new List<Node>();
            var testNode = new TopNode(testMatrix);
            var testNode1 = new LowerNode(testNode, 0, 1);
            var testNode2 = new LowerNode(testNode1, 0, 3);
            var testNode3 = new LowerNode(testNode2, 0, 2);
            var testNode4 = new LowerNode(testNode3, 0, 0);
            var testNode5 = new LowerNode(testNode4, 0, 0);
            nodeList.Add(testNode);
            nodeList.Add(testNode1);
            nodeList.Add(testNode2);
            nodeList.Add(testNode3);
            nodeList.Add(testNode4);
            nodeList.Add(testNode5);
            var expected = new int[5] { 1, 4, 3, 0, 2 };

            var actual = new int[5];
            for (int i = 0; i < actual.Length; i++)
            {
                actual[i] = ((LowerNode)nodeList[i + 1]).
                    GetOriginalMatrixElementColumnIndex(((LowerNode)nodeList[i + 1]).elementColumnRemoved);
            }

            CollectionAssert.AreEqual(expected, actual);

        }

    }

}

