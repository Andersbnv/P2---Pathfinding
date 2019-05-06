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
using System.Text.RegularExpressions;


namespace GUI_DFM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Graph graph;
        public Route route;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            string filePath = @"..\..\test.txt";
            graph = new Graph(filePath);
            route = new Route(graph.VertexList, graph.VertexList.ElementAt(1));
            lstRoute.ItemsSource = route.RouteList;
        }
        private void UpdateListBox()
        {
            lstRoute.ItemsSource = route.RouteList;
        }
        private void ClearListBox()
        {
            lstRoute.ItemsSource = null;
        }

        private void BtnAddPoint_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = txtAddress.Text == "Indtast navn" ? "" : txtAddress.Text;
            txtXCoordinate.Text = txtXCoordinate.Text == "Indtast x" ? "" : txtXCoordinate.Text;
            txtYCoordinate.Text = txtYCoordinate.Text == "Indtast y" ? "" : txtYCoordinate.Text;

            var inputValidation = new AddPointValidation(txtAddress.Text, txtXCoordinate.Text, txtYCoordinate.Text);
            if (inputValidation.HasErrors())
            {
                MessageBox.Show(inputValidation.GetErrorMessage());
            }
            else
            {
                var vertexToBeAdded = new Vertex(txtAddress.Text, int.Parse(txtXCoordinate.Text), int.Parse(txtYCoordinate.Text));
                ClearListBox();
                route.AddToList(vertexToBeAdded);
                UpdateListBox();
            }
            txtAddress.Text = "Indtast navn";
            txtXCoordinate.Text = "Indtast x";
            txtYCoordinate.Text = "Indtast y";
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
                ClearListBox();
                route.RemoveFromList(selectedIndex);
                UpdateListBox();
            }
        }
        private void BtnCalculateRoute_Click(object sender, RoutedEventArgs e)
        {
            cnvsCalculating.Opacity = 1;
            Panel.SetZIndex(cnvsCalculating, 1);
            RouteAlgorithm nearestNeighbour = new NearestNeighbour();
            route.CalculateRoute(nearestNeighbour);
            lstRoute.ItemsSource = route.RouteList;

        }
        private void BtnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lstRoute.Items.IndexOf(lstRoute.SelectedItem);
            int listCount = lstRoute.Items.Count;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Marker venligst et punkt");
            }
            else
            {
                ClearListBox();
                route.MoveDownElement(selectedIndex, listCount);
                UpdateListBox();
                if (selectedIndex == lstRoute.Items.Count - 1)
                {
                    lstRoute.SelectedItem = lstRoute.Items.GetItemAt(0);
                }
                else
                {
                    lstRoute.SelectedItem = lstRoute.Items.GetItemAt(selectedIndex + 1);

                }
            }
        }
        private void BtnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lstRoute.Items.IndexOf(lstRoute.SelectedItem); 
            if (selectedIndex < 0)
            {
                MessageBox.Show("Marker venligst et punkt");
            }
            else
            {
                ClearListBox();
                route.MoveUpElement(selectedIndex);
                UpdateListBox();
                if (selectedIndex == 0)
                {
                    lstRoute.SelectedItem = lstRoute.Items.GetItemAt(lstRoute.Items.Count - 1);
                }
                else
                {
                    lstRoute.SelectedItem = lstRoute.Items.GetItemAt(selectedIndex - 1);
                }
            }
        }
        private void LstRoute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox target = (TextBox)sender;
            target.Clear();
        }

        private void Btn_MouseEnter(object sender, RoutedEventArgs e)
        {
            Button target = (Button)sender;
            target.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0, 0));
        }

    }
}
