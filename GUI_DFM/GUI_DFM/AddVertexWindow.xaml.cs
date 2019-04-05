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
using System.Windows.Shapes;

namespace GUI_DFM
{
    /// <summary>
    /// Interaction logic for AddVertexWindow.xaml
    /// </summary>
    public partial class AddVertexWindow : Window
    {
        public AddVertexWindow()
        {
            InitializeComponent();
        }

        private void TxtYCoordinate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string address = txtAdress.Text;
            int xCoordinate = int.Parse(txtXCoordinate.Text);
            int yCoordinate = int.Parse(txtYCoordinate.Text);
        }
    }
}
