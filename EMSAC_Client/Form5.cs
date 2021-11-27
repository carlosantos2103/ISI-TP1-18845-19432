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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Ir a bse de Dados e retornar todos os produtos e mostrar
                listBox1.Items.Clear();
                foreach (string s in checkedListBox1.CheckedItems)
                {
                    listBox1.Items.Add(s);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                listBox1.Items.Add(checkedListBox1.CheckedIndices[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //StringBuilder url = new StringBuilder();

            //url.Append("https://localhost/ ");


            //HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;

            //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //{
            //    if (response.StatusCode != HttpStatusCode.OK)
            //    {
            //        string message = String.Format("Get falhou!!");

            //        throw new ApplicationException(message);
            //    }

            // Mostra os items selecionados
            foreach (var item in listBox1.Items)
            {
                MessageBox.Show(item.ToString());
            }

            //}

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                // Mostra a nova Form
                Form6 form6 = new Form6();
                form6.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // Verificar se o cliente n adicionou algum novo produto 
            List<Product> p1 = new List<Product>();
            // Retorna a lsita de produtos colocados pelo cliente
            p1 = Products.Show_Product();

            // Adiciona os itens
            foreach (Product item in p1)
            {
                checkedListBox1.Items.Add(item.Name.ToString());
            }

        }
    }
}
