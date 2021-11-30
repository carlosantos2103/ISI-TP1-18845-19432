/*
 * <copyright file="Docente.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.2</version>
 *  <user> Joao Ricardo / localhost Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */
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
using System.Web.Script.Serialization;  


namespace EMSAC_WCF_WebService
{
    public class EmsacService : IEmsacService
    {
        #region Infetados/Isolados
        /// <summary>
        /// Registo de Infetados
        /// </summary>
        /// <param name="inf"></param>
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

        /// <summary>
        /// Registo de Isolados
        /// </summary>
        /// <param name="iso"></param>
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

        #endregion

        #region RelatorioDigital

        /// <summary>
        /// Importar ficherios Json/Xml
        /// </summary>
        /// <param name="file"></param>
        /// <param name="extension"></param>
        public void Relatoriodigital(string file, string extension)
        {
            const string json = ".json";
            const string xml = ".xml";
            // Verificar se a extensao e Json/Xml
            if (String.Compare(extension, xml) == 0) RegisterXml(file);
            else if (String.Compare(extension, json) == 0) RegisterJson(file);
        }

        /// <summary>
        /// Registo apenas de ficheiro Xml
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool RegisterXml(string file) 
        {
            try
            {
                // Variaveis 
                string mydate = string.Empty;
                string pacient = String.Empty;
                int status = -1;
                string hour = String.Empty;

                // Instanciar um Documento Xml
                XmlDocument docXml = new XmlDocument();
                // Carregar a string para o documento Xml
                docXml.LoadXml(file);

                // Retorno das tags (name , adress, ...  de cada isolado)
                foreach (XmlNode xmlNode in docXml.DocumentElement.ChildNodes)
                {
                    // Retorna o valor para cada variavel 
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

        /// <summary>
        /// Registo apenas de ficheiro Json
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool RegisterJson(string file)
        {
            try
            {
                // Criação de strigs vazias
                string hour = String.Empty;
                string myDate = String.Empty;

                // Instanciar um Documento Json
                JsonDocument jsonDoc = JsonDocument.Parse(file);

                JsonElement root = jsonDoc.RootElement;
                JsonElement isolationsJsonElement = root.GetProperty("isolations");

                // Percorrer todos os objeto no ficheiro Json
                foreach (JsonElement iso in isolationsJsonElement.EnumerateArray())
                {

                    // Retorna o valor para cada variavel 
                    JsonElement pacientEl = iso.GetProperty("pacient_number");
                    String pacient = pacientEl.GetString();
                    JsonElement statusEl = iso.GetProperty("status"); 
                    Int32 status = statusEl.GetInt32();
                    JsonElement dateEl = iso.GetProperty("visit_date");
                    DateTime date = dateEl.GetDateTime();

                    // Junção dos campo Dia + Mes + Ano
                    myDate = date.Day + "/" + date.Month + "/" + date.Year;
                    // Junção dos campo Hora + Minuto + Segundo
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

        #endregion

        #region Visitas
        /// <summary>
        /// Registar Visitas
        /// </summary>
        /// <returns></returns>
        /// 
        public VisitsStats GetLastVisits()
        {
            // Ins5ta
            VisitsStats stats = new VisitsStats();
            try
            {
                // Registar na base de dados
                DataSet ds = new DataSet();

                //1º ConnectionString
                string cs = ConfigurationManager.ConnectionStrings["EMSACConnectionString"].ConnectionString;

                //2º OpenConnection
                SqlConnection con = new SqlConnection(cs);

                var today = DateTime.Today;
                var earlier = today.AddMonths(-1);
                string t = today.Day + "/" + today.Month + "/" + today.Year;
                string e = earlier.Day + "/" + earlier.Month + "/" + earlier.Year;

                //3º Query
                string q = "DECLARE @p_date date" +
                        " SET @p_date = CONVERT(date, '" + e + "', 103)" +
                        " DECLARE @p_date2 date" +
                        " SET     @p_date2 = CONVERT(date, '" + t + "', 103)" +

                        " SELECT count(id_visit) as visitas, count(id_visit)-sum(status) as a" +
                        " FROM visits" +
                        " WHERE CONVERT(date, visit_date, 103) >= @p_date AND CONVERT(date, visit_date, 103) <= @p_date2";

                //4º Execute
                SqlCommand co = new SqlCommand(q, con);

                //Lê dados
                con.Open();
                using (SqlDataReader read = co.ExecuteReader())
                {
                    while (read.Read())
                    {
                        stats.Visits_count = Int32.Parse(read["visitas"].ToString());
                        Trace.WriteLine(read["a"].ToString());
                        stats.Irregularities_percent = Int32.Parse(read["a"].ToString()) / stats.Visits_count * 100.0;
                    }
                    // Fechar Ligacao
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
