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
    /// Form que gere a Situção Pandemica Portuguesa atual e os restantes forms
    /// </summary>
    public partial class Form3 : Form
    {
        public Form3()
        {
            try
            {
                InitializeComponent();

                // Criação de uma string
                StringBuilder urlStatus = new StringBuilder();
                // Conteudo  da string
                urlStatus.Append("https://covid19-api.vost.pt/Requests/get_status");

                // Consumo da Api
                HttpWebRequest requestStatus = WebRequest.Create(urlStatus.ToString()) as HttpWebRequest;
                using (HttpWebResponse responseStatus = requestStatus.GetResponse() as HttpWebResponse)
                {
                    // Verifica de o serviço esta ON
                    if (responseStatus.StatusCode != HttpStatusCode.OK)
                    {
                        // Mensagem de Erro
                        string message = String.Format("GET falhou!!");
                        throw new ApplicationException(message);
                    }

                    // Converter objeto num json
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Root));
                    object objResponse = jsonSerializer.ReadObject(responseStatus.GetResponseStream());
                    Root jsonResponse = (Root)objResponse;

                    // Verifica se o serviço esta ON
                    if (String.Compare(jsonResponse.status, "Server is OK") != 0)
                    {
                        // Mensagem de Erro
                        string message = String.Format("API falhou!!");
                        throw new ApplicationException(message);
                    }
                }

                // Criação de uma string
                StringBuilder url = new StringBuilder();
                url.Append("https://covid19-api.vost.pt/Requests/get_last_update");

                // Consumo da Api
                HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Verifica se o serviço esta ON
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
                    label_ativos.Text = jsonResponse.ativos.ToString();
                    label_confirmados.Text = jsonResponse.confirmados.ToString();
                    label_obitos.Text = jsonResponse.obitos.ToString();
                    label_internados.Text = jsonResponse.internados.ToString();
                    label_recuperados.Text = jsonResponse.recuperados.ToString();
                    label_uci.Text = jsonResponse.internados_uci.ToString();
                }
            }
            catch(ApplicationException exception)
            {
                MessageBox.Show(exception.Message);
                this.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Fechar o Form atual
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostra a Form2
                Form2 form2 = new Form2();
                form2.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostra a Form1
                Form1 form1 = new Form1();
                form1.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostra a Form4
                Form4 form4 = new Form4();
                form4.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostra a Form5
                Form5 form5 = new Form5();
                form5.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label_confirmados_Click(object sender, EventArgs e)
        {

        }

        private void label_obitos_Click(object sender, EventArgs e)
        {

        }

        private void label_internados_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label_uci_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label_recuperados_Click(object sender, EventArgs e)
        {

        }

        private void label_ativos_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
