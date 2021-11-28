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

            // Enviar para o rest e depois meter na base de dados

            // Mostra a Form5
            Form5 form5 = new Form5();
            form5.Show();

            // Fechar o Form atual
            this.Close();
        }
    }
}
