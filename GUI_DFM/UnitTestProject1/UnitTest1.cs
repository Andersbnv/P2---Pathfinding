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
            var actual = testRoute.routeList.ElementAt(1);

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
            var actual = testRoute.routeList.ElementAt(0);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveFromListTest_ListWithZeroElement()
        {
            List<Vertex> testList = new List<Vertex>();
            Route testRoute = new Route(testList, new Vertex("startPoint", 2, 3));
            testRoute.RemoveFromList(0);
            var expected = 0;
            var actual = testRoute.routeList.Count;
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
    }
    [TestClass]
    public class HandyMethodsTest
    {
        [TestMethod]
        public void ReadFileTest()
        {
            string filePath = @"..\..\HandyMethodsTestFile.txt";
            List<string> fileLines = filePath.ReadFile();

            string expected1 = "Aalborg,1,2";
            string expected2 = "Esbjerg,3,4";

            string actual1 = fileLines[0];
            string actual2 = fileLines[1];

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void FileToVertexListTest()
        {
            string filePath = @"..\..\HandyMethodsTestFile.txt";
            List<Vertex> vertexList = filePath.FileToVertexList();

            string expected1 = "Aalborg";
            string expected2 = "Esbjerg";

            string actual1 = vertexList[0].address;
            string actual2 = vertexList[1].address;

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        
        
    }
    [TestClass]
    public class VertexTest
    {

        [TestMethod]
        public void VertexConstructorTest()
        {
            Vertex e = new Vertex("Aalborg", 1.1, 2.2);

            var expected1 = "Aalborg";
            var expected2 = 1.1;
            var expected3 = 2.2;

            var actual1 = e.address;
            var actual2 = e.xCoordinate;
            var actual3 = e.yCoordinate;

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        public void VertexDistanceTest_PossitiveCoordinates()
        {
            Vertex v = new Vertex("Aalborg", 1, 2);
            Vertex k = new Vertex("Aarhus", 2, 1);


            var expected = Math.Sqrt((2-1) * (2-1) + (1-2) * (1-2));

            var actual = v.DistanceToVertex(k);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VertexDistanceTest_NegativeCoordinates()
        {
            Vertex v = new Vertex("Aalborg", -1, -2);
            Vertex k = new Vertex("Aarhus", -2, -1);


            var expected = Math.Sqrt(((-2)-(-1)) * ((-2)-(-1)) + ((-1)-(-2)) * ((-1)-(-2)));

            var actual = v.DistanceToVertex(k);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VertexDistanceTest_ZeroCoordinates()
        {
            Vertex v = new Vertex("Aalborg", 0, 0);
            Vertex k = new Vertex("Aarhus", 0, 0);


            var expected = 0;

            var actual = v.DistanceToVertex(k);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Vertex testVertex = new Vertex("Address0", 0, 0);
            var expected = "Address0 X:0 Y:0";
            var actual = testVertex.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class AddPointValidationTest
    {
        string emptyString = "", letterString = "Test", numberString = "123";

        [TestMethod]
        public void HasErrorsTest_and_GetErrorMessageTest_noInput()
        {
            var TestValidation = new AddPointValidation(emptyString, emptyString, emptyString);
            var expectedMessage = "Indskriv venligst et bynavn (bogstaver).\nIndskriv venligst et x-koordinat (tal).\nIndskriv venligst et y-koordinat (tal).\n";
            var actualMessage = TestValidation.GetErrorMessage();
            Assert.IsTrue(TestValidation.HasErrors());
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void HasErrorsTest_and_GetErrorMessageTest_noAdress()
        {
            var TestValidation = new AddPointValidation(emptyString, numberString, numberString);
            var expectedMessage = "Indskriv venligst et bynavn (bogstaver).\n";
            var actualMessage = TestValidation.GetErrorMessage();
            Assert.IsTrue(TestValidation.HasErrors());
            Assert.AreEqual(expectedMessage, actualMessage);        
        }
        [TestMethod]
        public void HasErrorsTest_and_GetErrorMessageTest_noXCoordinate()
        {
            var TestValidation = new AddPointValidation(letterString, emptyString, numberString);
            var expectedMessage = "Indskriv venligst et x-koordinat (tal).\n";
            var actualMessage = TestValidation.GetErrorMessage();
            Assert.IsTrue(TestValidation.HasErrors());
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void HasErrorsTest_and_GetErrorMessageTest_noYCoordinate()
        {
            var TestValidation = new AddPointValidation(letterString, numberString, emptyString);
            var expectedMessage = "Indskriv venligst et y-koordinat (tal).\n";
            var actualMessage = TestValidation.GetErrorMessage();
            Assert.IsTrue(TestValidation.HasErrors());
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void HasErrorsTest_and_GetErrorMessageTest_AdressNotLetters()
        {
            var TestValidation = new AddPointValidation(numberString, numberString, numberString);
            var expectedMessage = "Bynavn må kun indeholde bogstaver.\n";
            var actualMessage = TestValidation.GetErrorMessage();
            Assert.IsTrue(TestValidation.HasErrors());
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void HasErrorsTest_and_GetErrorMessageTest_xCoordinateNotNumber()
        {
            var TestValidation = new AddPointValidation(letterString, letterString, numberString);
            var expectedMessage = "X-koordinat må kun indeholde tal.\n";
            var actualMessage = TestValidation.GetErrorMessage();
            Assert.IsTrue(TestValidation.HasErrors());
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void HasErrorsTest_and_GetErrorMessageTest_yCoordinateNotNumber()
        {
            var TestValidation = new AddPointValidation(letterString, numberString, letterString);
            var expectedMessage = "Y-koordinat må kun indeholde tal.\n";
            var actualMessage = TestValidation.GetErrorMessage();
            Assert.IsTrue(TestValidation.HasErrors());
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void HasErrorsTest_and_GetErrorMessageTest_allValidInput()
        {
            var TestValidation = new AddPointValidation(letterString, numberString, numberString);
            var expectedMessage = "";
            var actualMessage = TestValidation.GetErrorMessage();
            Assert.IsFalse(TestValidation.HasErrors());
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
    [TestClass]
    public class Greedy2OptimizationAlgorithmTest
    {
        [TestMethod]
        public void TwoOptTest()
        {
            Vertex Test1 = new Vertex("Test1", 1, 2);
            Vertex Test2 = new Vertex("Test2", 2, 1);
            Vertex Test3 = new Vertex("Test3", 15, 20);
            Vertex Test4 = new Vertex("Test 4", 2, 4);
            Vertex Test5 = new Vertex("Test 5", 4, 2);
            Vertex Test6 = new Vertex("Test 6", 12, 8);
            Vertex Test7 = new Vertex("Test 7", -10, 6);

            var unsortedList = new List<Vertex> { };
            unsortedList.Add(Test2);
            unsortedList.Add(Test1);
            unsortedList.Add(Test3);
            unsortedList.Add(Test4);
            unsortedList.Add(Test5);
            unsortedList.Add(Test7);
            unsortedList.Add(Test6);


            GreedyTwoOpt c = new GreedyTwoOpt();
            var actual = c.Algorithm(Test1, unsortedList);

            var expectedOptimalWeight = 69.07;
            double actualWeight = 0;
            for (int i = 0; i < actual.Count - 1; i++)
            {
                actualWeight += actual[i].DistanceToVertex(actual[i + 1]);
            }
            actualWeight += actual.Last().DistanceToVertex(actual.First());

            Assert.IsTrue(actualWeight < expectedOptimalWeight * 1.01);
        }
    }


}
