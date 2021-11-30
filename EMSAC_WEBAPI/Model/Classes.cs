/*
 * <copyright file="Classes.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.1</version>
 *  <user> Joao Ricardo / Carlos Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace EMSAC_WEBAPI.Model
{
    // Classe representativa de Requisição
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

    // Classe representativa de Equipa
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

    // Classe representativa de Custo por Equipa
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

    // Classe representativa de Produto
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

    // Classe representativa de Entrega
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

    // Classe representativa de Produto por Requisição
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

    // Classe representativa de Produto vendido
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
        /// Obter a histórico de requisições de uma equipa
        /// </summary>
        /// <param name="team_id">Código associado à equipa</param>
        /// <returns>Lista de requisições efetuadas</returns>
        public List<Order> GetTeamOrders(int team_id)
        {
            List<Order> l = new();
            try
            {
                //1º ConnectionString
                string cs = "Data Source=tcp:emsac-isi.database.windows.net,1433;Initial Catalog=EMSAC;User Id=a19432@emsac-isi;Password=ipca123!;MultipleActiveResultSets=True;";

                //2º Conexao a BD
                SqlConnection con = new(cs);

                //3º Query
                string q = "SELECT * FROM orders WHERE id_team = @id_team";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

                //Instancia parâmetros
                co.Parameters.Add("@id_team", SqlDbType.Int);
                co.Parameters["@id_team"].Value = team_id;

                con.Open();
                // Executa e lê dados
                using (SqlDataReader read = co.ExecuteReader())
                {
                    while (read.Read())
                    {
                        int currentId = Int32.Parse(read["id"].ToString());

                        string q2 = "SELECT * FROM product_order WHERE id_order = @id_order;";
                        SqlCommand co2 = new(q2, con);

                        //Instancia parâmetros
                        co2.Parameters.Add("@id_order", SqlDbType.Int);
                        co2.Parameters["@id_order"].Value = currentId;

                        List<ProductOrder> prList = new();
                        using (SqlDataReader read2 = co2.ExecuteReader())
                        {
                            while (read2.Read())
                            {
                                prList.Add(new ProductOrder(Int32.Parse(read2["id_product"].ToString()), Int32.Parse(read2["quantity"].ToString())));
                            }
                        }

                        Order o = new(currentId, DateTime.Parse(read["date"].ToString()), float.Parse(read["total_price"].ToString()), Int32.Parse(read["id_team"].ToString()), Int32.Parse(read["delivered"].ToString()), prList);
                        l.Add(o);
                    }
                    con.Close();
                }
                return l;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return l;
            }
        }

        /// <summary>
        /// Obter lista de produtos disponíveis
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        public List<Product> GetProductList()
        {
            List<Product> list = new();
            try
            {

                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º Conexao a BD
                SqlConnection con = new(cs);

                //3º Query
                string q = "SELECT * FROM product;";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

                //Executa e lê dados
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

        /// <summary>
        /// Regista uma nova requisicao
        /// </summary>
        /// <param name="or">Requisicao</param>
        public bool CreateNewOrder(Order or)
        {
            float price = 0;
            try
            {
                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º Conexao a BD
                SqlConnection con = new(cs);

                //3º Query
                string q = "insert into orders (date, id_team) " +
                    " output inserted.id" +
                    " values(@date, @team_id);";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

                //Instancia parâmetros
                co.Parameters.Add("@date", SqlDbType.NChar);
                co.Parameters["@date"].Value = or.Date.Day+"/"+or.Date.Month + "/"+or.Date.Year;
                
                co.Parameters.Add("@team_id", SqlDbType.Int);
                co.Parameters["@team_id"].Value = or.Id_team;

                con.Open();

                //Insere e obtem id inserido
                Int32 newId = (Int32)co.ExecuteScalar();

                //Query para inserir produtos relacionados com a requisicao
                string q2 = "insert into product_order (id_order, id_product, quantity) values(@id_order, @id_product, @quantity)";
                SqlCommand co2 = new(q2, con);
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

                //Query para atualizar custo total da requisição
                string q3 = "update orders set total_price = @total_price where id = @id_order";
                SqlCommand co3 = new(q3, con);
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

        /// <summary>
        /// Regista um novo produto
        /// </summary>
        /// <param name="pro">Produto</param>
        public bool CreateNewProduct(Product pro)
        {
            try
            {
                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º Conexao a BD
                SqlConnection con = new(cs);

                //3º Query
                string q = "insert into product (label, unitPrice) values(@label, @unitPrice);";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

                //Instancia parâmetros
                co.Parameters.Add("@label", SqlDbType.VarChar);
                co.Parameters["@label"].Value = pro.Label;

                co.Parameters.Add("@unitPrice", SqlDbType.Float);
                co.Parameters["@unitPrice"].Value = pro.UnitPrice;

                con.Open();
                // Insere dados
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

        /// <summary>
        /// Regista a entrega de uma requisição
        /// </summary>
        /// <param name="del">Entrega</param>
        public bool DeliverOrder(Delivery del)
        {
            try
            {
                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º OpenConnection
                SqlConnection con = new(cs);

                //3º Query
                string q = "insert into delivery (date, id_order) values(@date, @id_order);update orders set delivered=1 where id=@id_order;";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

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

        /// <summary>
        /// Obter lista dos produtos mais vendidos por ordem
        /// </summary>
        /// <returns>Lista dos produtos</returns>
        public List<ProductSelled> GetProductsMostSelled()
        {
            List<ProductSelled> list = new();
            try
            {
                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º OpenConnection
                SqlConnection con = new(cs);
                //3º Query
                string q = "select id_product, quantity, label " +
                    "from(" +
                    " select po.id_product, isnull(sum(po.quantity),0) as quantity, p.label" +
                    " from product_order po inner" +
                    " join product p on po.id_product = p.id" +
                    " group by po.id_product, p.label" +
                    ") q" +
                    " Order by quantity desc";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

                //Lê dados
                con.Open();
                using (SqlDataReader read = co.ExecuteReader())
                {
                    Trace.WriteLine(read.Read());
                    while (read.Read())
                    {
                        list.Add(new ProductSelled(Int32.Parse(read["id_product"].ToString()), Int32.Parse(read["quantity"].ToString()), read["label"].ToString()));
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

        /// <summary>
        /// Obter lista das equipas que mais gastaram
        /// </summary>
        /// <returns>Lista de equipas</returns>
        public List<TeamCost> GetMostExpensiveTeams()
        {
            List<TeamCost> list = new();
            try
            {
                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º OpenConnection
                SqlConnection con = new(cs);

                //3º Query
                string q = "select o.id_team, sum(o.total_price) cost, t.label"+
                    " from orders o inner"+
                    " join team t on o.id_team = t.id"+
                    " group by o.id_team, t.label"+
                    " Order by sum(o.total_price) desc";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

                //Lê dados
                con.Open();
                using (SqlDataReader read = co.ExecuteReader())
                {
                    while (read.Read())
                    {
                        Trace.WriteLine(read["cost"].ToString());
                        list.Add(new TeamCost(Int32.Parse(read["id_team"].ToString()), read["label"].ToString(), float.Parse(read["cost"].ToString())));
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

        /// <summary>
        /// Obter media de infetados nos ultimos 6 meses
        /// </summary>
        /// <returns>Media de infetados</returns>
        public double GetAverageInfected()
        {
            double count = -1;
            try
            {
                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º OpenConnection
                SqlConnection con = new(cs);

                var today = DateTime.Today;
                var earlier = today.AddMonths(-6);
                string t = today.Day + "/" + today.Month + "/" + today.Year;
                string e = earlier.Day + "/" + earlier.Month + "/" + earlier.Year;

                //3º Query
                string q = "DECLARE @p_date date" +
                    " SET @p_date = CONVERT(date, '" + e + "', 103)" +
                    " DECLARE @p_date2 date" + 
                    " SET     @p_date2 = CONVERT(date, '" + t + "', 103)" +
                    " SELECT count(pacient_number) as infetados" +
                    " FROM visits" +
                    " WHERE CONVERT(date, visit_date, 103) >= @p_date AND CONVERT(date, visit_date, 103) <= @p_date2";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

                double days = (today - earlier).TotalDays;

                //Executa e lê dados
                con.Open();

                count = (Int32)co.ExecuteScalar();

                con.Close();
                return count/days;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return -1;
            }
        }

        /// <summary>
        /// Apaga um produto da lista de produtos disponiveis
        /// ! Nao deve ser chamado se o produto tiver requisições associadas
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        public bool DeleteProduct(int id)
        {
            try
            {
                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º OpenConnection
                SqlConnection con = new(cs);

                //3º Query
                string q = "delete from product where id=@id;";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

                //Instancia parâmetros
                co.Parameters.Add("@id", SqlDbType.VarChar);
                co.Parameters["@id"].Value = id;

                con.Open();
                //Executa o comando
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

        /// <summary>
        /// Edita produto
        /// </summary>
        /// <param name="pr">Produto</param>
        /// <returns></returns>
        public bool EditProduct(Product pr)
        {
            try
            {
                //1º ConnectionString
                string cs = "Server=tcp:emsac-isi.database.windows.net,1433;Database=EMSAC;User ID=a19432@emsac-isi;Password=ipca123!;Trusted_Connection=False;Encrypt=True;";

                //2º OpenConnection
                SqlConnection con = new(cs);

                //3º Query
                string q = "UPDATE product " +
                    " SET label=@label, unitPrice=@unitPrice " +
                    " WHERE id=@id; ";

                //4º Cria comando para permitir executar
                SqlCommand co = new(q, con);

                //Instancia parâmetros
                co.Parameters.Add("@id", SqlDbType.Int);
                co.Parameters["@id"].Value = pr.Id;

                co.Parameters.Add("@unitPrice", SqlDbType.Float);
                co.Parameters["@unitPrice"].Value = pr.UnitPrice;

                co.Parameters.Add("@label", SqlDbType.VarChar);
                co.Parameters["@label"].Value = pr.Label;

                con.Open();
                //Executa o comando
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
        #endregion
    }

}
