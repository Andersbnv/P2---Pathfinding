using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GUI_DFM.Route_Sorting_Algorithms;
using GUI_DFM.GreedyTwoOpt;

namespace GUI_DFM
{
    public partial class MainWindow : Window
    {
        public Graph graph;
        public Route route;
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            string filePath = @"..\..\addresses.txt";
            graph = new Graph(filePath);
            route = new Route(graph.vertexList, graph.vertexList.ElementAt(0));
            lstRoute.ItemsSource = route.routeList;
        }
        private void UpdateListBox()
        {
            lstRoute.ItemsSource = route.routeList;
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
            IRouteAlgorithm routeAlgorithm = new GreedyTwoOpt.GreedyTwoOpt();
            route.CalculateRoute(routeAlgorithm);
            lstRoute.ItemsSource = route.routeList;
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
        private void TxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox target = (TextBox)sender;
            target.Clear();
        }
    }
}
