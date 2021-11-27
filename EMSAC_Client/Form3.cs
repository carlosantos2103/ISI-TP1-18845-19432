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
    public partial class Form3 : Form
    {
        public Form3()
        {
            try
            {
                InitializeComponent();

                StringBuilder urlStatus = new StringBuilder();
                urlStatus.Append("https://covid19-api.vost.pt/Requests/get_status");

                HttpWebRequest requestStatus = WebRequest.Create(urlStatus.ToString()) as HttpWebRequest;
                using (HttpWebResponse responseStatus = requestStatus.GetResponse() as HttpWebResponse)
                {
                    if (responseStatus.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("GET falhou!!");
                        throw new ApplicationException(message);
                    }

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Root));
                    object objResponse = jsonSerializer.ReadObject(responseStatus.GetResponseStream());
                    Root jsonResponse = (Root)objResponse;

                    if (String.Compare(jsonResponse.status, "Server is OK") != 0)
                    {
                        string message = String.Format("API falhou!!");
                        throw new ApplicationException(message);
                    }
                }

                StringBuilder url = new StringBuilder();

                url.Append("https://covid19-api.vost.pt/Requests/get_last_update");


                HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("Get falhou!!");

                        throw new ApplicationException(message);
                    }

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
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Mostra a nova Form
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
                // Mostra a nova Form
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
                // Mostra a nova Form
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
                // Mostra a nova Form
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
