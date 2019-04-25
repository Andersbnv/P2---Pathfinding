using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Shapes;

namespace GUI_DFM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Graph graph;
        public string filePath = @"C:\Users\Nikif\source\repos\Andersbnv\P2---Pathfinding\GUI_DFM\GUI_DFM\test.txt";
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            string filePath = String.Concat(Environment.CurrentDirectory, "\\test.txt");
            graph = new Graph(filePath);
            InitializeRoute(graph.VertexList);
            
        }

        private void InitializeRoute(List<Vertex> sortedVertexList)
        {

            foreach(Vertex vertex in sortedVertexList)
            {
                routeListElements.Add(vertex);
            }
            lstRoute.ItemsSource = routeListElements;
        }
        private void UpdateRouteList(List<Vertex> VertexList)
        {
            routeListElements.Clear();
            foreach (Vertex vertex in VertexList)
            {
                routeListElements.Add(vertex);
            }
        }

        private void BtnAddPoint_Click(object sender, RoutedEventArgs e)
        {
            bool hasInput = (txtAddress.Text.Length > 0) && (txtXCoordinate.Text.Length > 0) && (txtYCoordinate.Text.Length > 0);

            if(hasInput)
            {
                var vertexToBeAdded = new Vertex(txtAddress.Text, int.Parse(txtXCoordinate.Text), int.Parse(txtYCoordinate.Text));
                graph.AddVertex(vertexToBeAdded);
                graph.AddEdge(vertexToBeAdded);
                UpdateRouteList(graph.VertexList);

                txtAddress.Text = "";
                txtXCoordinate.Text = "";
                txtYCoordinate.Text = "";
            }
            else
            {
                MessageBox.Show("Indskriv venligst det punkt, som ønskes tilføjet til listen.");
            }
        }

        private void BtnRemovePoint_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lstRoute.Items.IndexOf(lstRoute.SelectedItem);

            if (selectedIndex < 0)
            {
                MessageBox.Show("Marker venligst det punkt i listen, som ønskes slettet.");
            }
            else
            {
                routeListElements.RemoveAt(selectedIndex);
            }
        }

        private void BtnCalculateRoute_Click(object sender, RoutedEventArgs e)
        {
            RouteAlgorithm algorithNearestNeighbour = new NearestNeighbour();
            Route calculatedRoute = new Route(algorithNearestNeighbour, graph.VertexList.ElementAt(0), graph.VertexList);
            UpdateRouteList(calculatedRoute.SortedRoute);
        }

        private void Route_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Route_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
