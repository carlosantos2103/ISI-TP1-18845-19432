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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                //StringBuilder url = new StringBuilder();

                //url.Append("https://localhost/orders/createneworder");


                //HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;

                //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                //{
                //    if (response.StatusCode != HttpStatusCode.OK)
                //    {
                //        string message = String.Format("Get falhou!!");

                //        throw new ApplicationException(message);
                //    }
                //}

                List<ProductOrder> lst_nova = new List<ProductOrder>();
                lst_nova = ProductsOrder.Show_ProductOrder();

                Order encomenda = new Order(DateTime.Today, Int32.Parse(idequipa.Text), lst_nova);

                foreach (ProductOrder item in lst_nova)
                {
                    MessageBox.Show(item.Id_product.ToString());
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
            try
            {
                StringBuilder url = new StringBuilder();

                url.Append("https://localhost/orders/getproductlist");


                HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("Get falhou!!");

                        throw new ApplicationException(message);
                    }
                }

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
                // Rerira a visibilidade da label no form se der
                //label3.Visible = false;
                //idequipa.Enabled = false;

                ProductOrder p1 = new ProductOrder(Int32.Parse(idproduto.Text), Int32.Parse(quantidade.Text));
                ProductsOrder.Add_ProductOrder(p1);
                this.Close();

                Form5 form5 = new Form5();
                form5.Show();
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
                Form7 form7 = new Form7();
                form7.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
