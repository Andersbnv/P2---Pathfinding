using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUI_DFM;
using System.Collections.Generic;
using System.Linq;


namespace UnitTest
{
    [TestClass]
    public class RouteTest
    {
        [TestMethod]
        public void RouteDistanceTest_PostitiveCoordinates()
        {
            List<Vertex> routeList = new List<Vertex>
            {
                new Vertex("Adress1", 1, 2),
                new Vertex("Adress2", 2, 3),
                new Vertex("Adress3", 6, 5),
                new Vertex("Adress4", 7, 5),
                new Vertex("Adress5", 10, 5)
            };


            Route route = new Route(routeList, routeList.ElementAt(0));

            double expected = (
                                Math.Sqrt(Math.Pow((2 - 1), 2) + Math.Pow((3 - 2), 2)) +
                                Math.Sqrt(Math.Pow((6 - 2), 2) + Math.Pow((5 - 3), 2)) +
                                Math.Sqrt(Math.Pow((7 - 6), 2) + Math.Pow((5 - 5), 2)) +
                                Math.Sqrt(Math.Pow((10 - 7), 2) + Math.Pow((5 - 5), 2)) +
                                Math.Sqrt(Math.Pow((1 - 10), 2) + Math.Pow((2 - 5), 2))
                              );

            double actual = route.RouteDistance();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RouteDistanceTest_NegativeCoordinates()
        {
            List<Vertex> routeList = new List<Vertex>
            {
                new Vertex("Adress1", -1, -2),
                new Vertex("Adress2", -2, -3),
                new Vertex("Adress3", -6, -5),
                new Vertex("Adress4", -7, -5),
                new Vertex("Adress5", -10, -5)
            };


            Route route = new Route(routeList, routeList.ElementAt(0));

            double expected = (
                                Math.Sqrt(Math.Pow(((-2) - (-1)), 2) + Math.Pow(((-3) - (-2)), 2)) +
                                Math.Sqrt(Math.Pow(((-6) - (-2)), 2) + Math.Pow(((-5) - (-3)), 2)) +
                                Math.Sqrt(Math.Pow(((-7) - (-6)), 2) + Math.Pow(((-5) - (-5)), 2)) +
                                Math.Sqrt(Math.Pow(((-10) - (-7)), 2) + Math.Pow(((-5) - (-5)), 2)) +
                                Math.Sqrt(Math.Pow(((-1) - (-10)), 2) + Math.Pow(((-2) - (-5)), 2))
                              );

            double actual = route.RouteDistance();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddToListTest_ListWithOneElement()
        {
            var testVertex = new Vertex("Address2", 4, 5);

            List<Vertex> testList = new List<Vertex>
            {
                new Vertex("Address1", 3, 4)
            };

            Route testRoute = new Route(testList, testList.ElementAt(0));
            testRoute.AddToList(testVertex);

            var expected = testVertex;
            var actual = testRoute.RouteList.ElementAt(1);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddToListTest_ListWithZeroElements()
        {
            var testVertex = new Vertex("Address1", 4, 5);
            var startPoint = new Vertex("Address2", 2, 2);

            List<Vertex> testList = new List<Vertex>();

            Route testRoute = new Route(testList, startPoint);
            testRoute.AddToList(testVertex);

            var expected = testVertex;
            var actual = testRoute.RouteList.ElementAt(0);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveFromListTest_ListWithZeroElement()
        {
            List<Vertex> testList = new List<Vertex>();
            Route testRoute = new Route(testList, new Vertex("startPoint", 2, 3));
            bool caughtException = false;
            try
            {
                testRoute.RemoveFromList(0);
            }
            catch
            {
                caughtException = true;
            }

            var expected = true;
            var actual = caughtException;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveFromListTest_ListWithOneElement()
        {


            List<Vertex> testList = new List<Vertex>
            {
                new Vertex("Address1", 3, 4)
            };

            Route testRoute = new Route(testList, testList.ElementAt(0));
            testRoute.RemoveFromList(0);

            var expected = 0;
            var actual = testList.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveFromListTest_ListWithTwoElement()
        {


            List<Vertex> testList = new List<Vertex>
            {
                new Vertex("Address1", 3, 4),
                new Vertex("Address1", 3, 4)
            };

            Route testRoute = new Route(testList, testList.ElementAt(0));
            testRoute.RemoveFromList(1);

            var expected = 1;
            var actual = testList.Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MoveUpElementTest_ElementInMiddleOfList()
        {
            Vertex testVertex0 = new Vertex("Adress1", 3, 4);
            Vertex testVertex1 = new Vertex("Adress2", 8, 6);
            Vertex testVertex2 = new Vertex("Adress2", 9, 12);
            List<Vertex> testList = new List<Vertex>
            {
                testVertex0,
                testVertex1,
                testVertex2
            };
            Route route = new Route(testList, testList.ElementAt(0));
            route.MoveUpElement(1);
            var actual_0 = testList.ElementAt(0);
            var actual_1 = testList.ElementAt(1);
            var actual_2 = testList.ElementAt(2);
            var expected_0 = testVertex1;
            var expected_1 = testVertex0;
            var expected_2 = testVertex2;

            Assert.AreEqual(expected_0, actual_0);
            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
        }
        [TestMethod]
        public void MoveUpElementTest_ElementInStartOfList()
        {
            Vertex testVertex0 = new Vertex("Adress1", 3, 4);
            Vertex testVertex1 = new Vertex("Adress2", 8, 6);
            Vertex testVertex2 = new Vertex("Adress3", 5, 9);
            List<Vertex> testList = new List<Vertex>
            {
                testVertex0,
                testVertex1,
                testVertex2
            };

            Route route = new Route(testList, testList.ElementAt(0));
            route.MoveUpElement(0);
            var actual_0 = testList.ElementAt(0);
            var actual_1 = testList.ElementAt(1);
            var actual_2 = testList.ElementAt(2);
            var expected_0 = testVertex1;
            var expected_1 = testVertex2;
            var expected_2 = testVertex0;

            Assert.AreEqual(expected_0, actual_0);
            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
        }
        [TestMethod]
        public void MoveDownElementTest_ElementInMiddleOfList()
        {
            Vertex testVertex0 = new Vertex("Adress1", 3, 4);
            Vertex testVertex1 = new Vertex("Adress2", 8, 6);
            Vertex testVertex2 = new Vertex("Adress3", 5, 9);
            List<Vertex> testList = new List<Vertex>
            {
                testVertex0,
                testVertex1,
                testVertex2
            };

            Route route = new Route(testList, testList.ElementAt(0));
            route.MoveDownElement(0, testList.Count);

            var actual_0 = testList.ElementAt(0);
            var actual_1 = testList.ElementAt(1);
            var actual_2 = testList.ElementAt(2);
            var expected_0 = testVertex1;
            var expected_1 = testVertex0;
            var expected_2 = testVertex2;

            Assert.AreEqual(expected_0, actual_0);
            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
        }
        [TestMethod]
        public void MoveDownElementTest_ElementInEndOfList()
        {
            Vertex testVertex0 = new Vertex("Adress1", 3, 4);
            Vertex testVertex1 = new Vertex("Adress2", 8, 6);
            Vertex testVertex2 = new Vertex("Adress3", 5, 9);
            List<Vertex> testList = new List<Vertex>
            {
                testVertex0,
                testVertex1,
                testVertex2
            };

            Route route = new Route(testList, testList.ElementAt(0));
            route.MoveDownElement(2, testList.Count);

            var actual_0 = testList.ElementAt(0);
            var actual_1 = testList.ElementAt(1);
            var actual_2 = testList.ElementAt(2);
            var expected_0 = testVertex2;
            var expected_1 = testVertex0;
            var expected_2 = testVertex1;

            Assert.AreEqual(expected_0, actual_0);
            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
        }
        [TestMethod]
        public void CalculateRouteTest()
        {
            Vertex testVertex0 = new Vertex("Adress0", 3, 4);
            Vertex testVertex1 = new Vertex("Adress1", 8, 6);
            Vertex testVertex2 = new Vertex("Adress2", 7, 9);
            Vertex testVertex3 = new Vertex("Adress3", 1, 9);
            Vertex testVertex4 = new Vertex("Adress4", 5, 2);
            Vertex testVertex5 = new Vertex("Adress5", 2, 4);
            Vertex testVertex6 = new Vertex("Adress6", 3, 3);
            Vertex testVertex7 = new Vertex("Adress7", 8, 7);
            Vertex testVertex8 = new Vertex("Adress8", 8, 6);
            Vertex testVertex9 = new Vertex("Adress9", 4, 9);          

            List<Vertex> testList = new List<Vertex>
            {
                testVertex0,
                testVertex1,
                testVertex2,
                testVertex3,
                testVertex4,
                testVertex5,
                testVertex6,
                testVertex7,
                testVertex8,
                testVertex9
            };
            Route route_0 = new Route(testList, testList.ElementAt(0));
            Route route_1 = new Route(testList, testList.ElementAt(0));
            RouteAlgorithm testAlgorithm = new NearestNeighbour();
            route_0.RouteList = testAlgorithm.Algorithm(testList.ElementAt(0), route_0.RouteList);
            route_1.CalculateRoute(testAlgorithm);

            var expected_0 = route_0.RouteList.ElementAt(0);
            var expected_1 = route_0.RouteList.ElementAt(1);
            var expected_2 = route_0.RouteList.ElementAt(2);
            var expected_3 = route_0.RouteList.ElementAt(3);
            var expected_4 = route_0.RouteList.ElementAt(4);
            var expected_5 = route_0.RouteList.ElementAt(5);
            var expected_6 = route_0.RouteList.ElementAt(6);
            var expected_7 = route_0.RouteList.ElementAt(7);
            var expected_8 = route_0.RouteList.ElementAt(8);
            var expected_9 = route_0.RouteList.ElementAt(9);            

            var actual_0 = route_1.RouteList.ElementAt(0);
            var actual_1 = route_1.RouteList.ElementAt(1);
            var actual_2 = route_1.RouteList.ElementAt(2);
            var actual_3 = route_1.RouteList.ElementAt(3);
            var actual_4 = route_1.RouteList.ElementAt(4);
            var actual_5 = route_1.RouteList.ElementAt(5);
            var actual_6 = route_1.RouteList.ElementAt(6);
            var actual_7 = route_1.RouteList.ElementAt(7);
            var actual_8 = route_1.RouteList.ElementAt(8);
            var actual_9 = route_1.RouteList.ElementAt(9);

            Assert.AreEqual(expected_0, actual_0);
            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
            Assert.AreEqual(expected_3, actual_3);
            Assert.AreEqual(expected_4, actual_4);
            Assert.AreEqual(expected_5, actual_5);
            Assert.AreEqual(expected_6, actual_6);
            Assert.AreEqual(expected_7, actual_7);
            Assert.AreEqual(expected_8, actual_8);
            Assert.AreEqual(expected_9, actual_9);
        }
    }
    [TestClass]
    public class RouteAlgorithmTest
    {
        [TestMethod]
        public void ListToMatrixTest()
        {
            List<Vertex> testList = new List<Vertex>
            {
                new Vertex("Adress1", 3, 4),
                new Vertex("Adress2", 6, 8),
                new Vertex("Adress3", 9, 12)
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
    public class VertexTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            Vertex testVertex = new Vertex("Address0", 0, 0);
            var expected = "Address0 X:0 Y:0";
            var actual = testVertex.ToString();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InitializeConnectionListTest()
        {
            List<Vertex> vertexList = new List<Vertex>
            {
                new Vertex("address1", 1, 2),
                new Vertex("address2", 2, 3),
                new Vertex("address3", 6, 5),
                new Vertex("address4", 7, 5),
                new Vertex("address5", 10, 5)
            };
            var edge = new Edge(vertexList[0].Address, vertexList[0].DistanceToVertex(vertexList[3]), vertexList[3].Address);
            
            vertexList[0].InitializeConnectionList(vertexList);
            var actual1 = vertexList.ElementAt(0).ConnectionList.ElementAt(3).FirstLocation;
            var actual2 = vertexList.ElementAt(0).ConnectionList.ElementAt(3).Weight;
            var actual3 = vertexList.ElementAt(0).ConnectionList.ElementAt(3).SecondLocation;

            var expected1 = edge.FirstLocation;
            var expected2 = edge.Weight;
            var expected3 = edge.SecondLocation;

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

    }
    [TestClass]
    public class GraphTest
    {
        [TestMethod]
        public void GraphConstructorTest()
        {
            string filePath = @"..\..\..\GUI_DFM\test.txt";
            Graph testGraph = new Graph(filePath);

            var expected_address_0 = "Aalborg";
            var expected_xCoordinate_0 = 0;
            var expected_yCoordinate_0 = 0;

            var actual_address_0 = testGraph.VertexList.ElementAt(0).Address;
            var actual_xCoordinate_0 = testGraph.VertexList.ElementAt(0).XCoordinate;
            var actual_yCoordinate_0 = testGraph.VertexList.ElementAt(0).YCoordinate;

            Assert.AreEqual(expected_address_0, actual_address_0);
            Assert.AreEqual(expected_xCoordinate_0, actual_xCoordinate_0);
            Assert.AreEqual(expected_yCoordinate_0, actual_yCoordinate_0);

        }
    }
  

}
