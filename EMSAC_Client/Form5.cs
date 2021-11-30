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
using System.Text.Json;

namespace EMSAC_Client
{
    /// <summary>
    /// Form que gere as requesiçoes das encomendas
    /// </summary>
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                // Criar uma Lista de ProductOrder
                List<ProductOrder> lst_nova = new List<ProductOrder>();
                // O conteudo da lista de ProductOrder é o retorno da funcao
                lst_nova = ProductsOrder.Show_ProductOrder();

                // Criar uma Encomenda
                Order encomenda = new Order(DateTime.Today, Int32.Parse(idequipa.Text), lst_nova);

                //// Criação de uma string
                StringBuilder url = new StringBuilder();
                //// Conteudo  da string
                url.Append("https://localhost/orders/createneworder");

                // // Consumo da Api
                HttpWebRequest req = WebRequest.Create(url.ToString()) as HttpWebRequest;
                req.Method = "POST";
                req.ContentType = "application/json; charset=utf-8";
                req.Timeout = 30000;

                var sw = new StreamWriter(req.GetRequestStream());
                string jsonString = JsonSerializer.Serialize(encomenda);
                req.ContentLength = jsonString.Length;
                sw.Write(jsonString);
                sw.Close();

                using (HttpWebResponse response = req.GetResponse() as HttpWebResponse)
                {
                    // Verifica de o serviço esta ON
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        // Mensagem de Erro
                        string message = String.Format("Post falhou!!");
                        throw new ApplicationException(message);
                    }
                }

                // Limpar a lista apos a encomenda estar concluida
                lst_nova.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostra a Form6
                Form6 form6 = new Form6();
                form6.Show();
                this.Close();
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
                // Criação de uma string
                StringBuilder url = new StringBuilder();
                // Conteudo  da string
                url.Append("https://localhost/orders/getproductlist");

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
                }

                // Converter objeto num json
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Product>));
                //object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                //List<Product> jsonResponse = (List<Product>)objResponse;

                // Criar a classe Product do json que vem
                //foreach (Product item in jsonResponse)
                //{
                //    listBox1.Items.Add(item.Name.ToString());
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Rerirar a visibilidade da label
                label3.Hide();
                // Rerirar a visibilidade do Input
                idequipa.Hide();

                // Criar um ProductOrder
                ProductOrder p1 = new ProductOrder(Int32.Parse(idproduto.Text), Int32.Parse(quantidade.Text));
                // Adicionar a lista o produto criado
                ProductsOrder.Add_ProductOrder(p1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostrar o form7
                Form7 form7 = new Form7();
                form7.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Criação de uma string
            StringBuilder url = new StringBuilder();
            // Conteudo  da string
            url.Append("https://localhost:44348/orders/getproductlist");

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
                // Converter objeto num json
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Product>));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                List<Product> jsonResponse = (List<Product>)objResponse;
                foreach (Product p in jsonResponse)
                {
                    var index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells["Id"].Value = p.id;
                    dataGridView1.Rows[index].Cells["Nome"].Value = p.label;
                    dataGridView1.Rows[index].Cells["Price"].Value = p.unitPrice;
                }

            }
        }
    }
}
