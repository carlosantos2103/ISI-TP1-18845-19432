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
                url.Append("https://localhost/");

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



                    // Trabalhar aqui sobre o que retorna
                    //label_equipasdespesas
                    //label_visitasdiarias
                    //label_produtosvendidos
                    //label_medioinfetados

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
    }
}
