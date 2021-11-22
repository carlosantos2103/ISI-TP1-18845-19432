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
            InitializeComponent();


            StringBuilder url = new StringBuilder();

            url.Append("https://covid19-api.vost.pt/Requests/get_last_update");


            HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse ) {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("Get falhou!!");

                    throw new ApplicationException(message);
                }

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Root));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                Root jsonResponse = (Root)objResponse;// ou "as Response";
                richTextBox1.Text = jsonResponse.ativos.ToString();

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

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
