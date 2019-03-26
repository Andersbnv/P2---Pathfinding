using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_CA
{
    class Relation
    {
        public List<Tuple<string, int, string>> RelatiionList = new List<Tuple<string, int, string>>();

        public void GetRelation(string adress1, int weight, string adress2)
        {
          RelatiionList.Add(Tuple.Create(adress1, weight, adress2));
        }

    }
}
