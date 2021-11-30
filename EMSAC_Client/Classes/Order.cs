using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSAC_Client
{
    public class Order
    {
        DateTime date;
        int id_team;
        List<ProductOrder> products;

        public Order( DateTime d, int team, List<ProductOrder> pr)
        {
            date = d;
            id_team = team;
            products = pr;
        }

        public Order()
        {
        }

        public DateTime Date
        {
            get => date;
            set => date = value;
        }
        
        public int Id_team
        {
            get => id_team;
            set => id_team = value;
        }

        public List<ProductOrder> Products
        {
            get => products;
            set => products = value;
        }
    }
}
