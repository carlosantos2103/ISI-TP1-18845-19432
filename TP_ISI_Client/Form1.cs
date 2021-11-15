using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TP_ISI_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Product product = new Product();

            //product.Name = "Apple";
            //product.ExpiryDate = new DateTime(2008, 12, 28);
            //product.Price = 3.99M;
            //product.Sizes = new string[] { "Small", "Medium", "Large" };

            //string output = JsonConvert.SerializeObject(product);
            //{
            //  "Name": "Apple",
            //  "ExpiryDate": "2008-12-28T00:00:00",
            //  "Price": 3.99,
            //  "Sizes": [
            //    "Small",
            //    "Medium",
            //    "Large"
            //  ]
            //}

            //Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);

            Infected p1 = new Infected("joao", DateTime.Now, "12", "1121", "rua", DateTime.Now);

            //Infected p1 = new Infected();
            //p1.Name = "joao";
            //p1.Birthday = DateTime.Now;
            //p1.Pacient_number = "12";
            //p1.Contact = "1121";
            //p1.Address = "rua";
            //p1.Register_date = DateTime.Now;
            //Isolated p2 = new Isolated("joao", DateTime.Now, "12", "1155", "rua", DateTime.Now, "1121");

            string output = JsonConvert.SerializeObject(p1);
            Covid.WebService1SoapClient co = new Covid.WebService1SoapClient();
            co.AddInfected(output);
            MessageBox.Show(output);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
