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

            Assert.AreEqual(expectedAdress, actual.Address);
            Assert.AreEqual(expectedXCordinate, actual.XCoordinate);
            Assert.AreEqual(expectedYCordinate, actual.YCoordinate);
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

            vertex1.InitializeConnectionList(vertexList);
            List<Edge> actual = vertex1.ConnectionList;

            Assert.AreEqual(expected[1].Weight, 10);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].FirstLocation, actual[i].FirstLocation);
                Assert.AreEqual(expected[i].Weight, actual[i].Weight);
                Assert.AreEqual(expected[i].SecondLocation, actual[i].SecondLocation);
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
            vertex1.InitializeConnectionList(vertexList);
            string expected = "Adress1 X:10 Y:0";

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

            Graph actualGraph = new Graph(filePath);

            for (int i = 0; i < expectededgeList.Count; i++)
            {
                Assert.AreEqual(expectededgeList[i].FirstLocation, actualGraph.EdgeList[i].FirstLocation);
                Assert.AreEqual(expectededgeList[i].Weight, actualGraph.EdgeList[i].Weight);
                Assert.AreEqual(expectededgeList[i].SecondLocation, actualGraph.EdgeList[i].SecondLocation);
            }

            for (int i = 0; i < expectedvertexList.Count; i++)
            {
                Assert.AreEqual(expectedvertexList[i].Address, actualGraph.VertexList[i].Address);
                Assert.AreEqual(expectedvertexList[i].XCoordinate, actualGraph.VertexList[i].XCoordinate);
                Assert.AreEqual(expectedvertexList[i].YCoordinate, actualGraph.VertexList[i].YCoordinate);
            }
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
            string expectedFirstLocation = "Adress1";
            double expectedWeight = 10;
            string expectedSecondLocation = "Adress2";

            Edge actualEdge = new Edge("Adress1", 10, "Adress2");

            Assert.AreEqual(expectedFirstLocation, actualEdge.FirstLocation);
            Assert.AreEqual(expectedWeight, actualEdge.Weight);
            Assert.AreEqual(expectedSecondLocation, actualEdge.SecondLocation);
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
                Assert.AreEqual(expected[i].Address, actual[i].Address);
                Assert.AreEqual(expected[i].XCoordinate, actual[i].XCoordinate);
                Assert.AreEqual(expected[i].YCoordinate, actual[i].YCoordinate);
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

            for (int i = 0; i < actual.SortedRoute.Count; i++)
            {
                Assert.AreEqual(expected[i].Address, actual.SortedRoute[i].Address);
                Assert.AreEqual(expected[i].XCoordinate, actual.SortedRoute[i].XCoordinate);
                Assert.AreEqual(expected[i].YCoordinate, actual.SortedRoute[i].YCoordinate);
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

            Assert.AreEqual(expectedstartingPoint.Address, actual.StartingPoint.Address);
            Assert.AreEqual(expectedstartingPoint.XCoordinate, actual.StartingPoint.XCoordinate);
            Assert.AreEqual(expectedstartingPoint.YCoordinate, actual.StartingPoint.YCoordinate);

            for (int i = 0; i < expectedsortedRoute.Count; i++)
            {
                Assert.AreEqual(expectedsortedRoute[i].Address, actual.SortedRoute[i].Address);
                Assert.AreEqual(expectedsortedRoute[i].XCoordinate, actual.SortedRoute[i].XCoordinate);
                Assert.AreEqual(expectedsortedRoute[i].YCoordinate, actual.SortedRoute[i].YCoordinate);
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