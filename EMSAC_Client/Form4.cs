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
            try
            {
                InitializeComponent();

                // Criação de uma string
                StringBuilder url = new StringBuilder();
                // Conteudo  da string
                url.Append("https://localhost:44348/orders/getmostselledproducts");

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
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Root));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Root jsonResponse = (Root)objResponse;
                }

                EMSAC.EmsacServiceClient cl = new EMSAC.EmsacServiceClient();
                label_visitasdiarias.Text = cl.GetLastVisits().ToString();

                // Criação de uma string
                StringBuilder url2 = new StringBuilder();
                // Conteudo  da string
                url2.Append("https://localhost:44348/orders/getmostexpensiveteams");

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
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Root));
                    object objResponse2 = jsonSerializer.ReadObject(response2.GetResponseStream());
                    Root jsonResponse2 = (Root)objResponse2;
                    //label_produtosvendidos.Text = jsonResponse2.
                }

                // Criação de uma string
                StringBuilder url3 = new StringBuilder();
                // Conteudo  da string
                url2.Append("https://localhost:44348/orders/getaverageinfected");

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
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Root));
                    object objResponse2 = jsonSerializer.ReadObject(response3.GetResponseStream());
                    Root jsonResponse2 = (Root)objResponse2;
                    //label_produtosvendidos.Text = jsonResponse2.
                }

            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message);
                this.Close();
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
    }
}
