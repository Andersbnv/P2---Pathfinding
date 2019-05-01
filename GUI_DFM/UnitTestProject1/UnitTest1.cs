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

            var actual = testAlgorithm.BranchAndBound(new TopNode(testMatrix), new List<Node>());
            double distanceActual = 0;
            double distanceExpected = 0;

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                distanceActual += testMatrix[i, actual[i,1]];
            }
            for (int i = 0; i < expected.GetLength(0); i++)
            {
                distanceExpected += testMatrix[i, expected[i, 1]];
            }

            Assert.AreEqual(distanceExpected, distanceActual);
        }

        [TestMethod]
        public void BranchAndBoundTestBig()
        {
            var testMatrix = new double[,]
            {
                { Double.PositiveInfinity, 52, 44, 17, 81, 19, 52, 44, 17, 81 },
                { 52, Double.PositiveInfinity, 43, 70, 28, 14, 52, 44, 17, 81 },
                { 44, 43, Double.PositiveInfinity, 12, 50, 14, 52, 44, 17, 81 }, 
                { 17, 70, 12, Double.PositiveInfinity, 69, 100, 52, 44, 17, 81},
                { 81, 28, 50, 69, Double.PositiveInfinity, 21, 52, 44, 17, 81 },
                { 81, 28, 50, 69, 41, Double.PositiveInfinity, 21, 52, 44, 17 },
                { 81, 28, 50, 69, 41, 21, Double.PositiveInfinity, 52, 44, 17 },
                { 81, 28, 50, 69, 41, 21, 52, Double.PositiveInfinity, 44, 17 },
                { 81, 28, 50, 69, 41, 21, 52, 44, Double.PositiveInfinity, 17 },
                { 81, 28, 50, 69, 41, 21, 42, 19, 52, Double.PositiveInfinity }
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

            var actual = testAlgorithm.BranchAndBound(new TopNode(testMatrix), new List<Node>());
            double distanceActual = 0;
            double distanceExpected = 0;

            for (int i = 0; i < actual.GetLength(0); i++)
            {
                distanceActual += testMatrix[i, actual[i, 1]];
            }
            for (int i = 0; i < expected.GetLength(0); i++)
            {
                distanceExpected += testMatrix[i, expected[i, 1]];
            }

            Assert.AreEqual(distanceExpected, distanceActual);
        }
    }



    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void ReduceMatrixTest()
        {
            var testMatrix = new double[,] 
            { 
                { Double.PositiveInfinity, 2, 3 }, 
                { 4, Double.PositiveInfinity, 6 }, 
                { 7, 8, Double.PositiveInfinity }
            };
            int rowToBeRemoved = 0;
            int columnToBeRemoved = 1;
            var expected = new double[,] 
            {
                { Double.PositiveInfinity, Double.PositiveInfinity, Double.PositiveInfinity },
                { Double.PositiveInfinity, Double.PositiveInfinity, 6 },
                { 7, Double.PositiveInfinity, Double.PositiveInfinity }
            };
            var testParent = new TopNode(testMatrix);
            var testNode = new LowerNode(testParent, rowToBeRemoved, columnToBeRemoved);

            var actual = testNode.GetMatrix(testNode.upperNode.matrix);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPreviouslyVisitedVertexesTest()
        {
            var testMatrix = new double[,]
            {
                { Double.PositiveInfinity, 52, 44, 17, 81 },
                { 52, Double.PositiveInfinity, 43, 70, 28 },
                { 44, 43, Double.PositiveInfinity, 12, 50 },
                { 17, 70, 12, Double.PositiveInfinity, 69 },
                { 81, 28, 50, 69, Double.PositiveInfinity }
            };
            var testNode = new TopNode(testMatrix);
            var testNode1 = new LowerNode(testNode, 0, 1);
            var testNode2 = new LowerNode(testNode1, 1, 4);
            var testNode3 = new LowerNode(testNode2, 2, 3);
            var testNode4 = new LowerNode(testNode3, 3, 0);
            var testNode5 = new LowerNode(testNode4, 4, 2);
            var expected = new int[,]
            {
                { 0, 1 },
                { 1, 4 },
                { 2, 3 },
                { 3, 0 },
                { 4, 2 }
            };

            var actual = testNode5.GetPreviouslyVisitedVertexes(new int[0, 0]);

            CollectionAssert.AreEqual(expected, actual);
        }

    }

}

