using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_DFM
{
    class Item
    {
        public string adress { get; set; }
        public double xCordinate { get; set; }
        public double yCordinate { get; set; }

        public Item(string adress, double xCordinate, double yCordinate)
        {
            this.adress = adress;
            this.xCordinate = xCordinate;
            this.yCordinate = yCordinate;
        }
    }
}
