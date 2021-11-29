using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using System.Xml;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace EMSAC_WEBAPI.Model
{
    public class Order
    {
        int id;
        DateTime date;
        float total_price;
        int id_team;
        int delivered;
        List<ProductOrder> products;

        public Order(int i, DateTime d, float p, int team, int del, List<ProductOrder> pr)
        {
            id = i;
            date = d;
            total_price = p;
            id_team = team;
            delivered = del;
            products = pr;
        }

        public Order()
        {
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public DateTime Date
        {
            get => date;
            set => date = value;
        }
        public float Total_price
        {
            get => total_price;
            set => total_price = value;
        }

        public int Id_team
        {
            get => id_team;
            set => id_team = value;
        }

        public int Delivered
        {
            get => delivered;
            set => delivered = value;
        }

        public List<ProductOrder> Products
        {
            get => products;
            set => products = value;
        }

    }

    public class Team
    {
        int id;
        string label;

        public Team(int i, string l)
        {
            id = i;
            label = l;
        }

        public Team()
        {
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Label
        {
            get => label;
            set => label = value;
        }

    }

    public class TeamCost
    {
        int id;
        string label;
        float cost;

        public TeamCost(int i, string l, float c)
        {
            id = i;
            label = l;
            cost = c;
        }

        public TeamCost()
        {
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Label
        {
            get => label;
            set => label = value;
        }

        public float Cost
        {
            get => cost;
            set => cost = value;
        }

    }

    public class Product
    {
        private int id;
        private string label;
        private float unitPrice;

        public Product(int i, string l, float price)
        {
            this.Id = i;
            this.Label = l;
            this.UnitPrice = price;
        }

        public Product()
        {
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Label
        {
            get => label;
            set => label = value;
        }

        public float UnitPrice
        {
            get => unitPrice;
            set => unitPrice = value;
        }
    }

    public class Delivery
    {
        int id;
        DateTime date;
        int id_order;

        public Delivery(int i, DateTime d, int order)
        {
            id = i;
            date = d;
            id_order = order;
        }

        public Delivery()
        {
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public DateTime Date
        {
            get => date;
            set => date = value;
        }

        public int Id_order
        {
            get => id_order;
            set => id_order = value;
        }
    }

    public class ProductOrder
    {
        int id_product;
        float unitPrice;
        int quantity;

        public ProductOrder(int id_p, int q, float uPrice)
        {
            id_product = id_p;
            quantity = q;
            unitPrice = uPrice;
        }

        public ProductOrder(int id_p, int q)
        {
            id_product = id_p;
            quantity = q;
            unitPrice = 0;
        }

        public ProductOrder()
        {
        }

        public int Id_product
        {
            get => id_product;
            set => id_product = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public float UnitPrice
        {
            get => unitPrice;
            set => unitPrice = value;
        }
    }

    public class ProductSelled
    {
        int id;
        int quantity;
        string label;

        public ProductSelled(int i, int q, string l)
        {
            id = i;
            quantity = q;
            label = l;
        }
        public ProductSelled()
        {
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public string Label
        {
            get => label;
            set => label = value;
        }
    }

    public class Orders
    {

        #region Management Methods

        /// <summary>
        /// Obter a histórico de requisições por parte de uma equipa
        /// </summary>
        /// <param name="team_id">Código associado à equipa</param>
        /// <returns>Lista de requisições efetuadas</returns>
        public List<Order> GetTeamOrders(int team_id)
        {
            List<Order> l = new List<Order>();
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMSAC;Integrated Security=True;MultipleActiveResultSets=True";

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                //3º Query
                string q = "SELECT * FROM orders WHERE id_team = @id_team";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);

                //Instancia parâmetros
                co.Parameters.Add("@id_team", SqlDbType.Int);
                co.Parameters["@id_team"].Value = team_id;

                con.Open();
                //Lê dados
                using (SqlDataReader read = co.ExecuteReader())
                {
                    while (read.Read())
                    {
                        int currentId = Int32.Parse(read["id"].ToString());

                        string q2 = "SELECT * FROM product_order WHERE id_order = @id_order;";
                        SqlCommand co2 = new SqlCommand(q2, con);

                        //Instancia parâmetros
                        co2.Parameters.Add("@id_order", SqlDbType.Int);
                        co2.Parameters["@id_order"].Value = currentId;

                        List<ProductOrder> prList = new List<ProductOrder>();
                        using (SqlDataReader read2 = co2.ExecuteReader())
                        {
                            while (read2.Read())
                            {
                                prList.Add(new ProductOrder(Int32.Parse(read2["id_product"].ToString()), Int32.Parse(read2["quantity"].ToString())));
                            }
                        }

                        Order o = new Order(currentId, DateTime.Parse(read["date"].ToString()), float.Parse(read["total_price"].ToString()), Int32.Parse(read["id_team"].ToString()), Int32.Parse(read["delivered"].ToString()), prList);
                        l.Add(o);
                    }
                    con.Close();
                }
                Trace.WriteLine(l.Count());
                return l;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return l;
            }
        }

        public List<Product> GetProductList()
        {
            string t;
            List<Product> list = new List<Product>();
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMSAC;Integrated Security=True";

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                //3º Query
                string q = "SELECT * FROM product;";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);

                //Lê dados
                con.Open();
                using (SqlDataReader read = co.ExecuteReader())
                {
                    while (read.Read())
                    {
                        list.Add(new Product(Int32.Parse(read["id"].ToString()), read["label"].ToString(), float.Parse(read["unitPrice"].ToString())));
                    }
                    con.Close();
                }
                return list;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return list;
            }
        }

        public bool CreateNewOrder(Order or)
        {
            float price = 0;
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();
                //1º ConnectionString
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMSAC;Integrated Security=True";
                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);
                //3º Query
                string q = "insert into orders (date, id_team) " +
                    " output inserted.id " +
                    "values(@date, @team_id);";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);

                //Instancia parâmetros
                co.Parameters.Add("@date", SqlDbType.NChar);
                co.Parameters["@date"].Value = or.Date.Day+"/"+or.Date.Month + "/"+or.Date.Year;
                
                co.Parameters.Add("@team_id", SqlDbType.Int);
                co.Parameters["@team_id"].Value = or.Id_team;

                con.Open();
                //Lê dados
                Int32 newId = (Int32)co.ExecuteScalar();

                //4º Execute
                string q2 = "insert into product_order (id_order, id_product, quantity) values(@id_order, @id_product, @quantity)";

                SqlCommand co2 = new SqlCommand(q2, con);
                co2.Parameters.Add(new SqlParameter("@id_order", SqlDbType.Int));
                co2.Parameters.Add(new SqlParameter("@id_product", SqlDbType.Int));
                co2.Parameters.Add(new SqlParameter("@quantity", SqlDbType.Int));

                foreach (ProductOrder pr in or.Products)
                {
                    co2.Parameters[0].Value = newId;
                    co2.Parameters[1].Value = pr.Id_product;
                    co2.Parameters[2].Value = pr.Quantity;
                    price += (pr.Quantity * pr.UnitPrice);
                    if (co2.ExecuteNonQuery() != 1)
                    {
                        throw new InvalidProgramException();
                    }
                }

                string q3 = "update orders set total_price = @total_price where id = @id_order";
                SqlCommand co3 = new SqlCommand(q3, con);
                co3.Parameters.Add("@total_price", SqlDbType.Float);
                co3.Parameters["@total_price"].Value = Math.Round(price,2);

                co3.Parameters.Add("@id_order", SqlDbType.Int);
                co3.Parameters["@id_order"].Value = newId;

                if (co3.ExecuteNonQuery() != 1)
                {
                    throw new InvalidProgramException();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
        }

        public bool CreateNewProduct(Product pro)
        {
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();
                //1º ConnectionString
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMSAC;Integrated Security=True";
                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);
                //3º Query
                string q = "insert into product (label, unitPrice) values(@label, @unitPrice);";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);

                //Instancia parâmetros
                co.Parameters.Add("@label", SqlDbType.VarChar);
                co.Parameters["@label"].Value = pro.Label;

                co.Parameters.Add("@unitPrice", SqlDbType.Float);
                co.Parameters["@unitPrice"].Value = pro.UnitPrice;

                con.Open();
                //Lê dados
                if (co.ExecuteNonQuery() != 1)
                {
                    throw new InvalidProgramException();
                }

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeliverOrder(Delivery del)
        {
            string t;
            List<string> list = new List<string>();
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMSAC;Integrated Security=True";

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                //3º Query
                string q = "insert into delivery (date, id_order) values(@date, @id_order);update orders set delivered=1 where id=@id_order;";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);

                //Instancia parâmetros
                co.Parameters.Add("@date", SqlDbType.NChar);
                co.Parameters["@date"].Value = del.Date;

                co.Parameters.Add("@id_order", SqlDbType.Int);
                co.Parameters["@id_order"].Value = del.Id_order;

                //Lê dados

                co.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
        }

        public List<ProductSelled> GetProductsMostSelled()
        {
            List<ProductSelled> list = new List<ProductSelled>();
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMSAC;Integrated Security=True";

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                //3º Query
                string q = "select po.id_product, sum(po.quantity) as quantity, p.label" +
                    "from product_order po inner" + 
                    "join product p on po.id_product = p.id" + 
                    "group by po.id_product, p.label" +
                    "Order by sum(po.quantity) desc";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);

                //Lê dados
                con.Open();
                using (SqlDataReader read = co.ExecuteReader())
                {
                    while (read.Read())
                    {
                        list.Add(new ProductSelled(Int32.Parse(read["id"].ToString()), Int32.Parse(read["id"].ToString()), read["label"].ToString()));
                    }
                    con.Close();
                }
                return list;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return list;
            }
        }

        public List<TeamCost> GetMostExpensiveTeams()
        {
            List<TeamCost> list = new List<TeamCost>();
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMSAC;Integrated Security=True";

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                //3º Query
                string q = "select o.id_team, sum(o.total_price) cost, t.label"+
                    "from orders o inner"+
                    "join team t on o.id_team = t.id"+
                    "group by o.id_team, t.label"+
                    "Order by sum(o.total_price) desc";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);

                //Lê dados
                con.Open();
                using (SqlDataReader read = co.ExecuteReader())
                {
                    while (read.Read())
                    {
                        list.Add(new TeamCost(Int32.Parse(read["id"].ToString()), read["label"].ToString(), float.Parse(read["cost"].ToString())));
                    }
                    con.Close();
                }
                return list;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return list;
            }
        }

        public double GetAverageInfected()
        {
            double count = -1;
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString
                string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMSAC;Integrated Security=True";

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                var today = DateTime.Today;
                var earlier = today.AddMonths(-6);

                //3º Query
                string q = "DECLARE @p_date date" +
                    "SET @p_date = CONVERT(date, '" + today.Day + "/" + today.Month + "/" + today.Year + "', 103" +
                    "DECLARE @p_date2 date" +
                    "SET     @p_date2 = CONVERT(date, '" + earlier.Day + "/" + earlier.Month + "/" + earlier.Year + "', 103" +
                    "SELECT count(id_infected) as infetados" +
                    "FROM infected" +
                    "WHERE CONVERT(date, visit_date, 103) >= @p_date AND CONVERT(date, visit_date, 103) <= @p_date2";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);
                double days = (today - earlier).TotalDays;
                //Lê dados
                con.Open();
                using (SqlDataReader read = co.ExecuteReader())
                {
                    while (read.Read())
                    {
                        double.TryParse(read["infetados"].ToString(), out count);
                    }
                    con.Close();
                }
                return count/days;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return -1;
            }
        }
        #endregion
    }

}
