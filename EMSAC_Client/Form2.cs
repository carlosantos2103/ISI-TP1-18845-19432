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
using System.IO;
using System.Xml;

namespace EMSAC_Client
{
    /// <summary>
    /// Form que gere o registo dos ficheiros Xml ou Json
    /// </summary>
    public partial class Form2 : Form
    {
        const string json = ".json";
        const string xml = ".xml";
        OpenFileDialog file = new OpenFileDialog();
        string path;
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Caso tenha selecionado um ficheiro
                if (file.ShowDialog() == DialogResult.OK)
                {
                    // Caminho absoluto do ficheiro
                    path = file.FileName;
                    
                    // Verificar se existe o ficheiro
                    if (File.Exists(path) == true)
                    {
                        // Ler o conteudo do Ficheiro
                        string text = File.ReadAllText(path);
                        // Mostra no Form o conteudo do ficheiro
                        richTextBox1.Text = text.ToString();
                    }
                    else
                    {
                        throw new Exception("Erro: Ficheiro nao possui conteudo!");
                    }
                }
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
                // Mostra a Form1 de novo e envia a informacao relativa a GNR ou PSP
                EMSAC.EmsacServiceClient co = new EMSAC.EmsacServiceClient();

                // Ler o conteudo do ficheiro
                string text = File.ReadAllText(path);

                // Verificar a extensao do ficheiro
                string extension = Path.GetExtension(path);

                // Comparar a extensao
                if (String.Compare(extension, xml) == 0)
                {
                    // Caso seja um ficheiro xml
                    co.Relatoriodigital(text.ToString(), xml);
                }
                else if (String.Compare(extension, json) == 0)
                {
                    // Caso seja um ficheirojson
                    co.Relatoriodigital(text.ToString(), json);
                }

                // Fechar o Form2
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
