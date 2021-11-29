using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSAC_Client
{
    public class TeamOrder
    {
        public int id { get; set; }
        public string date { get; set; }
        public int total_price { get; set; }
        public int id_team { get; set; }
        public int delivered { get; set; }
        public List<Product> products { get; set; }
    }
}
