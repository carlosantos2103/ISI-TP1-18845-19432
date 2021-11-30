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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization.Json;


namespace EMSAC_Client
{
    /// <summary>
    /// Form que gere o historico de requesicoes
    /// </summary>
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Fecha o Form atual
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Receber os Dados da Base de dados com a requesicoes
            try
            {
                // Criação de uma string
                StringBuilder url = new StringBuilder();
                // Conteudo  da string
                url.Append("https://emsacwebapi.azurewebsites.net/orders/get_team_orders/");
                url.Append(idequipa.Text.ToString());

                // Consumo da Api
                HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;
                // Verifica de o serviço esta ON
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        // Mensagem de Erro
                        string message = String.Format("Get falhou!!");
                        throw new ApplicationException(message);
                    }

                    // Converter Json numa Classe
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<TeamOrder>));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    List<TeamOrder> jsonResponse = (List<TeamOrder>)objResponse;
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    foreach (TeamOrder t in jsonResponse)
                    {
                        var d = DateTime.Parse(t.date);
                        if (t.delivered == 1)
                        {
                            var index = dataGridView1.Rows.Add();
                            dataGridView1.Rows[index].Cells["Date"].Value = d.Date;
                            dataGridView1.Rows[index].Cells["Price"].Value = t.total_price;
                        }
                        else
                        {
                            var index = dataGridView2.Rows.Add();
                            dataGridView2.Rows[index].Cells["Date2"].Value = d.Date;
                            dataGridView2.Rows[index].Cells["Price2"].Value = t.total_price;
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
