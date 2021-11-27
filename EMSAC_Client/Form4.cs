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
    public partial class Form4 : Form
    {
        public Form4()
        {
            try
            {
                InitializeComponent();

                StringBuilder url = new StringBuilder();

                url.Append("https://localhost/");


                HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
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
            this.Close();
        }
    }
}
