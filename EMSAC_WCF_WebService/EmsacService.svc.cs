using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Diagnostics;

using System.Configuration;     
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Text.Json;

using System.Web.Script.Serialization;  //Manipular JSON: Add Reference to System.Web.Extensions


namespace EMSAC_WCF_WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmsacService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmsacService.svc or EmsacService.svc.cs at the Solution Explorer and start debugging.
    public class EmsacService : IEmsacService
    {
        public void RegisterInfected(Infected inf)
        {

            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString no Web Config

                string cs = ConfigurationManager.ConnectionStrings["EMSACConnectionString"].ConnectionString;

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                // 3 Query
                string q = "insert into dbo.infected (name, address, birthday, pacient_number, contact, register_date)" +
                    "values(@name, @address, @birthday, @pacient_number, @contact, @register_date);";

                //4º Execute
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                //Instancia parâmetros
                da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@name"].Value = inf.Name;

                da.SelectCommand.Parameters.Add("@address", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@address"].Value = inf.Address;

                da.SelectCommand.Parameters.Add("@birthday", SqlDbType.DateTime2);
                da.SelectCommand.Parameters["@birthday"].Value = inf.Birthday;

                da.SelectCommand.Parameters.Add("@pacient_number", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@pacient_number"].Value = inf.Pacient_number;

                da.SelectCommand.Parameters.Add("@contact", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@contact"].Value = inf.Contact;

                da.SelectCommand.Parameters.Add("@register_date", SqlDbType.DateTime2);
                da.SelectCommand.Parameters["@register_date"].Value = inf.Register_date;

                da.Fill(ds, "Infetados");

            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }

        public void RegisterIsolated(Isolated iso)
        {
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString no Web Config

                string cs = ConfigurationManager.ConnectionStrings["EMSACConnectionString"].ConnectionString;

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                // 3 Query
                string q = "insert into dbo.isolated (cod_infected, name, address, birthday, pacient_number, contact, register_date)" +
                    "values(@codigo, @name, @address, @birthday, @pacient_number, @contact, @register_date);";

                //4º Execute
                SqlDataAdapter da = new SqlDataAdapter(q, con);

                //Instancia parâmetros
                da.SelectCommand.Parameters.Add("@codigo", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@codigo"].Value = iso.Name;

                da.SelectCommand.Parameters.Add("@name", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@name"].Value = iso.Name;

                da.SelectCommand.Parameters.Add("@address", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@address"].Value = iso.Address;

                da.SelectCommand.Parameters.Add("@birthday", SqlDbType.DateTime);
                da.SelectCommand.Parameters["@birthday"].Value = iso.Birthday;

                da.SelectCommand.Parameters.Add("@pacient_number", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@pacient_number"].Value = iso.Pacient_number;

                da.SelectCommand.Parameters.Add("@contact", SqlDbType.VarChar);
                da.SelectCommand.Parameters["@contact"].Value = iso.Contact;

                da.SelectCommand.Parameters.Add("@register_date", SqlDbType.DateTime);
                da.SelectCommand.Parameters["@register_date"].Value = iso.Register_date;

                da.Fill(ds, "Isolados");
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);

            }
        }


        #region RelatorioDigital
        public void Relatoriodigital(string file, string extension)
        {
            const string json = ".json";
            const string xml = ".xml";

            if (String.Compare(extension, xml) == 0) RegisterXml(file);
            else if (String.Compare(extension, json) == 0) RegisterJson(file);
        }

        private bool RegisterXml(string file) 
        {
            try
            {
                // Variaveis 
                string mydate = string.Empty;
                string pacient = String.Empty;
                int status = -1;
                string hour = String.Empty;

                XmlDocument docXml = new XmlDocument();
                docXml.LoadXml(file);

                // Retorna apenas as tags (name , adress, ...  de cada isolado)
                foreach (XmlNode xmlNode in docXml.DocumentElement.ChildNodes)
                {
                    // Retorna para cada variavel apenas
                    pacient = xmlNode.ChildNodes[0].InnerText;
                    status = Int32.Parse(xmlNode.ChildNodes[1].InnerText);
                    mydate = xmlNode.ChildNodes[2].InnerText;
                    hour = xmlNode.ChildNodes[3].InnerText;

                    // Registar na base de dados
                    DataSet ds = new DataSet();

                    //1º ConnectionString no Web Config
                    string cs = ConfigurationManager.ConnectionStrings["EMSACConnectionString"].ConnectionString;

                    //2º OpenConnection
                    SqlConnection con = new SqlConnection(cs);


                    // 3 Query
                    string q = "insert into dbo.visits (pacient_number, status, visit_date)" +
                        "values(@pacient_number, @status, @visit_date);";

                    //4º Execute
                    SqlDataAdapter da = new SqlDataAdapter(q, con);

                    //Instancia parâmetros
                    da.SelectCommand.Parameters.Add("@pacient_number", SqlDbType.VarChar);
                    da.SelectCommand.Parameters["@pacient_number"].Value = pacient;

                    da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar);
                    da.SelectCommand.Parameters["@status"].Value = status;

                    da.SelectCommand.Parameters.Add("@visit_date", SqlDbType.DateTime);
                    da.SelectCommand.Parameters["@visit_date"].Value = mydate + " " + hour;

                    da.Fill(ds, "VisitsXml");
                }

                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
    }

        private bool RegisterJson(string file)
        {
            try
            {
                string hour = String.Empty;
                string myDate = String.Empty;

                JsonDocument jsonDoc = JsonDocument.Parse(file);

                JsonElement root = jsonDoc.RootElement;
                JsonElement isolationsJsonElement = root.GetProperty("isolations");

                foreach (JsonElement iso in isolationsJsonElement.EnumerateArray())
                {

                    JsonElement pacientEl = iso.GetProperty("pacient_number");
                    String pacient = pacientEl.GetString();
                    JsonElement statusEl = iso.GetProperty("status"); 
                    Int32 status = statusEl.GetInt32();
                    JsonElement dateEl = iso.GetProperty("visit_date");
                    DateTime date = dateEl.GetDateTime();


                    myDate = date.Day + "/" + date.Month + "/" + date.Year;
                    hour = date.Hour + ":" + date.Minute + ":" + date.Second;
                    // Adicionar a BD
                    DataSet ds = new DataSet();

                    //1º ConnectionString no Web Config

                    string cs = ConfigurationManager.ConnectionStrings["EMSACConnectionString"].ConnectionString;

                    //2º OpenConnection
                    SqlConnection con = new SqlConnection(cs);


                    // 3 Query
                    string q = "insert into dbo.visits (pacient_number, status, visit_date)" +
                        "values(@pacient_number, @status, @visit_date);";

                    //4º Execute
                    SqlDataAdapter da = new SqlDataAdapter(q, con);

                    //Instancia parâmetros
                    da.SelectCommand.Parameters.Add("@pacient_number", SqlDbType.VarChar);
                    da.SelectCommand.Parameters["@pacient_number"].Value = pacient;

                    da.SelectCommand.Parameters.Add("@status", SqlDbType.VarChar);
                    da.SelectCommand.Parameters["@status"].Value = status;

                    da.SelectCommand.Parameters.Add("@visit_date", SqlDbType.DateTime);
                    da.SelectCommand.Parameters["@visit_date"].Value = date;

                    da.Fill(ds, "VisitsJson");
                }

                return true;
            }
            catch (Exception)
            {
                throw new Exception();

            }
        }
        
        public VisitsStats GetLastVisits()
        {
            VisitsStats stats = new VisitsStats();
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString
                string cs = ConfigurationManager.ConnectionStrings["EMSACConnectionString"].ConnectionString;

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                //3º Query
                string q = " DECLARE @p_date date" +
                        "SET @p_date = CONVERT(date, '12/03/2021', 103" +

                        "DECLARE @p_date2 date" +
                        "SET     @p_date2 = CONVERT(date, '12/05/2021', 103)" +

                        "SELECT count(id_visit) as visitas, count(id_visit)-sum(status) as irregularidades" +
                        "FROM visits" +
                        "WHERE CONVERT(date, visit_date, 103) >= @p_date AND CONVERT(date, visit_date, 103) <= @p_date2";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);

                //Lê dados
                con.Open();
                using (SqlDataReader read = co.ExecuteReader())
                {
                    while (read.Read())
                    {
                        stats.Visits_count = Int32.Parse(read["visitas"].ToString());
                        stats.Irregularities_percent = float.Parse(read["irregularidades"].ToString());
                    }
                    con.Close();
                }
                return stats;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return stats;
            }
        }

        #endregion


    }
}
