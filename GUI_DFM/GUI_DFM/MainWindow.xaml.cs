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
            string filePath = @"C:\Users\Nikif\source\repos\Andersbnv\P2---Pathfinding\GUI_DFM\GUI_DFM\test.txt";

            Graph testGraph = new Graph(filePath);

            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
      

        }

        private void Route_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Route_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
