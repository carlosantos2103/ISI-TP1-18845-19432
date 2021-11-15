using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Diagnostics;
using Npgsql;

namespace TP_ISI_Web.Service
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void AddInfected(string infected)
        {
            // base de dados
            //inf.describe();
            //iso.describe();
            //Trace.WriteLine(infected);
            try
            {
                Infected deserializedProduct = JsonConvert.DeserializeObject<Infected>(infected);
                Trace.WriteLine(deserializedProduct.Name);
                int number = InsertInfected(deserializedProduct);
                if (number == 1)
                {
                    throw new Exception("Erro no SQL");
                }
            }
            catch (Exception e)
            {

                Trace.WriteLine(e.Message);
            }
        }


        private static int InsertInfected(Infected inf)
        {
            try
            {
                // Ver digitos do numero de paciente
                //if (inf.Pacient_number.Length != 9)
                //    return 1;

                using (NpgsqlConnection con = GetConnection())
                {
                    // Abrir a base de dados
                    con.Open();
                    // Inserir na base de dados os atributos
                    string query = "insert into ipca.infected(id_infected, name, address, birthday, pacient_number, contact, register_date)values(@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    cmd.Parameters.AddWithValue("p1", 1);
                    cmd.Parameters.AddWithValue("p2", inf.Name);
                    cmd.Parameters.AddWithValue("p3", inf.Address);
                    cmd.Parameters.AddWithValue("p4", inf.Birthday);
                    cmd.Parameters.AddWithValue("p5", inf.Pacient_number);
                    cmd.Parameters.AddWithValue("p6", inf.Contact);
                    cmd.Parameters.AddWithValue("p7", inf.Register_date);
                    int n = cmd.ExecuteNonQuery();
                    if (n == 1)
                        return 0;
                    return 1;
                }
            }
            catch (IndexOutOfRangeException x)
            {
                throw new FormatException(x.Message);
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
        private static NpgsqlConnection GetConnection()
        {
            // Conectar a esta base de Dados - Muda consoante o utlizador
            var connString = "Host=localhost;Port=5432;Username=postgres;Password=admin;Database=postgres";
            return new NpgsqlConnection(connString);
        }
    }
}
