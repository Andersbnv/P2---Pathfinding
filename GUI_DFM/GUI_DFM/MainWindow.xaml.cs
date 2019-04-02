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
            string filePath = @"\\vmware-host\Shared Folders\Desktop\Text.txt";

            Graph testGraph = new Graph(filePath);

            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            route.Items.Add("AHello");
            route.Items.Add("BHello");
            route.Items.Add("CHello");
            route.Items.Add("DHello");
            route.Items.Add("EHello");
            route.Items.Add("FHello");

        }
    }
}
