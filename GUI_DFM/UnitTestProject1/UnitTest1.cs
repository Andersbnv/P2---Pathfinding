using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUI_DFM;

namespace UnitTest
{
    [TestClass]
    public class VertexTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            string expectedAdress = "Adress1";
            double expectedXCordinate = 10;
            double expectedYCordinate = 0;

            Vertex actual = new Vertex("Adress1", 10, 0);

            Assert.AreEqual(expectedAdress, actual.Adress);
            Assert.AreEqual(expectedXCordinate, actual.XCordinate);
            Assert.AreEqual(expectedYCordinate, actual.YCordinate);
        }
        [TestMethod]
        public void DistanceToVertexTest()
        {
            Vertex vertex1 = new Vertex("Adress1", 10, 0);
            Vertex vertex2 = new Vertex("Adress2", 20, 0);
            double expected = 10;

            double actual = vertex1.DistanceToVertex(vertex2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InitializeconnectionListTest()
        {
            Vertex vertex1 = new Vertex("Adress1", 10, 0);
            List<Vertex> vertexList = new List<Vertex>
            {
                vertex1,
                new Vertex("Adress2", 20, 0),
                new Vertex("Adress3", 30, 0),
                new Vertex("Adress4", 40, 0),
                new Vertex("Adress5", 50, 0),
                new Vertex("Adress6", 60, 0),
                new Vertex("Adress7", 70, 0)
            };
            List<Edge> expected = new List<Edge>
            {
                new Edge("Adress1", 0, "Adress1"),
                new Edge("Adress1", 10, "Adress2"),
                new Edge("Adress1", 20, "Adress3"),
                new Edge("Adress1", 30, "Adress4"),
                new Edge("Adress1", 40, "Adress5"),
                new Edge("Adress1", 50, "Adress6"),
                new Edge("Adress1", 60, "Adress7")
            };

            vertex1.InitializeconnectionList(vertexList);
            List<Edge> actual = vertex1.connectionList;

            Assert.AreEqual(expected[1].weight, 10);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].vertexA, actual[i].vertexA);
                Assert.AreEqual(expected[i].weight, actual[i].weight);
                Assert.AreEqual(expected[i].vertexB, actual[i].vertexB);
            }
        }

        [TestMethod]
        public void ToStringTest()
        {
            Vertex vertex1 = new Vertex("Adress1", 10, 0);
            List<Vertex> vertexList = new List<Vertex>
            {
                vertex1,
                new Vertex("Adress2", 20, 0),
                new Vertex("Adress3", 30, 0)
            };
            vertex1.InitializeconnectionList(vertexList);
            string expected = "Adress1 X:10 Y:0\n\tAdress1 weight:0\n\tAdress2 weight:10\n\tAdress3 weight:20\n";

            string actual = vertex1.ToString();

            Assert.AreEqual(expected, actual);
        }
    }


    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            string fileName = "GraphTest.txt";
            string fileLocation = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));
            string filePath = Path.Combine(fileLocation, @"UnitTest\TestFiles\", fileName);
            List<Vertex> expectedvertexList = new List<Vertex>
            {
                new Vertex("Adress1", 10, 0),
                new Vertex("Adress2", 20, 0),
                new Vertex("Adress3", 30, 0)
            };
            List<Edge> expectededgeList = new List<Edge>
            {
                new Edge("Adress1", 0, "Adress1"),
                new Edge("Adress1", 10, "Adress2"),
                new Edge("Adress1", 20, "Adress3"),
                new Edge("Adress2", 10, "Adress1"),
                new Edge("Adress2", 0, "Adress2"),
                new Edge("Adress2", 10, "Adress3"),
                new Edge("Adress3", 20, "Adress1"),
                new Edge("Adress3", 10, "Adress2"),
                new Edge("Adress3", 0, "Adress3")
            };
            double[,] expectedMatrix = new double[,] { { 0, 10, 20 }, { 10, 0, 10 }, { 20, 10, 0 } };

            Graph actualGraph = new Graph(filePath);

            for (int i = 0; i < expectededgeList.Count; i++)
            {
                Assert.AreEqual(expectededgeList[i].vertexA, actualGraph.edgeList[i].vertexA);
                Assert.AreEqual(expectededgeList[i].weight, actualGraph.edgeList[i].weight);
                Assert.AreEqual(expectededgeList[i].vertexB, actualGraph.edgeList[i].vertexB);
            }

            for (int i = 0; i < expectedvertexList.Count; i++)
            {
                Assert.AreEqual(expectedvertexList[i].Adress, actualGraph.vertexList[i].Adress);
                Assert.AreEqual(expectedvertexList[i].XCordinate, actualGraph.vertexList[i].XCordinate);
                Assert.AreEqual(expectedvertexList[i].YCordinate, actualGraph.vertexList[i].YCordinate);
            }
            CollectionAssert.AreEqual(expectedMatrix, actualGraph.matrix);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string fileName = "GraphTest.txt";
            string fileLocation = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));
            string filePath = Path.Combine(fileLocation, @"UnitTest\TestFiles\", fileName);
            Graph testGraph = new Graph(filePath);
            string expected = "City: Adress1 X: 10 Y: 0\nCity: Adress2 X: 20 Y: 0\nCity: Adress3 X: 30 Y: 0\n";

            string actual = testGraph.ToString();

            Assert.AreEqual(expected, actual);
        }
    }


    [TestClass]
    public class EdgeTest
    {


        [TestMethod]
        public void ConstructorTest()
        {
            string expectedvertexA = "Adress1";
            double expectedweight = 10;
            string expectedvertexB = "Adress2";

            Edge actualEdge = new Edge("Adress1", 10, "Adress2");

            Assert.AreEqual(expectedvertexA, actualEdge.vertexA);
            Assert.AreEqual(expectedweight, actualEdge.weight);
            Assert.AreEqual(expectedvertexB, actualEdge.vertexB);
        }
    }

    [TestClass]
    public class NearestNeighbourTest
    {
        [TestMethod]
        public void RemoveDuplicatesTest()
        {
            NearestNeighbour testAlgorithm = new NearestNeighbour();
            List<Vertex> testList = new List<Vertex>
            {
                new Vertex("Adress1", 10, 0),
                new Vertex("Adress1", 20, 0),
                new Vertex("Adress2", 10, 10),
                new Vertex("Adress1", 10, 0),
                new Vertex("Adress2", 30, 0),
                new Vertex("Adress3", 10, 10)
            };
            List<Vertex> expected = new List<Vertex>
            {
                new Vertex("Adress1", 10, 0),
                new Vertex("Adress2", 10, 10),
                new Vertex("Adress3", 10, 10)
            };

            List<Vertex> actual = testAlgorithm.RemoveDuplicates(testList);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Adress, actual[i].Adress);
                Assert.AreEqual(expected[i].XCordinate, actual[i].XCordinate);
                Assert.AreEqual(expected[i].YCordinate, actual[i].YCordinate);
            }
        }
        [TestMethod]
        public void AlgortithTest()
        {
            Vertex startingPoint = new Vertex("Adress1", 0, 0);

            List<Vertex> inputList = new List<Vertex>
            {
                startingPoint,
                new Vertex ("Adress2", -3, -3),
                new Vertex ("Adress3", 1, 2),
                new Vertex ("Adress4", 5, 5),
                new Vertex ("Adress5", 4, 3)
            };
            List<Vertex> expected = new List<Vertex>
            {
                startingPoint,
                new Vertex ("Adress3", 1, 2),
                new Vertex ("Adress5", 4, 3),
                new Vertex ("Adress4", 5, 5),
                new Vertex ("Adress2", -3, -3)
            };

            NearestNeighbour test = new NearestNeighbour();
            Route actual = new Route(test, startingPoint, inputList);

            for (int i = 0; i < actual.sortedRoute.Count; i++)
            {
                Assert.AreEqual(expected[i].Adress, actual.sortedRoute[i].Adress);
                Assert.AreEqual(expected[i].XCordinate, actual.sortedRoute[i].XCordinate);
                Assert.AreEqual(expected[i].YCordinate, actual.sortedRoute[i].YCordinate);
            }
        }
    }

    [TestClass]
    public class RouteTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            NearestNeighbour testAlgorithm = new NearestNeighbour();
            List<Vertex> testUnsortedRoute = new List<Vertex>
            {
                new Vertex("Adress1", 10, 0),
                new Vertex("Adress2", 20, 0 ),
                new Vertex("Adress3", 30, 0)
            };
            Vertex teststartingPoint = new Vertex("Adress1", 10, 0);
            Vertex expectedstartingPoint = new Vertex("Adress1", 10, 0);
            List<Vertex> expectedsortedRoute = new List<Vertex>
            {
                new Vertex("Adress1", 10, 0),
                new Vertex("Adress2", 20, 0),
                new Vertex("Adress3", 30, 0)
            };

            Route actual = new Route(testAlgorithm, teststartingPoint, testUnsortedRoute);

            Assert.AreEqual(expectedstartingPoint.Adress, actual.startingPoint.Adress);
            Assert.AreEqual(expectedstartingPoint.XCordinate, actual.startingPoint.XCordinate);
            Assert.AreEqual(expectedstartingPoint.YCordinate, actual.startingPoint.YCordinate);

            for (int i = 0; i < expectedsortedRoute.Count; i++)
            {
                Assert.AreEqual(expectedsortedRoute[i].Adress, actual.sortedRoute[i].Adress);
                Assert.AreEqual(expectedsortedRoute[i].XCordinate, actual.sortedRoute[i].XCordinate);
                Assert.AreEqual(expectedsortedRoute[i].YCordinate, actual.sortedRoute[i].YCordinate);
            }
        }

        [TestMethod]
        public void ToStringTest()
        {
            NearestNeighbour testAlgorithm = new NearestNeighbour();
            List<Vertex> testUnsortedRoute = new List<Vertex>
            {
                new Vertex("Adress1", 10, 0),
                new Vertex("Adress2", 20, 0),
                new Vertex("Adress3", 30, 0)
            };
            Vertex teststartingPoint = new Vertex("Adress1", 10, 0);
            Route testRoute = new Route(testAlgorithm, teststartingPoint, testUnsortedRoute);
            string expected = "Starting point: Adress1\nCity: Adress2\tDistance from previous: 10\n" +
                              "City: Adress3\tDistance from previous: 10" +
                              "\nCity: Adress1\tDistance from previous: 20" +
                              "\n\nTotal distance: 40";

            string actual = testRoute.ToString();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RouteDistanceTest()
        {
            NearestNeighbour testAlgorithm = new NearestNeighbour();
            List<Vertex> testUnsortedRoute = new List<Vertex>
            {
                new Vertex("Adress1", 10, 0),
                new Vertex("Adress2", 20, 0),
                new Vertex("Adress3", 30, 0)
            };
            Vertex teststartingPoint = new Vertex("Adress1", 10, 0);
            Route testRoute = new Route(testAlgorithm, teststartingPoint, testUnsortedRoute);
            double expected = 40;

            double actual = testRoute.RouteDistance();

            Assert.AreEqual(expected, actual);
        }
    }
}