using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_CA
{
    public class Program
    {
        static void Main(string[] args)
        {
            Knuder P0 = new Knuder("Rørdalsvej 201");
            Knuder P1 = new Knuder("P1vej 2");
            Knuder P2 = new Knuder("P2vej 3");
            Knuder P3 = new Knuder("P3vej 4");

            Relation R = new Relation();

            R.GetRelation(P0.Adress, 0, P0.Adress);
            R.GetRelation(P0.Adress, 1, P1.Adress);
            R.GetRelation(P0.Adress, 2, P2.Adress);
            R.GetRelation(P0.Adress, 3, P3.Adress);
            R.GetRelation(P1.Adress, 0, P1.Adress);
            R.GetRelation(P1.Adress, 4, P2.Adress);
            R.GetRelation(P1.Adress, 5, P3.Adress);
            R.GetRelation(P2.Adress, 0, P2.Adress);
            R.GetRelation(P2.Adress, 3, P3.Adress);
            R.GetRelation(P3.Adress, 0, P3.Adress);

            foreach (var item in R.RelatiionList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

