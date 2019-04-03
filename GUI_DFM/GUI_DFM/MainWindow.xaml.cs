using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        public MainWindow()
        {
             InitializeComponent();
            string filePath = @"C:\Users\Nikif\source\repos\Andersbnv\P2---Pathfinding\GUI_DFM\GUI_DFM\test.txt";

            Graph testGraph = new Graph(filePath);
            InitializeRoute(testGraph.knudeListe);
            
            
        }

        private void InitializeRoute(List<Vertex> sortedVertexList)
        {

            foreach(Vertex vertex in sortedVertexList)
            {
                lstRoute.Items.Add(vertex);
            }
        }

        private void BtnAddPoint_Click(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new AddVertexWindow();
            dialogWindow.Show();
        }

        public void AddPointToRoute(string address, int xCoordinate, int yCoordinate)
        {
            lstRoute.Items.Add($"{address}     X:{xCoordinate}     Y:{yCoordinate}");
        }

        private void BtnRemovePoint_Click(object sender, RoutedEventArgs e)
        {
            lstRoute.Items.RemoveAt(lstRoute.Items.IndexOf(lstRoute.SelectedItem));
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
