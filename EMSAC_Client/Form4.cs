/*
 * <copyright file="Docente.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.2</version>
 *  <user> Joao Ricardo / Carlos Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace EMSAC_Client
{
    /// <summary>
    /// Form que gere as Estatísticas relativas as equipas
    /// </summary>
    public partial class Form4 : Form
    {
        public Form4()
        {
            int i;
            InitializeComponent();
            try
            {

                // Criação de uma string
                StringBuilder url = new StringBuilder();
                // Conteudo  da string
                url.Append("https://emsacwebapi.azurewebsites.net/orders/get_most_selled_products");

                // Consumo da Api
                HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Verifica de o serviço esta ON
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        // Mensagem de Erro
                        string message = String.Format("Get falhou!!");
                        throw new ApplicationException(message);
                    }

                    // Converter Json numa Classe
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<ProductSelled>));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    List<ProductSelled> jsonResponse = (List<ProductSelled>)objResponse;
                    i = 0;
                    foreach (ProductSelled p in jsonResponse)
                    {
                        if (i == 5) break;
                        var index = dataGridView1.Rows.Add();
                        dataGridView1.Rows[index].Cells["label"].Value = p.label;
                        dataGridView1.Rows[index].Cells["quantity"].Value = p.quantity;
                        i++;
                    }
                }
            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message);
            }

            try
            {
                EMSAC.EmsacServiceClient cl = new EMSAC.EmsacServiceClient();
                label_visitasdiarias.Text = cl.GetLastVisits().Visits_count.ToString();
                label_irregularidades.Text = cl.GetLastVisits().Irregularities_percent.ToString();
            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message);
            }

            try
            {
                // Criação de uma string
                StringBuilder url2 = new StringBuilder();
                // Conteudo  da string
                url2.Append("https://emsacwebapi.azurewebsites.net/orders/get_most_expensive_teams");

                // Consumo da Api
                HttpWebRequest request2 = WebRequest.Create(url2.ToString()) as HttpWebRequest;
                using (HttpWebResponse response2 = request2.GetResponse() as HttpWebResponse)
                {
                    // Verifica de o serviço esta ON
                    if (response2.StatusCode != HttpStatusCode.OK)
                    {
                        // Mensagem de Erro
                        string message = String.Format("Get falhou!!");
                        throw new ApplicationException(message);
                    }

                    // Converter Json numa Classe
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<TeamCost>));
                    object objResponse2 = jsonSerializer.ReadObject(response2.GetResponseStream());
                    List<TeamCost> jsonResponse2 = (List<TeamCost>)objResponse2;

                    i = 0;
                    foreach (TeamCost tc in jsonResponse2)
                    {
                        if (i == 10) break;
                        var index = dataGridView2.Rows.Add();
                        dataGridView2.Rows[index].Cells["team"].Value = tc.label;
                        dataGridView2.Rows[index].Cells["price"].Value = tc.cost;
                        i++;
                    }
                }

            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message);
            }

            try
            {
                // Criação de uma string
                StringBuilder url3 = new StringBuilder();
                // Conteudo  da string
                url3.Append("https://emsacwebapi.azurewebsites.net/orders/get_average_infected");

                // Consumo da Api
                HttpWebRequest request3 = WebRequest.Create(url3.ToString()) as HttpWebRequest;
                using (HttpWebResponse response3 = request3.GetResponse() as HttpWebResponse)
                {
                    // Verifica de o serviço esta ON
                    if (response3.StatusCode != HttpStatusCode.OK)
                    {
                        // Mensagem de Erro
                        string message = String.Format("Get falhou!!");
                        throw new ApplicationException(message);
                    }

                    // Converter Json numa Classe
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(double));
                    object objResponse2 = jsonSerializer.ReadObject(response3.GetResponseStream());
                    double jsonResponse2 = Math.Round((double)objResponse2, 3);
                    label_medioinfetados.Text = jsonResponse2.ToString();
                }
            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Fechar a Form atual
            this.Close();
        }

        private void label_medioinfetados_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label_medioinfetados_Click_1(object sender, EventArgs e)
        {

        }

        private void label_irregularidades_Click(object sender, EventArgs e)
        {

        }
    }
}
