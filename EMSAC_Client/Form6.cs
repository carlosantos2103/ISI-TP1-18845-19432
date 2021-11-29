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
using System.Text.Json;
using System.IO;


namespace EMSAC_Client
{
    /// <summary>
    /// Form que gere a criacao de um novo produto
    /// </summary>
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Fechar o Form atual
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Criar um objeto Product
            Product p1 = new Product(NomeProduto.Text, float.Parse(PrecoProduto.Text));
            // Inserir o produto numa lista
            Products.Add_Product(p1);
            MessageBox.Show(p1.label + " - " + p1.unitPrice.ToString());
            // // Consumo da Api
            StringBuilder url = new StringBuilder();
            url.Append("https://localhost:44348/orders/createnewproduct/");
            HttpWebRequest req = WebRequest.Create(url.ToString()) as HttpWebRequest;
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";
            req.Timeout = 30000;

            string jsonString = JsonSerializer.Serialize(p1);
            MessageBox.Show(jsonString);
            req.ContentLength = jsonString.Length;
            var sw = new StreamWriter(req.GetRequestStream());
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

            // Mostra a Form5
            Form5 form5 = new Form5();
            form5.Show();

            // Fechar o Form atual
            this.Close();
        }
    }
}
